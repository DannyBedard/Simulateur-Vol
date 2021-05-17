using System;
using System.Collections.Generic;
using System.Text;

namespace TP2Editeur
{
    public abstract class Aeronef
    {
        public string Nom { get; set; }
        public int Capacite { get; set; }
        public int Vitesse { get; set; }
        public override abstract string ToString();
    }
}
