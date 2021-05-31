using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    class EtatEmbarquement : Etat
    {
        public EtatEmbarquement(Aeronef aeronef) : base(aeronef) { }

        public override void Action(double vitesseHorloge)
        {
            if (aeronef is AvionCiterne)
            {
                AvionCiterne avion = (AvionCiterne)aeronef;
                if (tempsEcoule >= avion.TempsChargement)
                {
                    tempsEcoule = 0;
                    avion.ChangerEtat();
                }
            }
            else
            {
                AeronefConteneur avion = (AeronefConteneur)aeronef;
                if (tempsEcoule >= avion.TempsEmbarquement)
                {
                    tempsEcoule = 0;
                    avion.ChangerEtat();
                }
            }
            tempsEcoule += vitesseHorloge / 10;
        }
    }
}
