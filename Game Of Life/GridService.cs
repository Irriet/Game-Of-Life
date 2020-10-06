using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Game_Of_Life
{
    class GridService
    {
        public Cell[,] CreateGrid(int gridHeight, int gridWidth)
        {
            Cell[,] cellGrid = new Cell[gridHeight, gridWidth];
            FillStartingGrid(cellGrid);
            return cellGrid;
        }

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

        private void FillStartingGrid(Cell[,] array)
        {
            int i;
            int j;
            for (i = 0; i < array.GetLength(0); i++)
            {
                for (j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = CreateRandomCell(i, j);
                }
            }
        }

        public Cell[,] CreateNextGenGrid(Cell[,] previousGrid)
        {
            Cell[,] cellGrid = previousGrid;
         
            int i;
            int j;
            for (i = 0; i < cellGrid.GetLength(0); i++)
            {
                for (j = 0; j < cellGrid.GetLength(1); j++)
                {
                    cellGrid[i, j] = CreateNextGenCell(previousGrid, i, j);
                }
            }
            return cellGrid;
        }

        private Cell CreateNextGenCell(Cell[,] previousGrid, int positionX, int positionY)
        {
            bool isItAlive;
            int aliveNeighbours = AliveNeighbours(previousGrid, positionX, positionY);
           
            if (previousGrid[positionX, positionY].isAlive)
            {
                if (aliveNeighbours >= 2)
                    isItAlive = true;
                if (aliveNeighbours > 3)
                    isItAlive = false;
                else
                    isItAlive = false;
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
