using Game_Of_Life.Data;
using System;
using System.Collections.Generic;
using System.Text;


namespace Game_Of_Life
{
    class Menu
    {
        WritingService writingService = new WritingService();
        FileService fileService = new FileService();
        GameRunner gameRunner = new GameRunner();
        public void Run()
        {
            int menuChoice = writingService.StartingMenu();

            if (menuChoice == 1) //run game
            {
                var currentGrid = gameRunner.CreateGame();
                gameRunner.RunGame(currentGrid);
            }
            else if (menuChoice == 2)
            {
                var filePaths = fileService.GetFilePaths(); //returns a list of files
                var filePath = writingService.SelectGame(filePaths);
                Grid grid = fileService.LoadGrid(filePath);
                gameRunner.RunGame(grid);
            }
            else if (menuChoice == 3) //exit
            {
                Environment.Exit(0);
            }
        }
    }
}
