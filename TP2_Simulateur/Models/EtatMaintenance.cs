using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    class EtatMaintenance : Etat
    {
        public EtatMaintenance(Aeronef aeronef) : base(aeronef) { }

        public override void Action(double vitesseHorloge)
        {
            AeronefConteneur avion = (AeronefConteneur)aeronef;
                if (tempsEcoule >= avion.TempsEntretient)
                {
                    tempsEcoule = 0;
                    avion.ChangerEtat();
                }
            tempsEcoule += vitesseHorloge / 10;
        }
        
        
    }
}
