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
            Thread.Sleep(100);
            Console.Clear();
        }
        //TO DO: limit input possibilities
        public int GetWidth()
        {
            Console.WriteLine("Please enter your field width (5-500): ");
            var width = Console.ReadLine();
            int widthInt;
            while (!int.TryParse(width, out widthInt) || widthInt > 500 || widthInt < 5 || string.IsNullOrEmpty(width))
            {
                Console.WriteLine("Height must be a number between 5 and 500.");
                width = Console.ReadLine();
            }
            return Convert.ToInt32(widthInt);
        }
        //TO DO: limit input possibilities
        public int GetHeight()
        {
            Console.WriteLine("Now enter your field height (5-500): ");
            var height = Console.ReadLine();
            int heightInt;
            while (!int.TryParse(height, out heightInt) || heightInt > 500 || heightInt < 5 || string.IsNullOrEmpty(height))
            {
                Console.WriteLine("Height must be a number between 5 and 500.");
                height = Console.ReadLine();
            }

            return heightInt;
        }

        public string GameOver()
        {
            Console.WriteLine("The game is over. Do you wish to save? \nPress Y for yes, N for no, confirm with Enter.");
            var input = Console.ReadLine();
            while (input != "n" && input != "N" && input != "y" && input != "Y")
            {
                Console.WriteLine("Invalid input. Input either Y or N.");
                input = Console.ReadLine();
            }
            return input;
        }

        public int StartingMenu()
        {
            Console.WriteLine("Hello, this is the game of life. Press a number and confirm with Enter to select one of the options below. \n1) Run the game \n2) Load a save \n3) Exit");
            var choice = Console.ReadLine();
            int num;

            while (!int.TryParse(choice, out num) || num > 3)
            {
                Console.WriteLine("Choice must be a number and must be within the options range. Input a valid number.");
                choice = Console.ReadLine();
            }
            return num;
        }

        public void GameWasSaved()
        {
            Console.WriteLine("The game has been saved.\n");
        }

        public void GameNotSaved()
        {
            Console.WriteLine("The game wasn't saved.\n");
        }

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
            while (!int.TryParse(choice, out num) || num >= i)
            {
                Console.WriteLine("Choice must be a number and must be within the options range. Input a valid number.");
                choice = Console.ReadLine();
            }
            return savePaths[num];
        }
    }
}
