using Game_Of_Life.Data;
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
        public Grid CreateGrid(int gridHeight, int gridWidth)
        {
            Grid grid = new Grid(gridHeight, gridWidth);
            for (int i = 0; i < grid.gridHeight; i++)
            {
                for (int j = 0; j < grid.gridWidth; j++)
                {
                    grid.cellGrid[i, j] = CreateRandomCell(i, j);
                    if (grid.cellGrid[i, j].isAlive)
                        grid.numberOfLiveCells++;
                }
            }
            return grid;
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

        public Grid CreateNextGenGrid(Grid previousGrid)
        {
            Grid grid = previousGrid;
            grid.numberOfLiveCells = 0;
            for (int i = 0; i < grid.gridHeight; i++)
            {
                for (int j = 0; j < grid.gridWidth; j++)
                {
                    grid.cellGrid[i, j] = CreateNextGenCell(previousGrid.cellGrid, i, j);
                    if (grid.cellGrid[i, j].isAlive)
                    grid.numberOfLiveCells++;
                }
            }
            grid.numberOfIteration++;
            return grid;
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
