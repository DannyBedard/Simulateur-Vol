﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    public class AvionMarchandises : AeronefConteneur
    {
        public AvionMarchandises() 
        {
            client = new Marchandise();
            etatActuel = 0;
            CycleEtat = new List<Etat>()
            {
                new EtatDisponnible(),
                new EtatEmbarquement(),
                new EtatVolPassager(),
                new EtatDebarquement(),
                new EtatMaintenance()
            };
        }

        public override string ToString()
        {
            return Nom + " (Marchandises), Capacité : " + Capacite + ", Vitesse : " + Vitesse + ", Temps embarquement : " + TempsEmbarquement + ", Temps debarquement : " + TempsDebarquement + ", Temps entretient : " + TempsEntretient;
        }

    }
}
