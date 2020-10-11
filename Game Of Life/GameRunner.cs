using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Game_Of_Life
{
    class GameRunner
    {
        Saves saves = new Saves();
        WritingService writingService = new WritingService();
        public void Run()
        {
            
            int menuChoice = writingService.StartingMenu();

            if (menuChoice == 1) //run game
            {
                RunGame();
            }
            else if (menuChoice == 2) //load save
            {
                saves.RunSave();
            }
            else if (menuChoice == 3) //exit
            {
                Environment.Exit(0);
            }
        }
        public void RunGame()
        {
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
            saves.PostGameSaving(currentGrid);
            Run();



            
        }






    }
}
