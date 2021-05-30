using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    public class Marchandise : Client
    {
        Aeroport destination;
        double tonne;
        public Marchandise(Aeroport destination, double tonne)
        {
            this.destination = destination;
            this.tonne = tonne;
        }
        public Marchandise() { }
        public Aeroport Destination
        {
            get { return destination; }
        }
        public override string ToString()
        {
            return tonne.ToString() + " tonnes de marchandise en destination de " + destination.Nom;
        }
    }
}
