using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TP2Editeur
{

    public class Editeur
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
            Editeur editeur = new Editeur();
            editeur.afficherVue();
        }

        public void afficherPositionChoisit(int x, int y)
        {
            string position = PositionCartographique.stringFromPixel(x,y,vueMap.avoirTailleCarte());
            vueEditeur.mettrePosition(position);
        }

        private Scenario scenario = new Scenario();
        private VueEditeur vueEditeur;
        private VueMap vueMap;
        public Editeur() {
            vueEditeur = new VueEditeur(this);
            
        }
        public void afficherVue()
        {
            Application.Run(vueEditeur);
        }

        public void ajouterAeroport(string apName, string apPosition, int minPassager, int maxPassager, int minMarchandise, int maxMarchandise)
        {
            Aeroport nouveauAeroport = new Aeroport
            {
                Nom = apName,
                Position = apPosition,
                MaxPassagersHeure = maxPassager,
                MaxMarchandisesHeure = maxMarchandise,
                MinMarchandisesHeure = minMarchandise,
                MinPassagersHeure = minPassager,
            };
            scenario.AjouterAeroport(nouveauAeroport);
            List<Aeroport> aeroports = scenario.Aeroports;
            List<string> stringAeroports = new List<string>();
            foreach (Aeroport aeroport in aeroports) {
                stringAeroports.Add(aeroport.ToString());
            }
            vueEditeur.mettreAJourListeAeroports(stringAeroports);
        }

        public List<string> avoirAeronefsDeAeroport(int selectedIndex)
        {


            List<Aeroport> aeroports = scenario.Aeroports;
            Aeroport aeroport = aeroports[selectedIndex];
            List<string> aeronefs = new List<string>();
            foreach (Aeronef aeronef in aeroport.Aeronefs)
            {
                aeronefs.Add(aeronef.ToString());
            }
            return aeronefs;
        }

        public void ajouterAeronef(int apIndex, string aeronefNom, string aeronefType, int capacite, int vitesse, int tempsEmbarquement, int tempsDebarquement, int tempsEntretient)
        {
            scenario.AjouterAeronef(apIndex, aeronefType, aeronefNom, capacite, vitesse, tempsEmbarquement, tempsDebarquement, tempsEntretient);
        }

        public void genererScenario()
        {
            string chemin = vueEditeur.choisirEmplacement();
            scenario.Serialize(chemin);
        }

        public void ajouterAeronef(int apIndex, string aeronefNom, string aeronefType, int vitesse, int tempsChargement, int tempsLargage, int tempsEntretient)
        {
            scenario.AjouterAeronef(apIndex, aeronefType, aeronefNom, vitesse, tempsChargement, tempsLargage, tempsEntretient);
        }

        public void ajouterAeronef(int apIndex, string aeronefType, string aeronefNom, int vitesse)
        {
            scenario.AjouterAeronef(apIndex, aeronefType, aeronefNom, vitesse);
        }

        public void afficherCarte()
        {
            vueMap = new VueMap(this);
            vueMap.Show();
        }
    }
}
