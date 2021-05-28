using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace TP2_Simulateur.Models
{
    public class PointCartographique
    {
        private float latitude;
        private float longitude;
        public PointCartographique(string coord) {
            MatchCollection match = Regex.Matches(coord, @"\d+° \d+' (N|S|E|O)");
            string latitudeString = match[0].Value;
            string longitudeString = match[1].Value;

            latitude = CoordVersFloat(latitudeString);
            longitude = CoordVersFloat(longitudeString);
        }
        public PointCartographique()
        {

        }
        private float CoordVersFloat(string coord) {
            float resultat = 0;
            MatchCollection coordParts = Regex.Matches(coord, @"\d+");
            int degree = int.Parse(coordParts[0].Value);
            int minute = int.Parse(coordParts[1].Value);
            char direction = coord[coord.Length - 1];
            resultat = float.Parse(degree.ToString() + "," + ((float)minute / 60).ToString().Split(',')[1]);
            if (char.ToUpper(direction) == 'S' || char.ToUpper(direction) == 'O')
                resultat = resultat * -1;
            return resultat;
        }
       override public string ToString() {
            return PointCartographique.StringFromLatLong(latitude, longitude);
        }
        public PointF Transposer(SizeF tailleImage) {
           // double mapWidth = tailleImage.Width; // largeur
           // double mapHeight = tailleImage.Height; // hauteur
           // double scaleMapX = mapWidth / 360.0; // Degrés par pixel (X)
           // double scaleMapY = mapHeight / (Math.PI * 2); // Degrés par pixel (Y)
            //double centerX = mapWidth / 2 - 1; // Centre de la map (X)
            //double centerY = mapHeight / 2 - 1;// Centre de la map (Y)
            // X
            //double x = centerX + longitude * scaleMapX;
            // degrees -> radians
            //double latRad = degreesToRadians(latitude);
            // Y


            float y = (float) Math.Round(((-1 * latitude) + 90) * (tailleImage.Height / 180));
            float x= (float) Math.Round((longitude + 180) * (tailleImage.Width / 360));

            //double siny = bound(Math.Sin(degreesToRadians(latitude)), -0.9999, 0.9999);
            //double y = centerY + 0.65 * Math.Log((1 + siny) / (1 - siny)) * -scaleMapY;
            return new PointF(x, y);
        }
        public static string StringFromLatLong(float lat, float lng)
        {
            string[] latParts = lat.ToString().Split(',');
            string[] lngParts = lng.ToString().Split(',');

            int latDegree = int.Parse(latParts[0]);
            int latMinute = (int)(char.GetNumericValue(latParts[0][0]) * 6);
            int lngDegree = int.Parse(lngParts[0]);
            int lngMinute = (int)(char.GetNumericValue(lngParts[0][0]) * 6);

            lngDegree = lngDegree < 0 ? lngDegree * -1 : lngDegree;
            lngMinute = lngMinute < 0 ? lngMinute * -1 : lngMinute;
            latMinute = latMinute < 0 ? latMinute * -1 : latMinute;
            latDegree = latDegree < 0 ? latDegree * -1 : latDegree;

            char directionLat = lat > 0 ? 'N' : 'S';
            char directionLng = lng > 0 ? 'E' : 'O';

            string strLat = latDegree.ToString() + "° " + latMinute.ToString() + "' " + directionLat;
            string strLng = lngDegree.ToString() + "° " + lngMinute.ToString() + "' " + directionLng;
            string coord = strLat + ", " + strLng;

            return coord;
        }
    }
}
