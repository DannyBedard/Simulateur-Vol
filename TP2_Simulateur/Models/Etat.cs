using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TP2_Simulateur.Models
{
    public abstract class Etat
    {
        protected double tempsEcoule = 0;
        protected Aeronef aeronef;
        public Etat(Aeronef aeronef) 
        {
            this.aeronef = aeronef;
        }
        public abstract void Action(double vitesseHorloge);

    }
}
