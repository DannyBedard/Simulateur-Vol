﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TP2_Simulateur.Models
{
    public class Trajectoire
    {
        public delegate void ArriverEventHandler();
        public event ArriverEventHandler TempsModifier;

        private PointF depart;
        private PointF destination;
        private PointF actuel;
        public PointF Depart { get { return depart; } }
        public PointF Destination { get { return destination; } }
        public PointF Actuel { get { return actuel; } }
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
        public Trajectoire(PointF p_depart, PointF p_destination) 
        {
            actuel = depart = p_depart;
            destination = p_destination;
        }


        public PointF NextPoint(double vitesseTemps, double vitesseAeronef) 
        {
            if (t >= 1)
            {
                return destination;
            }
            float deltaY = destination.Y - depart.Y;
            float deltaX = destination.X - depart.X;
            t += (float)(vitesseAeronef/100) * (float)vitesseTemps;
            float x = (1 - t) * (actuel.X) + t * (destination.X);
            float y = (1 - t) * (actuel.Y) + t * (destination.Y);

            return new PointF(x,y);
        }
    }
}
