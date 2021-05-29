using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    public abstract class Client
    {
        PointCartographique position;

        public PointCartographique Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}
