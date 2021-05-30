using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    public class Passager : Client
    {
        Aeroport destination;
        int quantite;
        public Passager(Aeroport destination, int quantite)
        {
            this.destination = destination;
            this.quantite = quantite;
        }
        public Passager() { }
        public Aeroport Destination
        {
            get { return destination; }
        }
        public override string ToString()
        {
            return quantite.ToString() + " passagers en destination de " + destination.Nom;
        }
    }
}
