using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    public class Passager : Client
    {
        Aeroport destination;
        public Passager(Aeroport destination)
        {
            this.destination = destination;
            
        }
        public Passager() { }
        public Aeroport Destination
        {
            get { return destination; }
        }
        public override string ToString()
        {
            return "";
        }
    }
}
