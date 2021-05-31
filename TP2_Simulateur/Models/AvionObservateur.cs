using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
   public class AvionObservateur : Aeronef
    {
        Observateur observateurAffecte;
        public AvionObservateur() 
        {
            client = new Observateur();
            etatActuel = 0;
            CycleEtat = new List<Etat>()
            {
                new EtatDisponnible(this),
                new EtatVolObservation(this),
            };
        }

        public override void EmbarquerClient(Client observateur)
        {
            observateurAffecte = (Observateur)observateur;
            base.DefinirTrajectoire(new Trajectoire(Position, observateur.Position));
            ChangerEtat();
        }

        internal void ObservationTermine()
        {
            observateurAffecte.Observer();
        }

        public override string ToString()
        {
            return Nom + " (Observateur),  Vitesse : " + Vitesse;

        }
        public override bool BonAvion(Client p_client)
        {
            return p_client is Observateur;
        }
    }
}
