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
        protected int capacite;
        protected int etatActuel;
        protected Client client;
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
        public int Capacite
        {
            get { return capacite; }
            set { capacite = value; }
        }
        /// <summary>
        /// Une fois arrivé, inverse la destination et l'arrivé pour revenir
        /// </summary>
        public void RetourPositionOrigine()
        {
            trajet = new Trajectoire(trajet.Destination, trajet.Depart);
        }
        /// <summary>
        /// Appel l'event d'atterissage
        /// </summary>
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
        /// <summary>
        /// Cycle des états, incrémente puis rendu au point, revient au premier
        /// </summary>
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

        /// <summary>
        /// Méthode externe permettant d'ajouter un trajet
        /// </summary>
        /// <param name="trajectoire">Trajet à affecter</param>
        public virtual void DefinirTrajectoire(Trajectoire trajectoire)
        {
            trajet = trajectoire;
        }
        public Trajectoire AvoirTrajectoire() 
        {
            return trajet;
        }
        public abstract bool BonAvion(Client p_client);

        /// <summary>
        /// Vérifie l'état actuel 
        /// </summary>
        /// <returns>true si disponible, sinon false</returns>
        public bool EstDisponnible()
        {
            if (cycleEtat[etatActuel] is EtatDisponnible)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Appel l'action de l'état actuel
        /// </summary>
        /// <param name="vitesseTemps">Vitesse actuel du programme</param>
        public void MettreAJourEtat(double vitesseTemps) 
        {
            cycleEtat[etatActuel].Action(vitesseTemps);
        }

        /// <summary>
        /// Vérifie l'état actuel 
        /// </summary>
        /// <returns>true si En vol, sinon false</returns>
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
