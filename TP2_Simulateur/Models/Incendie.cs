using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    public class Incendie : Client
    {
        int envergure;
        bool besoinAvion;
        public Incendie(PointCartographique point)
        {
            Random random = new Random();
            envergure = random.Next(1, 5); // envergure
            besoinAvion = true;
            base.Position = point;
        }
        public int Envergure
        {
            get { return envergure; }
        }
        public bool BesoinAvion
        {
            get { return besoinAvion; }
            set { besoinAvion = value; }
        }
    }
}
