using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace TP2_Simulateur.Models
{
    public class PointCartographique
    {
        /// <summary>
        /// Génère des nombres aléatoires
        /// </summary>
        private static readonly Random random = new Random();
        private static readonly object locker = new object();
        /// <summary>
        /// Latitude cartographique
        /// </summary>
        private float latitude;
        /// <summary>
        /// Longitude cartographique
        /// </summary>
        private float longitude;
        /// <summary>
        /// Latitude cartographique
        /// </summary>
        public float Latitude 
        {
            get 
            {
                return latitude; 
            }
            set
            {
                latitude = value;
            }
        }
        /// <summary>
        /// Longitude cartographique
        /// </summary>
        public float Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude = value;
            }
        }
        /// <summary>
        /// Retourne un point cartographique selon les coordonnées en paramètre 
        /// </summary>
        /// <param name="coord">Coordonnées</param>
        public PointCartographique(string coord) {
            MatchCollection match = Regex.Matches(coord, @"\d+° \d+' (N|S|E|O)");
            string latitudeString = match[0].Value;
            string longitudeString = match[1].Value;

            latitude = CoordVersFloat(latitudeString);
            longitude = CoordVersFloat(longitudeString);
        }
        /// <summary>
        /// Retourne un point cartographique à partir de la latitude et longitude recu
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        public PointCartographique(float lat, float lng) {
            latitude = lat;
            longitude = lng;
        }
        public PointCartographique()
        {

        }
        /// <summary>
        /// Retourne une coordonnée convertie en nombre
        /// </summary>
        /// <param name="coord"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Retourne les coordonnées sous forme d'une chaîne de caratères
        /// </summary>
        /// <returns></returns>
       override public string ToString() {
            return PointCartographique.StringFromLatLong(latitude, longitude);
        }
        /// <summary>
        /// Retourne un point indiquant la possition à l'écran du point cartographique
        /// </summary>
        /// <returns></returns>
        public PointF Transposer(SizeF tailleImage) {

            float y = (float) Math.Round(((-1 * latitude) + 90) * (tailleImage.Height / 180));
            float x= (float) Math.Round((longitude + 180) * (tailleImage.Width / 360));

            return new PointF(x, y);
        }
        /// <summary>
        /// Génère une position cartographique aléatoire
        /// </summary>
        /// <returns></returns>
        public static PointCartographique Random() {
            lock (locker) 
            {
                float lat = (float)random.NextDouble() * (90 - -90) + -90;
                float lng = (float)random.NextDouble() * (180 - -180) + -180;
                return new PointCartographique(lat, lng);
            }
        }
        /// <summary>
        /// Retourne les coordonnées sous forme d'une chaîne de caratères
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Transforme une valeur en radian
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
        private static float VersRadian(float valeur) 
        {
            return (float)(valeur / (180 / Math.PI));
        }
        /// <summary>
        /// Retourne la distance, en kilomètre, entre deux points cartographiques
        /// </summary>
        /// <param name="p1">Premier point</param>
        /// <param name="p2">Second point</param>
        /// <returns></returns>
        public static float DistanceEntre(PointCartographique p1, PointCartographique p2)
        {
            float lat1 = PointCartographique.VersRadian(p1.latitude);
            float lng1 = PointCartographique.VersRadian(p1.longitude);
            float lat2 = PointCartographique.VersRadian(p2.latitude);
            float lng2 = PointCartographique.VersRadian(p2.longitude);

            float distanceKm = (float)(1.609344 * (3963.0 * Math.Acos(Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(lng2 - lng1))));
            return distanceKm;
        }
    }
}
