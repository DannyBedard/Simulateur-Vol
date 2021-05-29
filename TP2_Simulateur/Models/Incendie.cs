﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    class Incendie : Client
    {
        PointCartographique point;
        int envergure;

        public Incendie(PointCartographique point)
        {
            Random random = new Random();
            envergure = random.Next(1, 5);
            this.point = point;
        }
        public PointCartographique Point
        {
            get { return point; }
        }
    }
}
