using System;
using System.Collections.Generic;
using System.Text;

namespace TP2Editeur
{
    public abstract class Aeronef
    {
        string nom;
        int vitesse;
        int tempsEntretient;

        public string Nom { get { return nom; } set { nom = value; } }
        public int Vitesse { get { return vitesse; } set { vitesse = value; } }
        public int TempsEntretient { get { return tempsEntretient; } set { tempsEntretient = value; } }
        public override abstract string ToString();
    }
}
