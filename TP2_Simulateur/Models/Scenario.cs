using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Serialization;

namespace TP2_Simulateur.Models
{
    [XmlInclude(typeof(AvionPassagers))]
    [XmlInclude(typeof(AvionCiterne))]
    [XmlInclude(typeof(AvionMarchandises))]
    [XmlInclude(typeof(AvionObservateur))]
    [XmlInclude(typeof(HelicoptereSecours))]
    public class Scenario
    {
        public delegate void EvenementTermineEventHandler();
        public event EvenementTermineEventHandler EvenementTermine;

        List<Client> incendies = new List<Client>();
        List<Client> observateurs = new List<Client>();
        List<Client> secours = new List<Client>();
        public List<Aeroport> Aeroports;
        public List<Aeronef> aeronefsEnVol = new List<Aeronef>();
        public SizeF TailleImage { get; set; }
        public List<Aeroport> ListAeroport
        {
            get { return Aeroports; }
        }
        public Scenario() 
        {
        }
        public List<PointF> AvoirPointsAeroport()
        {
            List<PointF> points = new List<PointF>();
            foreach (Aeroport ap in Aeroports)
            {
                points.Add(ap.PositionCarto.Transposer(TailleImage));
            }
            return points;
        }
        public List<PointF> AvoirPointsIncendies()
        {
            List<PointF> points = new List<PointF>();
            foreach (Client client in incendies)
            {
                points.Add(client.Position.Transposer(TailleImage));
            }
            return points;
        }

        public IEnumerable<PointF> AvoirPointsSecours()
        {
            List<PointF> points = new List<PointF>();
            foreach (Client client in secours)
            {
                points.Add(client.Position.Transposer(TailleImage));
            }
            return points;
        }

        public IEnumerable<PointF> AvoirPointsObservateur()
        {
            List<PointF> points = new List<PointF>();
            foreach (Client client in observateurs)
            {
                points.Add(client.Position.Transposer(TailleImage));
            }
            return points;
        }

        public List<string> AvoirToutAeroportsNom()
        {
            List<string> points = new List<string>();
            foreach (Aeroport ap in Aeroports)
            {
                points.Add(ap.Nom);
            }
            return points;
        }

        public List<Tuple<PointF[], Color>> AvoirTrajetsAeronefEnVol()
        {
            List<Tuple<PointF[], Color>> trajets = new List<Tuple<PointF[], Color>>();
            foreach (Aeronef aeronef in aeronefsEnVol)
            {
                
                    PointF[] points = new PointF[2];
                    Trajectoire trajet = aeronef.AvoirTrajectoire();
                    points[0] = trajet.Depart.Transposer(TailleImage);
                    points[1] = aeronef.Position.Transposer(TailleImage);
                    Color color = Color.Transparent;
                    if (aeronef is AvionCiterne)
                        color = Color.Yellow;
                    else if (aeronef is AvionPassagers)
                        color = Color.Green;
                    else if (aeronef is AvionMarchandises)
                        color = Color.Blue;
                    else if (aeronef is HelicoptereSecours)
                        color = Color.Red;
                    else if (aeronef is AvionObservateur)
                        color = Color.Gray;

                    trajets.Add(new Tuple<PointF[], Color>(points, color));
            }
            return trajets;
        }

        public void MettreAJour(double vitesseHorloge)
        {
            List<Aeronef> aeronefsEnVolCopi = new List<Aeronef>(aeronefsEnVol);
            foreach (Aeronef aeronef in aeronefsEnVolCopi)
            {
                aeronef.MettreAJourEtat(vitesseHorloge);
            }
            foreach (Aeroport ap in Aeroports)
            {
                ap.MettreAJour(vitesseHorloge);
            }
            GererEvenement();
        }

        public void GenererClient()
        {
            FabriqueClient.GenererIncendies(incendies);
            FabriqueClient.GenererSecours(secours);
            FabriqueClient.GenererObservateurs(observateurs);
            FabriqueClient.GenererClientAeroport(Aeroports);
        }
        public void GererDecollage(Aeronef aeronef, Aeroport depart) 
        {
            aeronefsEnVol.Add(aeronef);
            aeronef.Atterrissage += GererAtterrissage;
            depart.RetirerAeronef(aeronef);
        }

