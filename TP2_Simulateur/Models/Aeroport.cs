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

        /// <summary>
        ///Appel la méthode de l'aéronef qui compare le client que sert l'aéronef et le client en paramètre
        //Vérifie également si l'aéronef est dans l'état "disponible"
        /// </summary>
        /// <param name="client">Client dans le besoin</param>
        /// <returns>Retourne true si répond aux critères</returns>
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


        /// <summary>
        /// Parcours tous les passager en attentes ainsi que tous les aéronefs de l'aéroport
        /// Appel la méthode de l'aéronef qui compare le client que sert l'aéronef et le client en paramètre
        /// s'il y a assez de passager pour remplir l'avion, on procède à l'embarquement, changes la valeur de certaines données membres dont le trajet et on décolle
        /// </summary>
        /// <returns>null si il n'y pas assez de passager ou l'aéronef qui vient de décoller</returns>
        public Aeronef EmbarquementPassager() 
        {
            foreach (Passager passager in passagerEnAttente)
            {
                foreach (Aeronef aeronef in Aeronefs)
                {
                    if (aeronef.BonAvion(passager) && aeronef.EstDisponnible())
                    {
                        if (passager.Quantite >= aeronef.Capacite)
                        {
                            passager.Quantite -= aeronef.Capacite;
                            aeronef.Destination = passager.Destination.PositionCarto;
                            aeronef.Position = this.PositionCarto;
                            aeronef.DefinirTrajectoire(new Trajectoire(this.PositionCarto, passager.Destination.PositionCarto));
                            aeronef.ChangerEtat();
                            DecollageEnCours.Invoke(aeronef, this);
                            return aeronef;
                        }
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Parcours tous les marchandises en attentes ainsi que tous les aéronefs de l'aéroport
        /// Appel la méthode de l'aéronef qui compare le client que sert l'aéronef et le client en paramètre
        /// s'il y a assez de marchandises pour remplir l'avion, on procède à l'embarquement, changes la valeur de certaines données membres dont le trajet et on décolle
        /// </summary>
        /// <returns>null si il n'y pas assez de marchandises ou l'aéronef qui vient de décoller</returns>
        public Aeronef EmbarquementMarchandise()
        {
            foreach (Marchandise marchandise in marchandiseEnAttente)
            {
                foreach (Aeronef aeronef in Aeronefs)
                {
                    if (aeronef.BonAvion(marchandise) && aeronef.EstDisponnible())
                    {
                        if (marchandise.Tonne >= aeronef.Capacite)
                        {
                            marchandise.Tonne -= aeronef.Capacite;
                            aeronef.Destination = marchandise.Destination.PositionCarto;
                            aeronef.Position = this.PositionCarto;
                            aeronef.DefinirTrajectoire(new Trajectoire(this.PositionCarto, marchandise.Destination.PositionCarto));
                            aeronef.ChangerEtat();
                            DecollageEnCours.Invoke(aeronef, this);
                            return aeronef;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Appel la méthode de l'aéronef qui compare le client que sert l'aéronef et le client en paramètre
        /// Si une affectation est possible, on procède au décollage
        /// </summary>
        /// <param name="client">Incendies dans le besoin</param>
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
                aeronefChoisit.EmbarquerClient(client);
                DecollageEnCours.Invoke(aeronefChoisit, this);
            }
        }
        /// <summary>
        /// Vérifie si des embarquements sont possibles et mets à jours les états
        /// </summary>
        /// <param name="vitesseHorloge">Vitesse actuel du programme</param>
        internal void MettreAJour(double vitesseHorloge)
        {
            EmbarquementPassager();
            EmbarquementMarchandise();
            List<Aeronef> aeronefsCopi = new List<Aeronef>(Aeronefs);
            foreach (Aeronef aeronef in aeronefsCopi)
            {
                aeronef.MettreAJourEtat(vitesseHorloge);
            }
            
        }
        /// <summary>
        /// Méthode Externe permettant de retirer un aéronefs
        /// </summary>
        /// <param name="aeronef"> aéronef à retirer</param>
        public void RetirerAeronef(Aeronef aeronef)
        {
            Aeronefs.Remove(aeronef);
        }
       
        /// <summary>
        /// Parcours tous les clients
        /// </summary>
        /// <returns>Une liste de string de tous les clients en attentes dans l'aéroport</returns>
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

        /// <summary>
        /// Parcours tous les aéronefs
        /// </summary>
        /// <returns>Une liste de string de tous les aéronefs de l'aéroport</returns>
        public List<string> AvoirAeronefInfo()
        {
            List<string> aeronefInfo = new List<string>();
            foreach (Aeronef aeronef in Aeronefs)
            {
                aeronefInfo.Add(aeronef.ToString());
            }
            return aeronefInfo;
        }

        /// <summary>
        /// Appel la méthode de l'aéronef qui compare le client que sert l'aéronef et le client en paramètre
        /// Si une affectation est possible, on procède au décollage
        /// </summary>
        /// <param name="client">Secours dans le besoin</param>
        internal void AffecterSecour(Client secours)
        {
            Aeronef aeronefChoisit = null;
            foreach (Aeronef aeronef in Aeronefs)
            {
                if (aeronef.BonAvion(secours))
                {
                    aeronef.Destination = secours.Position;
                    aeronefChoisit = aeronef;
                    break;
                }
            }
            if (aeronefChoisit != null)
            {
                aeronefChoisit.Position = this.PositionCarto;
                aeronefChoisit.EmbarquerClient(secours);
                DecollageEnCours.Invoke(aeronefChoisit, this);
            }
        }

        /// <summary>
        /// Méthode Externe permettant d'ajouter un aéronefs
        /// </summary>
        /// <param name="aeronef"> aéronef à ajouter</param>
        internal void AjouterAeronef(Aeronef aeronef)
        {
            Aeronefs.Add(aeronef);
        }

        /// <summary>
        /// Appel la méthode de l'aéronef qui compare le client que sert l'aéronef et le client en paramètre
        /// Si une affectation est possible, on procède au décollage
        /// </summary>
        /// <param name="client">Observateur dans le besoin</param>
        internal void AffecterObservateur(Client client)
        {
            Aeronef aeronefChoisit = null;
            foreach (Aeronef aeronef in Aeronefs)
            {
                if (aeronef.BonAvion(client) && aeronef.EstDisponnible())
                {
                    aeronef.Destination = client.Position;
                    aeronefChoisit = aeronef;
                    break;
                }
            }
            if (aeronefChoisit != null)
            {
                aeronefChoisit.Position = this.PositionCarto;
                aeronefChoisit.EmbarquerClient(client);
                DecollageEnCours.Invoke(aeronefChoisit, this);
            }
        }
    }
}
