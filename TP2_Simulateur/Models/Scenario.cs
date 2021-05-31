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

        internal List<Tuple<PointF[], Color>> AvoirTrajetsAeronefEnVol()
        {
            List<Tuple<PointF[], Color>> trajets = new List<Tuple<PointF[], Color>>();
            foreach (Aeronef aeronef in aeronefsEnVol)
            {
                
                if (aeronef.EstEnVol())
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
            }
            return trajets;
        }

        public void MettreAJour(double vitesseHorloge)
        {
            foreach (Aeronef aeronef in aeronefsEnVol)
            {
                if (aeronef.EstEnVol())
                {
                    aeronef.Avancer(vitesseHorloge);
                }
                else
                    aeronef.Action();
            }
        }

        public void GenererClient()
        {
            FabriqueClient.GenererIncendies(incendies);
            FabriqueClient.GenererSecours(secours);
            FabriqueClient.GenererObservateurs(observateurs);
            FabriqueClient.GenererClientAeroport(Aeroports);

            GererEvenement();

        }
        public void GereAeronefArrive() 
        {
            //Gerer les aeronefs qui sont arrivés
        }
        public void GererDecollage(Aeronef aeronef, Aeroport depart) 
        {
            aeronefsEnVol.Add(aeronef);
            depart.RetirerAeronef(aeronef);
            Trajectoire trajectoire = new Trajectoire(depart.PositionCarto, aeronef.Destination); // Trouver dans quel classe mettre cette trajectoire.
            
            aeronef.DefinirTrajectoire(trajectoire);
        }
        public List<PointF> AvoirPointsAeronef()
        {
            List<PointF> points = new List<PointF>();
            foreach (Aeronef aeronef in aeronefsEnVol)
            {
                aeronef.Action();
                points.Add(aeronef.Position.Transposer(TailleImage));
            }
            return points;
        }
        public void GererEvenement()
        {
            foreach (Incendie incendie in incendies)
            {
                if (incendie.BesoinAvion)
                {
                    Aeroport aeroportProche = null;
                    float distanceAeroport = 0;
                    foreach (Aeroport aeroportActuel in Aeroports)
                    {
                        if (aeroportActuel.AvionDisponible(incendie))
                        {
                            float distanceActuel = PointCartographique.DistanceEntre(aeroportActuel.PositionCarto, incendie.Position);
                            if (distanceActuel > distanceAeroport)
                            {
                                aeroportProche = aeroportActuel;
                                distanceAeroport = distanceActuel;
                            }
                        }
                    }
                    if (aeroportProche != null)
                    {
                        aeroportProche.AffecterIncendie(incendie);

                    }
                }
            }
        }

        internal List<string> AvoirInfoClientAeroport(int index)
        {
            return Aeroports[index].AvoirClientInfo();
        }

        public List<string> AvoirAeronefAeroport(int index)
        {
            return Aeroports[index].AvoirAeronefInfo();
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
