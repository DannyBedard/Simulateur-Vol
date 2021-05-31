using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    public abstract class AeronefConteneur : Aeronef
    {
        public int TempsEntretient { get; set; }
        public int TempsEmbarquement { get; set; }
        public int TempsDebarquement { get; set; }
        public override abstract string ToString();

        public abstract void Vider();
    }
}
