using System;
using System.Collections.Generic;
using System.Text;

namespace TP2Editeur
{
    public class Aeroport
    {
        string nom;
        string position;
        int maxPassagersHeure;
        int minPassagersHeure;
        int maxMarchandisesHeure;
        int minMarchandisesHeure;
        public string Nom { get { return nom; } set { nom = value; } }
        public string Position { get { return position; } set { position = value; } }
        public int MaxPassagersHeure { get { return maxPassagersHeure; } set { maxPassagersHeure = value; } }
        public int MinPassagersHeure { get { return minPassagersHeure; } set { minPassagersHeure = value; } }
        public int MaxMarchandisesHeure { get { return maxMarchandisesHeure; } set { maxMarchandisesHeure = value; } }
        public int MinMarchandisesHeure { get { return minMarchandisesHeure; } set { minMarchandisesHeure = value; } }
        public List<Aeronef> Aeronefs { get {return aeronefs; } set { this.aeronefs = value; } }
        private List<Aeronef> aeronefs = new List<Aeronef>();
        override public string ToString() {
            return Nom + "; (" + Position + ") " + "; MinPassagers : " + MinPassagersHeure + "; MaxPassagers : " + MaxPassagersHeure + "; MinMarchandises : " + MinMarchandisesHeure + "; MaxMarchandises : " + MaxMarchandisesHeure;
        }

        public void ajouterAeronef(string aeronefType, string aeronefNom, int capacite, int vitesse, int tempsEmbarquement, int tempsDebarquement, int tempsEntretient)
        {
            Aeronef aeronef = FabriqueAeronef.FabriquerAeronef(aeronefType, aeronefNom, capacite, vitesse, tempsEmbarquement, tempsDebarquement, tempsEntretient);
            aeronefs.Add(aeronef);
        }

        public void ajouterAeronef(string aeronefType, string aeronefNom, int vitesse, int tempsChargement, int tempsLargage, int tempsEntretient)
        {
            Aeronef aeronef = FabriqueAeronef.FabriquerAeronef(aeronefType, aeronefNom, vitesse, tempsChargement, tempsLargage, tempsEntretient);
            aeronefs.Add(aeronef);
        }

        public void ajouterAeronef(string aeronefType, string aeronefNom, int vitesse)
        {
            Aeronef aeronef = FabriqueAeronef.FabriquerAeronef(aeronefType, aeronefNom, vitesse);
            aeronefs.Add(aeronef);
        }

        public void SupprimerAeronef(int index)
        {
            aeronefs.RemoveAt(index);
        }

    }
}
