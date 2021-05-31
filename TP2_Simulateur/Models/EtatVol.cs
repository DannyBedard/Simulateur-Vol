using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TP2_Simulateur.Models
{
    abstract class EtatVol : Etat
    {
        private Trajectoire trajet;
        private bool estArrive = false;
        public EtatVol(Aeronef aeronef) : base(aeronef) { }
        public override void Action(double vitesseHorloge)
        {
            aeronef.Position = base.aeronef.AvoirTrajectoire().NextPoint(vitesseHorloge,aeronef.Vitesse);

        }
    }
}
