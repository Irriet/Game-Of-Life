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
        readonly CellService cellService = new CellService();

        public Grid CreateGrid(int gridHeight, int gridWidth)
        {
            Grid grid = new Grid(gridHeight, gridWidth);
            for (int i = 0; i < grid.gridHeight; i++)
            {
                for (int j = 0; j < grid.gridWidth; j++)
                {
                    grid.cellGrid[i, j] = cellService.CreateRandomCell(i, j);
                    if (grid.cellGrid[i, j].isAlive)
                        grid.numberOfLiveCells++;
                }
            }
            return grid;
        }
               
        public Grid CreateNextGenGrid(Grid previousGrid)
        {
            Grid grid = previousGrid;
            grid.numberOfLiveCells = 0;
            for (int i = 0; i < grid.gridHeight; i++)
            {
                for (int j = 0; j < grid.gridWidth; j++)
                {
                    grid.cellGrid[i, j] = cellService.CreateNextGenCell(previousGrid.cellGrid, i, j);
                    if (grid.cellGrid[i, j].isAlive)
                    grid.numberOfLiveCells++;
                }
            }
            grid.numberOfIteration++;
            return grid;
        }
    }
}
