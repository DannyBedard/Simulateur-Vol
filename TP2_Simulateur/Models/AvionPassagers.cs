using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    public class AvionPassagers : AeronefConteneur
    {

        Client client;
        public AvionPassagers() 
        {
            client = new Passager();
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
        public AvionPassagers(string aeronefNom, int capacite, int vitesse, int tempsEmbarquement, int tempsDebarquement, int tempsEntretient)
        {
            base.Nom = aeronefNom;
            base.Vitesse = vitesse;
            base.Capacite = capacite;
            base.TempsEntretient = tempsEntretient;
            base.TempsEmbarquement = tempsEmbarquement;
            base.TempsDebarquement = tempsDebarquement;
            client = new Passager();
            etatActuel = 0;
            CycleEtat = new List<Etat>()
            {
                new EtatDisponnible(this),
                new EtatEmbarquement(this),
                new EtatVolSecours(this),
                new EtatDebarquement(this, null),
                new EtatMaintenance(this)
            };
        }

        public override void EmbarquerClient(Client client)
        {

        }
        public override string ToString()
        {
            return Nom + " (Passagers), Capacité : " + Capacite + ", Vitesse : " + Vitesse + ", Temps embarquement : " + TempsEmbarquement + ", Temps debarquement : " + TempsDebarquement + ", Temps entretient : " + TempsEntretient;
        }

        public override void Vider()
        {
            client = null;
            DefinirTrajectoire(null);
        }
        public override bool BonAvion(Client p_client)
        {
            return p_client is Passager;
        }
    }
}
