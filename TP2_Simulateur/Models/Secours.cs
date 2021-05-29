using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    class Secours : Client
    {
        PointCartographique point;

        public Secours(PointCartographique point)
        {
            this.point = point;
        }

        public PointCartographique Point
        {
            get { return point; }
        }
    }
}
