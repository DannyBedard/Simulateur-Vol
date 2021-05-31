using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    public class HelicoptereSecours : Aeronef
    {
        private Secours secourAffectee;
        public HelicoptereSecours() 
        {
            client = new Secours();
            etatActuel = 0;
            CycleEtat = new List<Etat>()
            {
                new EtatDisponnible(this),
                new EtatVolObservation(this),
            };
        }
        public override void EmbarquerClient(Client secour)
        {
            secourAffectee = (Secours) secour;
            base.DefinirTrajectoire(new Trajectoire(Position, secour.Position));
            ChangerEtat();
        }
        public override void ChangerEtat()
        {
            base.ChangerEtat();
        }

        public override string ToString()
        {
            return Nom + " (Hélicoptère de secours),  Vitesse : " + Vitesse;

        }
        public override bool ContientClient(Client client)
        {
            return secourAffectee == client;
        }

        internal void Secourir()
        {
            secourAffectee.Secourir();
        }
    }
}
