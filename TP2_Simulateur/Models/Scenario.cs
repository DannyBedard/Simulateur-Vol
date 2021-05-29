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
        //List<Client> clients = new List<Client>();
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
                //TODO Regler erreur d'initialisation de la position
                points.Add(client.Position.Transposer(TailleImage));
            }
            return points;
        }

        internal IEnumerable<PointF> AvoirPointsSecours()
        {
            List<PointF> points = new List<PointF>();
            foreach (Client client in secours)
            {
                //TODO Regler erreur d'initialisation de la position
                points.Add(client.Position.Transposer(TailleImage));
            }
            return points;
        }

        internal IEnumerable<PointF> AvoirPointsObservateur()
        {
            List<PointF> points = new List<PointF>();
            foreach (Client client in observateurs)
            {
                //TODO Regler erreur d'initialisation de la position
                points.Add(client.Position.Transposer(TailleImage));
            }
            return points;
        }

        internal List<string> AvoirToutAeroportsNom()
        {
            List<string> points = new List<string>();
            foreach (Aeroport ap in Aeroports)
            {
                points.Add(ap.Nom);
            }
            return points;
        }

        internal void GenererClient()
        {
            FabriqueClient.GenererIncendies(incendies);
            FabriqueClient.GenererSecours(secours);
            FabriqueClient.GenererObservateurs(observateurs);
            FabriqueClient.GenererClientAeroport(Aeroports);
        }
    }
}
