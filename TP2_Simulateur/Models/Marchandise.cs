using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    public class Marchandise : Client
    {
        Aeroport destination;
        public Marchandise(Aeroport destination)
        {
            this.destination = destination;
        }
        public Marchandise() { }
        public Aeroport Destination
        {
            get { return destination; }
        }
    }
}
