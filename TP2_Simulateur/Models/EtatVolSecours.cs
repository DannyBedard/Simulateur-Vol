using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TP2_Simulateur.Models
{
    class EtatVolSecours : EtatVol
    {
        public EtatVolSecours(Aeronef aeronef) : base(aeronef) { }
        override public void Action(double vitesseTemps)
        {
            base.Action(vitesseTemps);
            if (aeronef.Position == aeronef.AvoirTrajectoire().Destination)
            {
                tempsEcoule = 0;
                aeronef.ChangerEtat();
            }
        }
    }
}
