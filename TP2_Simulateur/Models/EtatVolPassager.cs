using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    class EtatVolPassager : EtatVol 
    {
        public EtatVolPassager(Aeronef aeronef) : base(aeronef) { }
        public override void Action(double vitesseTemps)
        {
            base.Action(vitesseTemps);
            if (aeronef.Position == aeronef.AvoirTrajectoire().Destination)
            {
                tempsEcoule = 0;
                aeronef.ChangerEtat();
                aeronef.FaireAtterrissage();
            }
        }
    }
}
