using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur
{
    public class AvionPassagers : AeronefConteneur
    {


        public AvionPassagers() { }
        public AvionPassagers(string aeronefNom, int capacite, int vitesse, int tempsEmbarquement, int tempsDebarquement, int tempsEntretient)
        {
            base.Nom = aeronefNom;
            base.Vitesse = vitesse;
            base.Capacite = capacite;
            base.TempsEntretient = tempsEntretient;
            base.TempsEmbarquement = tempsEmbarquement;
            base.TempsDebarquement = tempsDebarquement;
            
        }

        public override string ToString()
        {
            return Nom + " (Passagers), Capacité : " + Capacite + ", Vitesse : " + Vitesse + ", Temps embarquement : " + TempsEmbarquement + ", Temps debarquement : " + TempsDebarquement + ", Temps entretient : " + TempsEntretient;
        }
    }
}
