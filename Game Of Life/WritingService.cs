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
            Console.WriteLine($"\nGrid number: {grid.numberOfIteration}. \nLive cells: {grid.numberOfLiveCells}. \n\nPress ESC to stop.");
            Thread.Sleep(2000);
            Console.Clear();
        }

        public int GetWidth()
        {
            Console.WriteLine("Please enter your field width: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public int GetHeight()
        {
            Console.WriteLine("Now enter your field height: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public string GameOver()
        {
            Console.WriteLine("The game is over. Do you wish to save? \nPress Y for yes, N for no, confirm with Enter.");
            return Console.ReadLine();
        }

        public int StartingMenu()
        {
            Console.WriteLine("Hello, this is the game of life. Press a number and confirm with Enter to select one of the options below. \n1) Run the game \n2) Load a save \n3) Exit");
            return Convert.ToInt32(Console.ReadLine());
        }

        public void GameWasSaved()
        {
            Console.WriteLine("The game has been saved.\n");
        }
    }
}
