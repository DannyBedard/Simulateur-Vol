using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TP2_Simulateur.Models
{
    abstract class EtatVol : Etat
    {
        protected PointCartographique depart;
        protected PointCartographique destination;
        protected PointCartographique positionActuel;

        public PointF PositionActuel
        {
            get { return new PointF(1000, 1000); }
        }
        private float LongeurTrajet() 
        {
            return PointCartographique.DistanceEntre(depart, destination);
        }


    }
}
