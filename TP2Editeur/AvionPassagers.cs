using System;
using System.Collections.Generic;
using System.Text;

namespace TP2Editeur
{
    public class AvionPassagers : Aeronef
    {

        public AvionPassagers() { }
        public AvionPassagers(string aeronefNom, int capacite, int vitesse, int tempsEmbarquement, int tempsDebarquement, int tempsEntretient)
        {
            base.Nom = aeronefNom;
            base.Vitesse = vitesse;
            base.Capacite = capacite;
            TempsEmbarquement = tempsEmbarquement;
            TempsDebarquement = tempsDebarquement;
            TempsEntretient = tempsEntretient;
        }

        public int TempsEmbarquement { get; set; }
        public int TempsDebarquement { get; set; }
        public int TempsEntretient { get; set; }
        public override string ToString()
        {
            return Nom + " (Passagers), Capacité : " + Capacite + ", Vitesse : " + Vitesse + ", Temps embarquement : " + TempsEmbarquement + ", Temps debarquement : " + TempsDebarquement + ", Temps entretient : " + TempsEntretient;
        }
    }
}
