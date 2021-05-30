﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TP2_Simulateur.Models
{
    abstract class EtatVol : Etat
    {
        private Trajectoire trajet;
        private bool estArrive = false;
        //private float LongeurTrajet() 
        //{
            
        //}
        public override void DefinirTrajectoire(Trajectoire p_trajet)
        {
            trajet = p_trajet;
        }
        public override PointF AvoirProchainPoint(double vitesseTemps, double vitesseAeronef)
        {
            return trajet.NextPoint(vitesseTemps, vitesseAeronef);
        }
    }
}
