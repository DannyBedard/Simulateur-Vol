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
        //public List<PointF[]> AvoirPointsTrajectoireAeronef() 
        //{
        //    List<PointF[]> pointsTrajectoires = new List<PointF[]>();
        //    foreach (Aeronef aeronef in aeronefsEnVol)
        //    {
                
        //    }
        //}
        public List<string> AvoirToutAeroportsNom()
        {
            List<string> aeroportsNom = new List<string>();
            foreach (Aeroport ap in Aeroports)
            {
                aeroportsNom.Add(ap.Nom);
            }
            return aeroportsNom;
        }
    }
}
