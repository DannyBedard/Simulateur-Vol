using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TP2_Simulateur.Models
{
    public abstract class Etat
    {
        int temps;
        PointF point;

        public PointF PositionActuel { get { return point; } }

        public virtual void Action(Aeronef aeronef){}
        public virtual void DefinirTrajectoire(Trajectoire trajet) { return; }
        public virtual PointF AvoirProchainPoint(double vitesseTemps, double vitesseAeronef) { return Point.Empty; }
    }
}
