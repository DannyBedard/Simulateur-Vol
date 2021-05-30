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
    }
}
