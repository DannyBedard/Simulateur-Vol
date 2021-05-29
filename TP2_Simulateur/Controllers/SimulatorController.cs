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
    public class SimulatorController
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

            SimulatorController controller = new SimulatorController();
            controller.ShowMainMenu();
        }

        public XmlSerializer xs;
        public ViewSimulator view;
        public Scenario scenario;
        private List<Aeroport> airports = new List<Aeroport>();
        private Thread simulatorThread;
        private Stopwatch timer = new Stopwatch();
        private Horloge horloge;

        private static bool running = false;
        public void ShowMainMenu() {
            view = new ViewSimulator(this);
            Bitmap map = new Bitmap("Ressources/carte.jpg");
            view.LoadMap(map); // Charge la map sur la vue
            view.Show();
            Application.Run(view);
        }
        
        private void UpdateSimView() {
            timer.Start();
            long now = timer.ElapsedMilliseconds;
            long lastFrame = timer.ElapsedMilliseconds;
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
                    view.UpdateSim(horloge.Vitesse);
                }
                
            }
            timer.Stop();
        }
        private void MettreAJourTemps(string temps)
        {
            view.AfficherTemps(temps);
        }
        private void GenererClient() 
        {
            // Cette méthode est appelée par un event à chaque fois qu'une heure passe (voir methode init et classe Horloge)
            // TODO : appeler le scénario afin qu'il génère des clients. (Doit coder une fabrique de client avant)
        }
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
            simulatorThread.Start();
            horloge.Start();
        }

        public bool TelechargerScenario(string fichier)
        {
            xs = new XmlSerializer(typeof(Scenario));
            bool valide = false;
            using (StreamReader rd = new StreamReader(fichier))
            {
                try
                {
                    scenario = (Scenario)xs.Deserialize(rd);
                    valide = true;
                }
                catch { }

                if (valide)
                    Init();

                return valide;

            }

        }

        public void ModifierVitesseTemps(double vitesse)
        {
            horloge.Vitesse = vitesse;
        }
    }


}
