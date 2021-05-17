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
        private Scenario scenario = new Scenario();
        private VueEditeur vue;
        public Editeur() {
             vue = new VueEditeur(this);
        }
        public void afficherVue()
        {
            Application.Run(vue);
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
            scenario.ajouterAeroport(nouveauAeroport);
            List<Aeroport> aeroports = scenario.Aeroports;
            List<string> stringAeroports = new List<string>();
            foreach (Aeroport aeroport in aeroports) {
                stringAeroports.Add(aeroport.ToString());
            }
            vue.mettreAJourListeAeroports(stringAeroports);
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
            scenario.ajouterAeronef(apIndex, aeronefType, aeronefNom, capacite, vitesse, tempsEmbarquement, tempsDebarquement, tempsEntretient);
        }

        public void genererScenario()
        {
            string chemin = vue.choisirEmplacement();
            scenario.serialize(chemin);
        }

        public void ajouterAeronef(int apIndex, string aeronefNom, string aeronefType, int vitesse, int tempsChargement, int tempsLargage, int tempsEntretient)
        {
            scenario.ajouterAeronef(apIndex, aeronefType, aeronefNom, vitesse, tempsChargement, tempsLargage, tempsEntretient);
        }
    }
}
