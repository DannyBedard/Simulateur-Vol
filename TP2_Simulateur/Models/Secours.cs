using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    class Secours : Client
    {
        public delegate void SecourFinitEventHandler(Secours secours);
        public event SecourFinitEventHandler secourFinit;

        public Secours()
        {
            EnAttente = false;
        }
        public Secours(PointCartographique point)
        {
            base.Position = point;
            EnAttente = true;
        }
        public void Secourir() 
        {
            secourFinit.Invoke(this);
        }
        public bool EnAttente { get; set; }
        public override string ToString()
        {
            return "Secours à la position " + Position.ToString();
        }
    }
}
