using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Simulateur.Models
{
    public class AvionCiterne : AeronefConteneur
    {
        public int TempsChargement { get; set; }
        public int TempsLargage { get; set; }
        private Incendie incendieAffectee;
        public override void DefinirTrajectoire(Trajectoire trajectoire)
        {
            base.DefinirTrajectoire(trajectoire);
            ChangerEtat();
        }
        public AvionCiterne() 
        {
            client = new Incendie();
            etatActuel = 1;
            CycleEtat = new List<Etat>()
            {
                new EtatEmbarquement(this),
                new EtatDisponnible(this),
                new EtatVolSecours(this),
                new EtatDebarquement(this, EteindreFeu),
                new EtatVolSecours(this)
            };
        }

        public override string ToString()
        {
            return Nom + " (Citerne),  Vitesse : " + Vitesse + ", Temps chargement : " + TempsChargement + ", Temps largage : " + TempsLargage + ", Temps entretient : " + TempsEntretient;
        }
        public override void ChangerEtat()
        {
            base.ChangerEtat();
            if (CycleEtat[etatActuel] is EtatDisponnible && incendieAffectee.Envergure != 0)
            {
                RetourPositionOrigine();
                etatActuel++;
            }
            
        }
        public override void RetirerClient()
        {
            incendieAffectee = null;
        }
        private void EteindreFeu() 
        {
            incendieAffectee.Eteindre();

        }
        private void RetirerFeu(Incendie incendie) 
        {
            
        }
        public override void EmbarquerClient(Client client)
        {
            incendieAffectee = (Incendie)client;
            incendieAffectee.FeuEtein += RetirerFeu;
            base.DefinirTrajectoire(new Trajectoire(Position, client.Position));
            ChangerEtat();
        }
        public override bool ContientClient(Client client)
        {
            return client == incendieAffectee;
        }
        public override bool PretPourAtterrissage()
        {
            if (incendieAffectee.Envergure == 0 && (this.Position == AvoirTrajectoire().Destination))
            {
                return true;
            }
            return false;
        }
    }
}
