using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TP2_Simulateur.Models
{
    public class Trajectoire
    {
        public delegate void ArriverEventHandler();
        public event ArriverEventHandler TempsModifier;

        private PointCartographique depart;
        private PointCartographique destination;
        private PointCartographique actuel;
        public PointCartographique Depart { get { return depart; } }
        public PointCartographique Destination { get { return destination; } }
        public PointCartographique Actuel { get { return actuel; } }
        private float t = 0F;
        public bool EstArrive 
        {
            get
            {
                if (t >= 1)
                    return true;
                return false;
            }
        }
        public Trajectoire(PointCartographique p_depart, PointCartographique p_destination) 
        {
            actuel = depart = p_depart;
            destination = p_destination;
        }


        public PointCartographique NextPoint(double vitesseTemps, double vitesseAeronef) 
        {
            if (t >= 1)
            {
                return destination;
            }
            float deltaY = destination.Latitude - depart.Latitude;
            float deltaX = destination.Longitude - depart.Longitude;
            t += (float)(vitesseAeronef/(PointCartographique.DistanceEntre(depart,destination)/10)) * (float)vitesseTemps;
            float x = (1 - t) * (actuel.Longitude) + t * (destination.Longitude);
            float y = (1 - t) * (actuel.Latitude) + t * (destination.Latitude);

            return new PointCartographique(y,x);
        }
    }
}
