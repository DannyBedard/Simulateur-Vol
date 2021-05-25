using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur
{
    public abstract class AeronefConteneur : Aeronef
    {
        public int Capacite { get; set; }
        public int TempsEntretient { get; set; }
        public int TempsEmbarquement { get; set; }
        public int TempsDebarquement { get; set; }
        public override abstract string ToString();
    }
}
