using System;
using System.Collections.Generic;
using System.Text;

namespace TP2Editeur
{
   public class AvionObservateur : Aeronef
    {
        public AvionObservateur() { }
        public AvionObservateur(string nom, int vitesse) {
            base.Nom = nom;
            base.Vitesse = vitesse;
        }
        public override string ToString()
        {
            return Nom + " (Observateur),  Vitesse : " + Vitesse;

        }
    }
}
