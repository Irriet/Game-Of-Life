using System;
using System.Collections.Generic;
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

        private Cell CreateRandomCell(int positionX, int positionY)
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
    }
}
