using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
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
        public bool BonAvion(Client p_client)
        {
            return p_client.GetType() == client.GetType();
        }
    }
}
