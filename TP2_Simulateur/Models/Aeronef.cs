using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    public abstract class Aeronef
    {
        public string Nom { get; set; }
        public int Vitesse { get; set; }
        public PointCartographique Destination { get; set; }
        public override abstract string ToString();
    }
}