        public void GererEvenement()
        {
            foreach (Incendie incendie in incendies)
            {
                if (incendie.BesoinAvion)
                {
                    Aeroport aeroportProche = null;
                    float distanceAeroport = -1F;
                    foreach (Aeroport aeroportActuel in Aeroports)
                    {
                        if (aeroportActuel.AvionDisponible(incendie))
                        {
                            float distanceActuel = PointCartographique.DistanceEntre(aeroportActuel.PositionCarto, incendie.Position);
                            if (distanceAeroport == -1F)
                            {
                                distanceAeroport = distanceActuel;
                                aeroportProche = aeroportActuel;
                            }
                            else if (distanceActuel < distanceAeroport)
                            {
                                aeroportProche = aeroportActuel;
                                distanceAeroport = distanceActuel;
                            }
                        }
                    }
                    if (aeroportProche != null)
                    {
                        incendie.BesoinAvion = false;
                        aeroportProche.AffecterIncendie(incendie);
                        incendie.FeuEtein += SupprimerFeu;
                    }
                }
            }

            foreach (Secours secour in secours)
            {
                if (secour.EnAttente)
                {
                    Aeroport aeroportProche = null;
                    float distanceAeroport = -1F;
                    foreach (Aeroport aeroportActuel in Aeroports)
                    {
                        if (aeroportActuel.AvionDisponible(secour))
                        {
                            float distanceActuel = PointCartographique.DistanceEntre(aeroportActuel.PositionCarto, secour.Position);
                            if (distanceAeroport == -1F)
                            {
                                distanceAeroport = distanceActuel;
                                aeroportProche = aeroportActuel;
                            }
                            else if (distanceActuel < distanceAeroport)
                            {
                                aeroportProche = aeroportActuel;
                                distanceAeroport = distanceActuel;
                            }
                        }
                    }
                    if (aeroportProche != null)
                    {
                        secour.EnAttente = false;
                        aeroportProche.AffecterSecour(secour);
                        secour.secourFinit += SupprimerSecour;
                    }
                }

            }
            foreach (Observateur observateur in observateurs)
            {
                if (observateur.EnAttente)
                {
                    Aeroport aeroportProche = null;
                    float distanceAeroport = -1F;
                    foreach (Aeroport aeroportActuel in Aeroports)
                    {
                        if (aeroportActuel.AvionDisponible(observateur))
                        {
                            float distanceActuel = PointCartographique.DistanceEntre(aeroportActuel.PositionCarto, observateur.Position);
                            if (distanceAeroport == -1F)
                            {
                                distanceAeroport = distanceActuel;
                                aeroportProche = aeroportActuel;
                            }
                            else if (distanceActuel < distanceAeroport)
                            {
                                aeroportProche = aeroportActuel;
                                distanceAeroport = distanceActuel;
                            }
                        }
                    }
                    if (aeroportProche != null)
                    {
                        observateur.EnAttente = false;
                        aeroportProche.AffecterObservateur(observateur);
                            observateur.ObservationFinit += SupprimerObservateur;
                    }
                }

            }
        }
        private void GererAtterrissage(Aeronef aeronef, PointCartographique positionAeroport) 
        {
            foreach (Aeroport ap in Aeroports)
            {
                if (ap.PositionCarto == positionAeroport)
                {
                    ap.AjouterAeronef(aeronef);
                    aeronef.Atterrissage -= GererAtterrissage;
                    aeronefsEnVol.Remove(aeronef);
                }
            }
        }
        private void SupprimerObservateur(Observateur observateur)
        {
            observateurs.Remove(observateur);
            EvenementTermine.Invoke();
        }
        private void SupprimerSecour(Secours secour)
        {
            secours.Remove(secour);
            EvenementTermine.Invoke();
        }

        private void SupprimerFeu(Incendie incendie)
        {
            incendies.Remove(incendie);
            EvenementTermine.Invoke();
        }

        public List<string> AvoirInfoClientAeroport(int index)
        {
            return Aeroports[index].AvoirClientInfo();
        }

        public List<string> AvoirAeronefAeroport(int index)
        {
            return Aeroports[index].AvoirAeronefInfo();
        }
        public List<string> AvoirClient()
        {
            List<string> clients = new List<string>();

            foreach (Incendie incendie in incendies)
                clients.Add(incendie.ToString());

            foreach (Secours secours in secours)
                clients.Add(secours.ToString());

            foreach (Observateur observation in observateurs)
                clients.Add(observation.ToString());

            return clients;
        }

        public void Init()
        {
            foreach (Aeroport aeroport in Aeroports)
            {
                aeroport.DecollageEnCours += GererDecollage;
            }
        }
    }
}
