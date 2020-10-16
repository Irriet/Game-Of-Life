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
            Thread.Sleep(500);
            Console.Clear();
        }
        //TO DO: limit input possibilities
        public int GetWidth()
        {
            Console.WriteLine("Please enter your field width: ");
            return Convert.ToInt32(Console.ReadLine());
        }
        //TO DO: limit input possibilities
        public int GetHeight()
        {
            Console.WriteLine("Now enter your field height: ");
            return Convert.ToInt32(Console.ReadLine());
        }
        //TO DO: limit input possibilities
        public string GameOver()
        {
            Console.WriteLine("The game is over. Do you wish to save? \nPress Y for yes, N for no, confirm with Enter.");
            return Console.ReadLine();
        }

        //TO DO: limit input possibilities
        public int StartingMenu()
        {
            Console.WriteLine("Hello, this is the game of life. Press a number and confirm with Enter to select one of the options below. \n1) Run the game \n2) Load a save \n3) Exit");
            return Convert.ToInt32(Console.ReadLine());
        }

        public void GameWasSaved()
        {
            Console.WriteLine("The game has been saved.\n");
        }

        //TO DO: limit input possibilities
        public string SelectGame(string[] savePaths)
        {
            Console.Clear();
            int i;
            int num;
            //display the saves:
            for (i = 0; i < savePaths.Length; i++)
            {
                string path = savePaths[i];
                Console.WriteLine($"{i}. {System.IO.Path.GetFileName(path)}");
            }

            //ask for input:
            Console.WriteLine("Enter a number of save file that you want to load: ");
            var choice = Console.ReadLine();
            while (!int.TryParse(choice, out num))
            {
                Console.WriteLine("Choice must be a number. Input a valid number.");
                choice = Console.ReadLine();
            }
            while (num >= i)
            {
                Console.WriteLine("There's no save with such a number. Input a valid number.");
                num = Convert.ToInt32(Console.ReadLine());
            }
            return savePaths[num];
        }

    }
}
