using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    class Observateur : Client
    {
        public Observateur() { }
        public Observateur(PointCartographique point)
        {
            base.Position = point;
        }
        public override string ToString()
        {
            return "Observation à la position " + Position.ToString();
        }
    }
}
