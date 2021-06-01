using System;
using System.Collections.Generic;
using System.Text;

namespace TP2Editeur
{
    public abstract class AeronefConteneur : Aeronef
    {
        int capacite;
        int tempsEmbarquement;
        int tempsDebarquement;
        public int Capacite { get { return capacite; } set { capacite = value; } }
        public int TempsEmbarquement { get { return tempsEmbarquement; } set { tempsEmbarquement = value; } }
        public int TempsDebarquement { get { return tempsDebarquement; } set { tempsDebarquement = value; } }
        public override abstract string ToString();
    }
}
