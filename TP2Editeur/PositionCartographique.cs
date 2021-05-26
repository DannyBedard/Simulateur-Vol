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
            int lattitude = positionX / 55;
            int longitude =  positionY / 55;
            int minuteX = positionX % 55;
            int minuteY = positionY % 55;

            return "X : " + positionX.ToString() + " Y : " + positionY.ToString();
        }
    }
}
