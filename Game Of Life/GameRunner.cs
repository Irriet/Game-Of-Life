using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Game_Of_Life
{
    class GameRunner
    {
        public void Run()
        {
            
            WritingService writingService = new WritingService();
            int menuChoice = writingService.StartingMenu();

            if (menuChoice == 1) //run game
            {
                RunTheGame();
            }
            else if (menuChoice == 2) //load save
            {

            }
            else if (menuChoice == 3) //exit
            {
                Environment.Exit(0);
            }
        }

        public void RunTheGame()
        {
            WritingService writingService = new WritingService();
            int gridWidth = writingService.GetWidth();
            int gridHeight = writingService.GetHeight();

            GridService gridService = new GridService();
            var currentGrid = gridService.CreateGrid(gridHeight, gridWidth);

            writingService.DisplayGrid(currentGrid);

            do
            {
                while (currentGrid.numberOfLiveCells > 0 && !Console.KeyAvailable)
                {
                    var nextGrid = gridService.CreateNextGenGrid(currentGrid);
                    writingService.DisplayGrid(nextGrid);
                    currentGrid = nextGrid;
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            string createSave = writingService.GameOver();
            if (createSave == "y" || createSave == "Y")
            {
                Environment.Exit(0);
            }
            else if (createSave == "n" || createSave == "N")
            {
                Environment.Exit(0);
            }


        }







    }
}
