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
        List<Client> clients = new List<Client>();
        FabriqueClient fabriqueClient = new FabriqueClient();
        public List<Aeroport> Aeroports;
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
        public List<PointF> AvoirPointsClient()
        {
            List<PointF> points = new List<PointF>();
            foreach (Client client in clients)
            {
                //TODO Regler erreur d'initialisation de la position
                //points.Add(client.Position.Transposer(TailleImage));
            }
            return points;
        }

        public List<string> AvoirToutAeroportsNom()
        {
            List<string> aeroportsNom = new List<string>();
            foreach (Aeroport ap in Aeroports)
            {
                aeroportsNom.Add(ap.Nom);
            }
            return aeroportsNom;
        }

        public void GenererClient()
        {
            fabriqueClient.GenererClient(clients, Aeroports);
        }
    }
}
