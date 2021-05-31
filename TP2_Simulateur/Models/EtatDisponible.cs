using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    class EtatDisponnible : Etat
    {
        public EtatDisponnible(Aeronef aeronef) : base(aeronef) { }

        public override void Action(double vitesseHorloge)
        {
            return;
        }
    }
}
