using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    public class HelicoptereSecours : Aeronef
    {
        public HelicoptereSecours() { }
        public HelicoptereSecours(string nom, int vitesse)
        {
            base.Nom = nom;
            base.Vitesse = vitesse;
            client = new Secours();
            etatActuel = 0;
            CycleEtat = new List<Etat>()
            {
                new EtatDisponnible(),
                new EtatVolObservation(),
                new EtatMaintenance()
            };
        }
        public override string ToString()
        {
            return Nom + " (Hélicoptère de secours),  Vitesse : " + Vitesse;

        }
        public bool BonAvion(Client p_client)
        {
            return p_client.GetType() == client.GetType();
        }
    }
}
