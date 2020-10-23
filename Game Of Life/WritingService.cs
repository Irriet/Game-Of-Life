using Game_Of_Life.Data;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Game_Of_Life
{
    class WritingService
    {
        private readonly int minGridSize = 5;
        private readonly int maxGridSize = 50;
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

        public int GetWidth()
        {
            Console.WriteLine($"Please enter your field width ({minGridSize}-{maxGridSize}): ");
            var width = Console.ReadLine();
            int widthInt;
            while (!int.TryParse(width, out widthInt) || widthInt > maxGridSize || widthInt < minGridSize || string.IsNullOrEmpty(width))
            {
                Console.WriteLine($"Width must be a number between {minGridSize} and {maxGridSize}.");
                width = Console.ReadLine();
            }
            return widthInt;
        }

        public int GetHeight()
        {
            Console.WriteLine($"Now enter your field height ({minGridSize}-{maxGridSize}): ");
            var height = Console.ReadLine();
            int heightInt;
            while (!int.TryParse(height, out heightInt) || heightInt > maxGridSize || heightInt < minGridSize || string.IsNullOrEmpty(height))
            {
                Console.WriteLine($"Height must be a number between {minGridSize} and {maxGridSize}.");
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
