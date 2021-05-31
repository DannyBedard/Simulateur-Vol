using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
   public class AvionObservateur : Aeronef
    {
        public AvionObservateur() { }
        public AvionObservateur(string nom, int vitesse) {
            base.Nom = nom;
            base.Vitesse = vitesse;
            client = new Observateur();
            etatActuel = 0;
            CycleEtat = new List<Etat>()
            {
                new EtatDisponnible(this),
                new EtatVolObservation(this),
                new EtatMaintenance(this)
            };
        }

        public override void EmbarquerClient(Client client)
        {
            
        }

        public override string ToString()
        {
            return Nom + " (Observateur),  Vitesse : " + Vitesse;

        }

    }
}
