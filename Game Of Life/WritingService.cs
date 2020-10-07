using Game_Of_Life.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Game_Of_Life
{
    class WritingService
    {
        public void DisplayGrid(Grid grid)
        {
            for (int i = 0; i < grid.gridHeight; i++)
            {
                for (int j = 0; j < grid.gridWidth; j++)
                {
                    if (grid.cellGrid[i, j].isAlive)
                    {
                        Console.Write("o");
                    }
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Grid number: {grid.numberOfIteration}. \nLive cells: {grid.numberOfLiveCells}.");
            Thread.Sleep(2000);
            Console.Clear();
        }

        public int GetWidth()
        {
            Console.WriteLine("Hello, this is the game of life. Please enter your field width: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public int GetHeight()
        {
            Console.WriteLine("Now enter your field height: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public void GameOver()
        {
            Console.WriteLine("All cells are dead, the game is over.");
        }
    }
}
