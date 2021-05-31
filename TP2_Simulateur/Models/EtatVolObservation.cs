using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    class EtatVolObservation : EtatVol
    {
        bool retourEffectue = false;
        public EtatVolObservation(Aeronef aeronef) : base(aeronef) { }
        public override void Action(double vitesseHorloge)
        {
            base.Action(vitesseHorloge);
            if (aeronef.Position == aeronef.AvoirTrajectoire().Destination)
            {
                if (retourEffectue)
                {
                    aeronef.FaireAtterrissage();
                    aeronef.ChangerEtat();
                }
                else 
                {
                    aeronef.RetourPositionOrigine();
                    if (aeronef is HelicoptereSecours)
                    {
                        HelicoptereSecours helico = (HelicoptereSecours)aeronef;
                        helico.Secourir();
                    }
                }
                retourEffectue = !retourEffectue;
            }
        }
    }
}
