using System;
using System.Collections.Generic;
using System.Text;

namespace TP2Editeur
{
    public class Aeroport
    {
        public string Nom { get; set; }
        public string Position { get; set; }
        public int MaxPassagersHeure { get; set; }
        public int MinPassagersHeure { get; set; }
        public int MaxMarchandisesHeure { get; set; }
        public int MinMarchandisesHeure { get; set; }
        public List<Aeronef> Aeronefs { get {return aeronefs; } set { this.aeronefs = value; } }
        private List<Aeronef> aeronefs = new List<Aeronef>();
        override public string ToString() {
            return Nom + " (" + Position + ") " + "MinPassagers : " + MinPassagersHeure + ", MaxPassagers : " + MaxPassagersHeure + ", MinMarchandises : " + MinMarchandisesHeure + ", MaxMarchandises : " + MaxMarchandisesHeure;
        }

        internal void ajouterAeronef(string aeronefType, string aeronefNom, int capacite, int vitesse, int tempsEmbarquement, int tempsDebarquement, int tempsEntretient)
        {
            Aeronef aeronef = FabriqueAeronef.fabriquerAeronef(aeronefType, aeronefNom, capacite, vitesse, tempsEmbarquement, tempsDebarquement, tempsEntretient);
            aeronefs.Add(aeronef);
        }
    }
}
