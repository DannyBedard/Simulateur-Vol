using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    public class Incendie : Client
    {
        public delegate void FeuEteintEventHandler(Incendie incendie);
        public event FeuEteintEventHandler FeuEtein;

        int envergure;
        bool besoinAvion;
        public Incendie(PointCartographique point)
        {
            Random random = new Random();
            envergure = random.Next(1, 5); // envergure
            besoinAvion = true;
            base.Position = point;
            BesoinAvion = true;
        }
        public Incendie() { }
        public int Envergure
        {
            get { return envergure;}
        }
        public bool BesoinAvion
        {
            get { return besoinAvion; }
            set { besoinAvion = value; }
        }

        //Se fait appeler à chaque Largage d'avion citerne, appel l'évennement
        internal void Eteindre()
        {
            envergure--;
            if (envergure == 0)
            {
                FeuEtein.Invoke(this);
            }
        }

        public override string ToString()
        {
            return "Incendie d'envergure " + envergure + " à la position " + Position.ToString();
        }
    }
}
