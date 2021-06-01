using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Serialization;
using TP2_Simulateur.Models;

namespace TP2_Simulateur
{
    public class COTAI
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            COTAI controller = new COTAI();
            controller.ShowMainMenu();
        }
        /// <summary>
        /// XmlSerializer pour le chargement de scénario xml
        /// </summary>
        public XmlSerializer xs;
        /// <summary>
        /// Vue du simulateur
        /// </summary>
        public ViewSimulator view;
        /// <summary>
        /// Scénario chargé
        /// </summary>
        public Scenario scenario;
        /// <summary>
        /// Thread mettant a jour le scénario et la vue
        /// </summary>
        private Thread simulatorThread;
        /// <summary>
        /// timer utilisé pour limiter l'exécution du thread par seconde
        /// </summary>
        private Stopwatch timer = new Stopwatch();
        /// <summary>
        /// Horloge pour la vitesse du scénario
        /// </summary>
        private Horloge horloge;
        /// <summary>
        /// Indique si le programme est en cours d'exécution
        /// </summary>
        private static bool running = false;
        public void ShowMainMenu() {
            view = new ViewSimulator(this);
            Bitmap map = new Bitmap("Ressources/carte.jpg");
            view.LoadMap(map);
            Application.Run(view);
        }
        /// <summary>
        /// Met à jour le scénario et la vue 30 fois par secondes
        /// </summary>
        private void UpdateSimView() {

            timer.Start();
            long now = timer.ElapsedMilliseconds;
            long lastFrame = timer.ElapsedMilliseconds;
            GenererClient();
            //horloge.Vitesse = 50;
            while (running) 
            {
                now = timer.ElapsedMilliseconds;
                long delta = now - lastFrame;
                lastFrame = now;
                // 33 = 30 FPS 
                if (delta < 33)
                {
                    Thread.Sleep((int)(33 - delta));
                }
                if (running)
                {
                    scenario.MettreAJour(horloge.Vitesse);
                    List<Tuple<PointF[], Color>> trajets = scenario.AvoirTrajetsAeronefEnVol();
                    view.AjouterPointsTrajectoire(trajets);
                    view.UpdateSim(horloge.Vitesse);
                }
            }
            timer.Stop();
        }
        /// <summary>
        /// Envoi le temps à la vue
        /// </summary>
        /// <param name="temps"></param>
        private void MettreAJourTemps(string temps)
        {
            view.AfficherTemps(temps);
        }

        /// <summary>
        /// Dit au scénario de generer des clients et invoit les informations à la vue
        /// </summary>
        private void GenererClient() 
        {
            scenario.GenererClient();
            foreach (PointF point in scenario.AvoirPointsIncendies())
            {
                view.AjouterPointIncendie(point);
            }
            foreach (PointF point in scenario.AvoirPointsSecours())
            {
                view.AjouterPointSecours(point);
            }
            foreach (PointF point in scenario.AvoirPointsObservateur())
            {
                view.AjouterPointObservateur(point);
            }
        }
        /// <summary>
        /// Exécutée au début du programme
        /// </summary>
        private void Init() {
            scenario.TailleImage = view.GetImageSize();
            
            horloge = new Horloge();
            horloge.TempsModifier += MettreAJourTemps;
            horloge.ChangementHeure += GenererClient;

            view.AfficherTemps("00:00:00");

            foreach (PointF point in scenario.AvoirPointsAeroport())
            {
                view.AjouterPointAeroport(point);
            }
            List<string> aeroportsNom = scenario.AvoirToutAeroportsNom();
            view.ChargerAeroportsNom(aeroportsNom);
            running = true;
            simulatorThread = new Thread(new ThreadStart(UpdateSimView));
            simulatorThread.IsBackground = true;
            simulatorThread.Start();
            horloge.Start();
        }
        /// <summary>
        /// Importe et lance le scénario
        /// </summary>
        /// <param name="fichier">Emplacement du fichier</param>
        /// <returns></returns>
        public bool TelechargerScenario(string fichier)
        {
            xs = new XmlSerializer(typeof(Scenario));
            bool valide = false;
            
            try
            {
                StreamReader rd = new StreamReader(fichier);
                scenario = (Scenario)xs.Deserialize(rd);
                scenario.Init();
                scenario.EvenementTermine += MettreAJoursPoints;
                valide = true;
            }
            catch { }

            if (valide)
                Init();

            return valide;
            
        }
        /// <summary>
        /// Envoi à la vue les nouvelles informations à afficher
        /// </summary>
        private void MettreAJoursPoints()
        {
            view.ViderListesDePoint();
            foreach (PointF point in scenario.AvoirPointsIncendies())
            {
                view.AjouterPointIncendie(point);
            }
            foreach (PointF point in scenario.AvoirPointsSecours())
            {
                view.AjouterPointSecours(point);
            }
            foreach (PointF point in scenario.AvoirPointsObservateur())
            {
                view.AjouterPointObservateur(point);
            }
            view.ViderClientListView();
        }
        /// <summary>
        /// Modifie la vitesse de l'horloge
        /// </summary>
        /// <param name="vitesse"></param>
        public void ModifierVitesseTemps(double vitesse)
        {
            horloge.Vitesse = vitesse;
        }
        /// <summary>
        /// Retourne une liste contenant les informations des clients d'un aéroport
        /// </summary>
        /// <param name="index">Index de l'aéroport</param>
        /// <returns></returns>
        internal List<string> AvoirClientAeroport(int index)
        {
            return scenario.AvoirInfoClientAeroport(index);
        }
        /// <summary>
        /// Retourne une liste contenant les informations des aeronefs d'un aéroport
        /// </summary>
        /// <param name="index">Index de l'aéroport</param>
        /// <returns></returns>
        public List<string> AvoirAeronefAeroport(int index)
        {
            return scenario.AvoirAeronefAeroport(index);
        }
        /// <summary>
        /// Retourne une liste contenant les informations des clients (incendies,feux,secours)
        /// </summary>
        /// <returns></returns>
        public List<string> AvoirClient()
        {
            return scenario.AvoirClient();
        }
    }


}
