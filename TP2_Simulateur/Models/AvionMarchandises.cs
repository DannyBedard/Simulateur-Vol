using System;
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
                new EtatDisponnible(this),
                new EtatEmbarquement(this),
                new EtatVolPassager(this),
                new EtatDebarquement(this, null),
                new EtatMaintenance(this)
            };
        }

        public override void EmbarquerClient(Client client)
        {
            
        }

        public override string ToString()
        {
            return Nom + " (Marchandises), Capacité : " + Capacite + ", Vitesse : " + Vitesse + ", Temps embarquement : " + TempsEmbarquement + ", Temps debarquement : " + TempsDebarquement + ", Temps entretient : " + TempsEntretient;
        }

        public override void Vider()
        {
            client = null;
        }
        public override bool BonAvion(Client p_client)
        {
            return p_client is Marchandise;
        }
    }
}
