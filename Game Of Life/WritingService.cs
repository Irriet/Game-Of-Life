using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Game_Of_Life
{
    class WritingService
    {
        public void DisplayCells(Cell[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j].isAlive)
                        Console.Write("o");
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
            }
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
