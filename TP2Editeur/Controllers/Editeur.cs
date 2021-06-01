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
            editeur.AfficherVue();
        }

        public void AfficherPositionChoisit(int x, int y)
        {
            string position = PositionCartographique.StringFromPixel(x,y,vueMap.avoirTailleCarte());
            vueEditeur.MettrePosition(position);
        }

        private Scenario scenario = new Scenario();
        private VueEditeur vueEditeur;
        private VueMap vueMap;
        public Editeur() {
            vueEditeur = new VueEditeur(this);
            
        }
        private void AfficherVue()
        {
            Application.Run(vueEditeur);
        }

        //Façade pour ajouter/Modifier/Supprimer un aéroport
        public void AjouterAeroport(string apName, string apPosition, int minPassager, int maxPassager, int minMarchandise, int maxMarchandise)
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
            MiseAjourAeroport();
        }

        public void ModifierAeroport(string apName, string apPosition, int minPassager, int maxPassager, int minMarchandise, int maxMarchandise, int index)
        {
            scenario.ModifierAeroport(apName, apPosition, minPassager, maxPassager, minMarchandise, maxMarchandise, index);
            MiseAjourAeroport();
        }

        public void SupprimerAeroport(int index)
        {
            scenario.SupprimerAeroport(index);
            MiseAjourAeroport();
        }

        //Change la vue lors d'un changement dans la liste d'aéroport
        private void MiseAjourAeroport()
        {
            List<Aeroport> aeroports = scenario.Aeroports;
            List<string> stringAeroports = new List<string>();
            foreach (Aeroport aeroport in aeroports)
            {
                stringAeroports.Add(aeroport.ToString());
            }
            vueEditeur.MettreAJourListeAeroports(stringAeroports);
        }

        //Façade pour avoir le format string des aéronef pour la vue
        public List<string> AvoirAeronefsDeAeroport(int selectedIndex)
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
        //Va cherche la méthode de sérialisation dans le scénario
        public void GenererScenario()
        {
            string chemin = vueEditeur.ChoisirEmplacement();
            scenario.Serialize(chemin);
        }

        //Façade pour ajouter/Modifier/Supprimer un aéronef
        public void AjouterAeronef(int apIndex, string aeronefNom, string aeronefType, int capacite, int vitesse, int tempsEmbarquement, int tempsDebarquement, int tempsEntretient)
        {
            scenario.AjouterAeronef(apIndex, aeronefType, aeronefNom, capacite, vitesse, tempsEmbarquement, tempsDebarquement, tempsEntretient);
        }
        public void AjouterAeronef(int apIndex, string aeronefNom, string aeronefType, int vitesse, int tempsChargement, int tempsLargage, int tempsEntretient)
        {
            scenario.AjouterAeronef(apIndex, aeronefType, aeronefNom, vitesse, tempsChargement, tempsLargage, tempsEntretient);
        }
        public void AjouterAeronef(int apIndex, string aeronefType, string aeronefNom, int vitesse)
        {
            scenario.AjouterAeronef(apIndex, aeronefType, aeronefNom, vitesse);
        }

        public void ModifierAeronef(int apIndex, string aeronefType, string aeronefNom, int vitesse, int index)
        {
            scenario.ModifierAeronef(apIndex, aeronefType, aeronefNom, vitesse, index);
        }
        public void ModifierAeronef(int apIndex, string aeronefNom, string aeronefType, int capacite, int vitesse, int tempsEmbarquement, int tempsDebarquement, int tempsEntretient, int index)
        {
            scenario.ModifierAeronef(apIndex, aeronefType, aeronefNom, capacite, vitesse, tempsEmbarquement, tempsDebarquement, tempsEntretient, index);
        }
        public void ModifierAeronef(int apIndex, string aeronefNom, string aeronefType, int vitesse, int tempsChargement, int tempsLargage, int tempsEntretient, int index)
        {
            scenario.ModifierAeronef(apIndex, aeronefType, aeronefNom, vitesse, tempsChargement, tempsLargage, tempsEntretient, index);
        }

        public void SupprimerAeronef(int apIndex, int index)
        {
            scenario.SupprimerAeronef(apIndex, index);
        }

        public void AfficherCarte()
        {
            vueMap = new VueMap(this);
            vueMap.Show();
        }
    }
}
