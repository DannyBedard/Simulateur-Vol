using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace TP2_Simulateur.Models
{
    class PointCartographique
    {
        private float latitude;
        private float longitude;
        public PointCartographique(string coord) {
            MatchCollection match = Regex.Matches(coord, @"\d+° \d+' (N|O|E|W)");
            string latitudeString = match[0].Value;
            string longitudeString = match[1].Value;

            latitude = coordVersFloat(latitudeString);
            longitude = coordVersFloat(longitudeString);
        }
        private float coordVersFloat(string coord) {
            float resultat = 0;
            MatchCollection coordParts = Regex.Matches(coord, @"\d+");
            int degree = int.Parse(coordParts[0].Value);
            int minute = int.Parse(coordParts[1].Value);
            char direction = coord[coord.Length - 1];
            resultat = float.Parse(degree.ToString() + "," + ((float)minute / 60).ToString().Split(',')[1]);
            if (char.ToUpper(direction) == 'S' || char.ToUpper(direction) == 'W')
                resultat = resultat * -1;
            return resultat;
        }
        private double bound(double val, double min, double max)
        {
            double res;
            res = Math.Max(val, min);
            res = Math.Min(res, max);
            return res;
        }
        private double degreesToRadians(double deg)
        {
            return deg * (Math.PI / 180);
        }
        public string toString() {
            // TODO : transformer la latitude et longitude en string degree/minute
            return null;
        }
        public PointF Transposer(SizeF tailleImage) {
            double mapWidth = tailleImage.Width; // largeur
            double mapHeight = tailleImage.Height; // hauteur
            double scaleMapX = mapWidth / 360.0; // Degrés par pixel (X)
            double scaleMapY = mapHeight / (Math.PI * 2); // Degrés par pixel (Y)
            double centerX = mapWidth / 2 - 1; // Centre de la map (X)
            double centerY = mapHeight / 2 - 1;// Centre de la map (Y)
            // X
            double x = centerX + longitude * scaleMapX;
            // degrees -> radians
            double latRad = degreesToRadians(latitude);
            // Y
            double siny = bound(Math.Sin(degreesToRadians(latitude)), -0.9999, 0.9999);
            double y = centerY + 0.65 * Math.Log((1 + siny) / (1 - siny)) * -scaleMapY;
            return new PointF((float)x, (float)y);
        }
    }
}
