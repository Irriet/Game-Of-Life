using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Of_Life
{
    class Cell
    {
        public bool isAlive;
        public int positionX;
        public int positionY;

        public Cell(bool aIsAlive, int aPositionX, int aPositionY) //this is a constructor
        {
            isAlive = aIsAlive;
            positionX = aPositionX;
            positionY = aPositionY;
        }
    }
}

