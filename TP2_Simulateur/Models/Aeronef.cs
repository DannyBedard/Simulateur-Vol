using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    public abstract class Aeronef
    {
        string nom;
        int vitesse;
        protected int etatActuel;
        protected Client client = new Passager();
        PointCartographique destination;
        PointCartographique position;
        List<Etat> cycleEtat;

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
            cycleEtat[etatActuel].Action();
            SetEtatActuel();
        }
        private void SetEtatActuel()
        {
            etatActuel++;
            if (etatActuel > cycleEtat.Count)
                etatActuel = 0;
        }
        public virtual bool BonAvion(Client p_client)
        {
            return p_client.GetType() == client.GetType();
        }
    }
}
