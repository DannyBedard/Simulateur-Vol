using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TP2_Simulateur.Models
{
    public class Trajectoire
    {
        /// <summary>
        /// Déclenché une fois arrivé à destination
        /// </summary>
        public delegate void ArriverEventHandler();
        /// <summary>
        /// Déclenché une fois arrivé à destination
        /// </summary>
        public event ArriverEventHandler ArriverADestinnation;
        /// <summary>
        /// PointCartographique de départ
        /// </summary>
        private PointCartographique depart;
        /// <summary>
        /// PointCartographique de destination
        /// </summary>
        private PointCartographique destination;
        /// <summary>
        /// PointCartographique actuel
        /// </summary>
        private PointCartographique actuel;
        /// <summary>
        /// PointCartographique de départ
        /// </summary>
        public PointCartographique Depart { get { return depart; } }
        /// <summary>
        /// PointCartographique de destination
        /// </summary>
        public PointCartographique Destination { get { return destination; } }
        /// <summary>
        /// PointCartographique actuel
        /// </summary>
        public PointCartographique Actuel { get { return actuel; } }
        /// <summary>
        /// Aucune idée, variable nécéssaire pour le calcule du prochain PointCartographique
        /// </summary>
        private float t = 0F;
        /// <summary>
        /// Construit une trajectoire du point de départ, au point de destination
        /// </summary>
        /// <param name="p_depart"></param>
        /// <param name="p_destination"></param>
        public Trajectoire(PointCartographique p_depart, PointCartographique p_destination) 
        {
            actuel = depart = p_depart;
            destination = p_destination;
        }
        /// <summary>
        /// Calcule le prochain point cartographique selon la vitesse du temps et de l'aeronef
        /// </summary>
        /// <param name="vitesseTemps">Vitesse du temps</param>
        /// <param name="vitesseAeronef">Vitesse de l'aeronef</param>
        /// <returns></returns>
        public PointCartographique NextPoint(double vitesseTemps, double vitesseAeronef) 
        {
            if (t >= 1)
            {
                return destination;
            }
            t += (float)(vitesseAeronef/(PointCartographique.DistanceEntre(depart,destination)/10)) * (float)vitesseTemps;
            float x = (1 - t) * (actuel.Longitude) + t * (destination.Longitude);
            float y = (1 - t) * (actuel.Latitude) + t * (destination.Latitude);

            return new PointCartographique(y,x);
        }
    }
}
