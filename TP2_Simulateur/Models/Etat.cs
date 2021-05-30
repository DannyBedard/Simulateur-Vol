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

        public virtual void Action(){}
    }
}
