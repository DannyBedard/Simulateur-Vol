using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TP2_Simulateur.Models
{
    class EtatVolSecours : EtatVol
    {
        public void Action(Aeronef aeronef)
        {

        }
        public PointF PositionActuel
        {
            get { return new PointF(1000, 1000); }
        }
    }
}
