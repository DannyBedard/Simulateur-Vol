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

        public virtual void Action(){}
        public void setEtatActuel()
        {
            etatActuel++;
            if (etatActuel > cycleEtat.Count)
                etatActuel = 0;
        }
    }
}
