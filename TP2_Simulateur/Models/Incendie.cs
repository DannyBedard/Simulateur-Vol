﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    public class Incendie : Client
    {
        int envergure;
        public bool BesoinAvion { get; set; }
        public Incendie(PointCartographique point)
        {
            Random random = new Random();
            envergure = random.Next(1, 5); // envergure
            base.Position = point;
        }
    }
}
