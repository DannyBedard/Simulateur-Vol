using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TP2_Simulateur.Models
{
    public abstract class Aeronef
    {


        string nom;
        int vitesse;
        protected int etatActuel;
        protected Client client = new Passager();
        private bool estDisponnible = false;
        PointCartographique destination;
        PointCartographique position;
        List<Etat> cycleEtat;
        Trajectoire trajet = null;

        public List<Etat> CycleEtat
        {
            get { return cycleEtat; }
            set { cycleEtat = value; }
        }
        public int EtatActuel{ get { return etatActuel; } }
        public string Nom {
            get { return nom; } 
            set { nom = value; } 
        }
        public int Vitesse
        {
            get { return vitesse; }
            set { vitesse = value; }
        }
        public PointCartographique Position
        {
            get { return position; }
            set { position = value; }
        }
        public PointCartographique Destination { get { return destination; } set { destination = value; } }

        public override abstract string ToString();

        public void Action()
        {
            //cycleEtat[etatActuel].Action();
            SetEtatActuel();
        }
        private void SetEtatActuel()
        {
            etatActuel++;
            if (etatActuel > cycleEtat.Count)
                etatActuel = 0;
        }

        public void DefinirTrajectoire(Trajectoire trajectoire)
        {
            trajet = trajectoire;
        }
        public Trajectoire AvoirTrajectoire() 
        {
            return trajet;
        }
        public bool BonAvion(Client p_client) 
        {
            return client.GetType() == p_client.GetType();
        }

        public bool EstDisponnible()
        {
            if (cycleEtat[etatActuel] is EtatDisponnible)
            {
                return true;
            }
            return false;
        }

        public void Avancer(double vitesseHorloge)
        {
            position = trajet.NextPoint(vitesseHorloge, Vitesse);
        }

        internal bool EstEnVol()
        {
            if (cycleEtat[etatActuel] is EtatVol)
            {
                return true;
            }
            return false;
        }
    }
}
