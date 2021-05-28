using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TP2Editeur
{
    public class PositionCartographique
    {
        private float longitude;
        private float latitude;
        public string Position 
        {
            get
            {
                return this.ToString();
            }
        }
        public PositionCartographique() { 
            
        }
        public PositionCartographique(float latitude, float longitude)
        {
            this.longitude = longitude;
            this.latitude = latitude;
        }
        public static string stringFromLatLong(float lat, float lng) 
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
        public static string stringFromPixel(int x, int y, SizeF tailleCarte) {
            
            float lat = (y / (tailleCarte.Height / 180) - 90) / -1;
            float lng = x / (tailleCarte.Width / 360) - 180;

            return PositionCartographique.stringFromLatLong(lat,lng);
        }
        public override string ToString()
        {
            return PositionCartographique.stringFromLatLong(this.latitude, this.longitude);
        }
    }
}
