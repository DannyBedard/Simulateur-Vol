using System;
using System.Collections.Generic;
using System.Text;

namespace TP2Editeur
{
    public class AvionMarchandises : AeronefConteneur
    {
        public AvionMarchandises() { }
        public AvionMarchandises(string aeronefNom, int capacite, int vitesse, int tempsEmbarquement, int tempsDebarquement, int tempsEntretient)
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
            return Nom + ", (Marchandises), Capacité : " + Capacite + ", Vitesse : " + Vitesse + ", Temps embarquement : " + TempsEmbarquement + ", Temps debarquement : " + TempsDebarquement + ", Temps entretient : " + TempsEntretient;
        }
    }
}
