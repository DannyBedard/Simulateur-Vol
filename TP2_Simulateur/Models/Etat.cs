using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TP2_Simulateur.Models
{
    public abstract class Etat
    {
        /// <summary>
        /// Temps ecoulé dans cet état
        /// </summary>
        protected double tempsEcoule = 0;
        /// <summary>
        /// Aéronef lié à l'état
        /// </summary>
        protected Aeronef aeronef;
        public Etat(Aeronef aeronef) 
        {
            this.aeronef = aeronef;
        }
        /// <summary>
        /// Exécute l'action de l'état selon la vitesse fourni
        /// </summary>
        /// <param name="vitesseHorloge">Vitesse du temps</param>
        public abstract void Action(double vitesseHorloge);

    }
}
