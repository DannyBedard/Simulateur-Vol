using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    class EtatDebarquement : Etat
    {
        /// <summary>
        /// Exécuté quand l'état se termine
        /// </summary>
        public delegate void DebarquementTermineEventHandler();
        public event DebarquementTermineEventHandler DebarquementTermine;

        public EtatDebarquement(AeronefConteneur aeronef, DebarquementTermineEventHandler methode ) : base(aeronef) 
        {
            DebarquementTermine += methode;
        }

        public override void Action(double vitesseHorloge)
        {
            if (aeronef is AvionCiterne)
            {
                AvionCiterne avion = (AvionCiterne)aeronef;
                if (tempsEcoule >= avion.TempsLargage)
                {
                    aeronef.RetourPositionOrigine();
                    DebarquementTermine.Invoke();
                    aeronef.ChangerEtat();
                }
            }
            else
            {
                AeronefConteneur avion = (AeronefConteneur)aeronef;
                if (tempsEcoule >= avion.TempsDebarquement)
                {
                    avion.Vider();
                    avion.ChangerEtat();
                }
            }
            tempsEcoule += vitesseHorloge / 10;
        }
    }
}
