using System;
using System.Collections.Generic;
using System.Text;

namespace TP2Editeur
{
    public class PositionCartographique
    {
        private int positionX;
        private int positionY;

        public PositionCartographique(int positionX, int positionY)
        {
            this.positionX = positionX;
            this.positionY = positionY;
        }
        public override string ToString()
        {
            char equateur;
            char greenwich;
            int longitude = (positionX / 55) + 1;
            int lattitude =  (positionY / 55) + 1;
            int minuteX;
            int minuteY;

            if (lattitude >= 7)
            {
                equateur = 'S';
                lattitude = 15 * (lattitude - 7);
                minuteY = positionY % 55;
            }
            else
            {
                equateur = 'N';
                lattitude = 15 * (6 - lattitude);
                minuteY = 55 - (positionX % 55);
            }


            if (longitude >= 13)
            {
                greenwich = 'E';
                longitude = 15 * (longitude - 13);
                minuteX = positionX % 55;

            }
            else
            {
                greenwich = 'O';
                longitude = 15 * (12 - longitude);
                minuteX = 55 - (positionX % 55);
            }

            return lattitude.ToString() + "'" + minuteY + "\"" + equateur + ", " + longitude.ToString() + "'" + minuteX +  "\"" + greenwich;
        }
    }
}
