using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    class Observateur : Client
    {
        PointCartographique point;

        public Observateur(PointCartographique point)
        {
            this.point = point;
        }

        public PointCartographique Point
        {
            get { return point; }
        }
    }
}
