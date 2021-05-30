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
            Trajectoire trajectoire = new Trajectoire(depart.PositionCarto.Transposer(TailleImage), aeronef.Destination.Transposer(TailleImage)); // Trouver dans quel classe mettre cette trajectoire.
            aeronefsEnVol.Add(aeronef);
            //
        }
        public IEnumerable<PointF> AvoirPointsAeronef()
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
                GererAeroportProche(incendie);

            foreach (Secours secours in secours)
                GererAeroportProche(secours);

            foreach (Observateur observateur in observateurs)
                GererAeroportProche(observateur);

            
        }

        private void GererAeroportProche(Client client)
        {
            Aeroport aeroportProche = null;
            float distanceAeroport = 0;
            foreach (Aeroport aeroportActuel in Aeroports)
            {
                if (aeroportActuel.AvionDisponible(client))
                {
                    float distanceActuel = PointCartographique.DistanceEntre(aeroportActuel.PositionCarto, client.Position);
                    if (distanceActuel > distanceAeroport)
                    {
                        aeroportProche = aeroportActuel;
                        distanceAeroport = distanceActuel;
                    }
                }
            }
            if (aeroportProche != null)
            {
                aeroportProche.AffecterClient(client);
            }
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
