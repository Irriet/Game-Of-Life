using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Of_Life
{
    class WritingService
    {
        public void DisplayCells(Cell[,] grid)
        {
            foreach (var cell in grid)
            {
                if (cell.isAlive)
                    Console.Write("o");
                else
                    Console.Write(".");
            }
        }
    }
}
