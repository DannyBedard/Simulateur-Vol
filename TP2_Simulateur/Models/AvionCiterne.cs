using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    public class AvionCiterne : Aeronef
    {
        public int TempsChargement { get; set; }
        public int TempsLargage { get; set; }
        public int TempsEntretient { get; set; }
        private double qtChargement = 100.0;
        public bool EstRemplit() 
        {
            if (qtChargement == 100.0)
            {
                return true;
            }
            return false;
        }
        public void Remplire() 
        {
            // Trouver un moyen de remplir l'avion selon son temps de chargement
        }
        public AvionCiterne() { }
        public AvionCiterne(string aeronefNom, int vitesse, int tempsChargement, int tempsLargage, int tempsEntretient)
        {
            base.Nom = aeronefNom;
            base.Vitesse = vitesse;
            TempsChargement = tempsChargement;
            TempsLargage = tempsLargage;
            TempsEntretient = tempsEntretient;
            etatActuel = 0;
            CycleEtat = new List<Etat>()
            {
                new EtatEmbarquement(),
                new EtatDisponnible(),
                new EtatVolSecours(),
                new EtatDebarquement(),
                new EtatVolSecours()
            };
        }

        public override string ToString()
        {
            return Nom + " (Citerne),  Vitesse : " + Vitesse + ", Temps chargement : " + TempsChargement + ", Temps largage : " + TempsLargage + ", Temps entretient : " + TempsEntretient;
        }

    }
}
