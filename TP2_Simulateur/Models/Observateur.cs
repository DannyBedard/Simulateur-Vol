using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    class Observateur : Client
    {
        public delegate void ObservationFinitEventHandler(Observateur observateur);
        public event ObservationFinitEventHandler ObservationFinit;

        public Observateur() { }
        public Observateur(PointCartographique point)
        {
            base.Position = point;
            EnAttente = true;
        }

        public bool EnAttente { get; internal set; }
        public void Observer() 
        {
            ObservationFinit.Invoke(this);
        }
        public override string ToString()
        {
            return "Observation à la position " + Position.ToString();
        }
    }
}
