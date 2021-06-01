using System;
using System.Collections.Generic;
using System.Text;

namespace TP2Editeur
{
    public class AvionCiterne : Aeronef
    {
        int tempsChargement;
        int tempsLargage;
        public int TempsChargement { get { return tempsChargement; } set { tempsChargement = value; } }
        public int TempsLargage { get { return tempsLargage; } set { tempsLargage = value; } }

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
            return Nom + ", (Citerne),  Vitesse : " + Vitesse + ", Temps chargement : " + TempsChargement + ", Temps largage : " + TempsLargage + ", Temps entretient : " + TempsEntretient;

        }
    }
}
