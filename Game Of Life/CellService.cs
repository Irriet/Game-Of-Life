using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Of_Life
{
    class CellService
    {
        public Cell CreateRandomCell(int positionX, int positionY)
        {
            bool isItAlive;
            Random aliveness = new Random();
            int aliveCode = aliveness.Next(0, 2);

            if (aliveCode == 0)
                isItAlive = false;
            else
                isItAlive = true;
            Cell cell = new Cell(isItAlive, positionX, positionY);
            return cell;
        }
        public Cell CreateNextGenCell(Cell[,] previousGrid, int positionX, int positionY)
        {
            bool isItAlive;
            int aliveNeighbours = AliveNeighbours(previousGrid, positionX, positionY);

            if (previousGrid[positionX, positionY].isAlive)
            {
                if (aliveNeighbours < 2)
                    isItAlive = false;
                else if (aliveNeighbours > 3)
                    isItAlive = false;
                else
                    isItAlive = true;
            }
            else
            {
                if (aliveNeighbours == 3)
                    isItAlive = true;
                else
                    isItAlive = false;
            }
            Cell cell = new Cell(isItAlive, positionX, positionY);
            return cell;
        }
        private int AliveNeighbours(Cell[,] previousGrid, int positionX, int positionY)
        {
            int counter = 0;
            if ((positionX - 1) >= 0 && (positionY - 1) >= 0 && (positionX - 1) < previousGrid.GetLength(0) && (positionY - 1) < previousGrid.GetLength(1))
            {
                if (previousGrid[(positionX - 1), (positionY - 1)].isAlive)
                {
                    counter++;
                }
            }

            if ((positionX - 1) >= 0 && (positionY) >= 0 && (positionX - 1) < previousGrid.GetLength(0) && (positionY) < previousGrid.GetLength(1))
            {
                if (previousGrid[(positionX - 1), (positionY)].isAlive)
                {
                    counter++;
                }
            }

            if ((positionX - 1) >= 0 && (positionY + 1) >= 0 && (positionX - 1) < previousGrid.GetLength(0) && (positionY + 1) < previousGrid.GetLength(1))
            {
                if (previousGrid[(positionX - 1), (positionY + 1)].isAlive)
                {
                    counter++;
                }
            }

            if ((positionX) >= 0 && (positionY - 1) >= 0 && (positionX) < previousGrid.GetLength(0) && (positionY - 1) < previousGrid.GetLength(1))
            {
                if (previousGrid[(positionX), (positionY - 1)].isAlive)
                {
                    counter++;
                }
            }

            if ((positionX) >= 0 && (positionY + 1) >= 0 && (positionX) < previousGrid.GetLength(0) && (positionY + 1) < previousGrid.GetLength(1))
            {
                if (previousGrid[(positionX), (positionY + 1)].isAlive)
                {
                    counter++;
                }
            }

            if ((positionX + 1) >= 0 && (positionY - 1) >= 0 && (positionX + 1) < previousGrid.GetLength(0) && (positionY - 1) < previousGrid.GetLength(1))
            {
                if (previousGrid[(positionX + 1), (positionY - 1)].isAlive)
                {
                    counter++;
                }
            }

            if ((positionX + 1) >= 0 && (positionY) >= 0 && (positionX + 1) < previousGrid.GetLength(0) && (positionY) < previousGrid.GetLength(1))
            {
                if (previousGrid[(positionX + 1), (positionY)].isAlive)
                {
                    counter++;
                }
            }

            if ((positionX + 1) >= 0 && (positionY + 1) >= 0 && (positionX + 1) < previousGrid.GetLength(0) && (positionY + 1) < previousGrid.GetLength(1))
            {
                if (previousGrid[(positionX + 1), (positionY + 1)].isAlive)
                {
                    counter++;
                }
            }

            return counter;
        }

    }
}
