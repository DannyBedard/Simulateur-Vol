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
                if (aeronef.BonAvion(client))
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

        public void AffecterClient(Client client)
        {
            foreach (Aeronef aeronef in Aeronefs)
            {
                if (aeronef.BonAvion(client)) 
                {
                    DecollageEnCours.Invoke(aeronef, this);
                    /*AvionCiterne avion = (AvionCiterne)aeronef; 
                    avion.Destination = client.Position;
                    if (avion.EstRemplit())
                    {
                        DecollageEnCours.Invoke(avion, this);
                    }*/
                }
            }
        }
    }
}
