using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TP2_Simulateur.Models
{
    public abstract class Aeronef
    {

        public delegate void AtterrissageEventHandler(Aeronef aeronef, PointCartographique aeroportPosition);
        public event AtterrissageEventHandler Atterrissage;

        string nom;
        int vitesse;
        protected int etatActuel;
        protected Client client = new Passager();
        PointCartographique destination;
        PointCartographique position;

        virtual public bool PretPourAtterrissage() { return false; }

        List<Etat> cycleEtat;
        Trajectoire trajet = null;
        public List<Etat> CycleEtat
        {
            get { return cycleEtat; }
            set { cycleEtat = value; }
        }

        public void RetourPositionOrigine()
        {
            trajet = new Trajectoire(trajet.Destination, trajet.Depart);
        }
        public void FaireAtterrissage() 
        {
            try
            {
                RetirerClient();
                Atterrissage.Invoke(this, this.AvoirTrajectoire().Destination);
            }
            catch { };
        }

        virtual public void RetirerClient()
        {
            return;
        }

        public virtual void ChangerEtat()
        {
            etatActuel++;
            if (etatActuel >= cycleEtat.Count)
            {
                etatActuel = 0;
            }
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


        public virtual void DefinirTrajectoire(Trajectoire trajectoire)
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

        public void MettreAJourEtat(double vitesseTemps) 
        {
            cycleEtat[etatActuel].Action(vitesseTemps);
        }

        internal bool EstEnVol()
        {
            if (cycleEtat[etatActuel] is EtatVol)
            {
                return true;
            }
            return false;
        }

        public abstract void EmbarquerClient(Client client);

        virtual public bool ContientClient(Client client)
        {
            return false;
        }
    }
}
