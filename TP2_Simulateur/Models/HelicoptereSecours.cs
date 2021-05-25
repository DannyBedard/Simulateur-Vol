using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur
{
    public class HelicoptereSecours : Aeronef
    {
        public HelicoptereSecours() { }
        public HelicoptereSecours(string nom, int vitesse)
        {
            base.Nom = nom;
            base.Vitesse = vitesse;
        }
        public override string ToString()
        {
            return Nom + " (Hélicoptère de secours),  Vitesse : " + Vitesse;

        }
    }
}
