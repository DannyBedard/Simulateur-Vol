using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TP2_Simulateur.Models
{
    public class Aeroport
    {
        public delegate void DecollageEventHandler(Aeronef aeronef, Aeroport aeropartDepart);
        public event DecollageEventHandler DecollageEnCours;

        public string Nom { get; set; }
        public List<Aeronef> Aeronefs;
        public List<Passager> passagerEnAttente;
        public List<Marchandise> marchandiseEnAttente;
        public int MaxPassagersHeure;
        public int MinPassagersHeure;
        public int MaxMarchandisesHeure;
        public int MinMarchandisesHeure;
        
        public string Position {
            get 
            {
                return PositionCarto.ToString();
            } 
            set 
            {
                PositionCarto = new PointCartographique(value);
            } 
        }
        public PointCartographique PositionCarto { get; set; }

        public Aeroport() { }
        public Aeroport(string nom, string position) {
            PositionCarto = new PointCartographique(position);
            Nom = nom;
        }
        public Aeroport(string nom, PointCartographique position)
        {
            PositionCarto = position;
            Nom= nom;
        }
        override public string ToString()
        {
            return Nom + " (" + Position + ") " + "MinPassagers : " + MinPassagersHeure + ", MaxPassagers : " + MaxPassagersHeure + ", MinMarchandises : " + MinMarchandisesHeure + ", MaxMarchandises : " + MaxMarchandisesHeure;
        }
        public bool AvionDisponible(Client client) 
        {
            foreach (Aeronef aeronef in Aeronefs)
            {
                if (aeronef.BonAvion(client) && aeronef.EstDisponnible())
                {
                    return true;
                }
            }
            return false;
            
        }

        //private void EmbarquementPassager() 
        //{
        //    foreach (Passager passager in passagerEnAttente)
        //    {
        //        foreach (Aeronef aeronef in Aeronefs)
        //        {
        //            if (aeronef.EstEnAttenteDePassager())
        //            {
        //                if (aeronef.Destination == passager.Destination.PositionCarto)
        //                {

        //                }
        //                else if (aeronef.Destination == null)
        //                {
                            
        //                }
        //            }
        //        }

        //    }

        //}
        public void mettreAJour() 
        {
            //EmbarquementPassager();
        }

        public void AffecterIncendie(Client client)
        {
            Aeronef aeronefChoisit = null;
            foreach (Aeronef aeronef in Aeronefs)
            {
                if (aeronef.BonAvion(client)) 
                {
                    aeronef.Destination = client.Position;
                    aeronefChoisit = aeronef;
                    
                    break;
                }
            }
            if (aeronefChoisit != null)
            {
                aeronefChoisit.Position = this.PositionCarto;
                DecollageEnCours.Invoke(aeronefChoisit, this);
            }
        }
        internal void RetirerAeronef(Aeronef aeronef)
        {
            Aeronefs.Remove(aeronef);
        }


        internal List<string> AvoirClientInfo()
        {
            List<string> clientInfo = new List<string>();
            foreach (Passager passager in passagerEnAttente)
            {
                clientInfo.Add(passager.ToString());
            }
            foreach (Marchandise marchandise in marchandiseEnAttente)
            {
                clientInfo.Add(marchandise.ToString());
            }
            return clientInfo;
        }

        public List<string> AvoirAeronefInfo()
        {
            List<string> aeronefInfo = new List<string>();
            foreach (Aeronef aeronef in Aeronefs)
            {
                aeronefInfo.Add(aeronef.ToString());
            }
            return aeronefInfo;
        }
    }
}
