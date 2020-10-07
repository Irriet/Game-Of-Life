using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Game_Of_Life
{
    class WritingService
    {
        public int numberOfIterations = 0;
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
            numberOfIterations++;
            Console.WriteLine($"Grid number: {numberOfIterations}.");
            Thread.Sleep(2000);
            Console.Clear();
        }

        public void AskForWidth()
        {
            Console.WriteLine("Hello, this is the game of life. Please enter your field width: ");
        }

        public void AskForHeight()
        {
            Console.WriteLine("Now enter your field height: ");
        }

        public void GameOver(bool areCellsAlive)
        {
            if (areCellsAlive == false)
                Console.WriteLine("All cells are dead, the game is over.");
        }
    }
}
