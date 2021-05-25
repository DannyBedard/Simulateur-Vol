using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur
{
    public class AvionCiterne : Aeronef
    {
        public int TempsChargement { get; set; }
        public int TempsLargage { get; set; }
        public int TempsEntretient { get; set; }

        public AvionCiterne() { }
        public AvionCiterne(string aeronefNom, int vitesse, int tempsChargement, int tempsLargage, int tempsEntretient)
        {
            base.Nom = aeronefNom;
            base.Vitesse = vitesse;
            TempsChargement = tempsChargement;
            TempsLargage = tempsLargage;
            TempsEntretient = tempsEntretient;
        }



        public override string ToString()
        {
            return Nom + " (Citerne),  Vitesse : " + Vitesse + ", Temps chargement : " + TempsChargement + ", Temps largage : " + TempsLargage + ", Temps entretient : " + TempsEntretient;

        }
    }
}
