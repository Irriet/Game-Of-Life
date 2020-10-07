using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Of_Life.Data
{
    class Grid
    {
        public int gridHeight;
        public int gridWidth;
        public int numberOfIteration = 0;
        public int numberOfLiveCells = 0;
        public Cell[,] cellGrid;

        public Grid(int aGridHeight, int aGridWidth)
        {
            gridHeight = aGridHeight;
            gridWidth = aGridWidth;
            cellGrid = new Cell[gridHeight, gridWidth];
        }
    }
}
