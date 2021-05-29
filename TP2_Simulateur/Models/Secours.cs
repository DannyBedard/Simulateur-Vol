using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    class Secours : Client
    {

        public Secours(PointCartographique point)
        {
            base.Position = point;
        }
    }
}
