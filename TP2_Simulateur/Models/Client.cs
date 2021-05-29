using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    public abstract class Client
    {
        private PointCartographique position;
        protected int allerRetour;
        public PointCartographique Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}
