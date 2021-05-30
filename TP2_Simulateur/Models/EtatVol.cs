using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TP2_Simulateur.Models
{
    abstract class EtatVol : Etat
    {
        private PointCartographique depart;
        private PointCartographique destination;
        private float LongeurTrajet() 
        {
            return PointCartographique.DistanceEntre(depart, destination);
        }
    }
}
