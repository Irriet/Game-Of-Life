using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Game_Of_Life.Data;

namespace Game_Of_Life
{
    class GameRunner
    {
        readonly GridService gridService = new GridService();
        readonly FileService fileService = new FileService();
        readonly WritingService writingService = new WritingService();

        public Data.Grid CreateGame()
        {
            int gridWidth = writingService.GetWidth();
            int gridHeight = writingService.GetHeight();
            return gridService.CreateGrid(gridHeight, gridWidth);
        }
        public void RunGame(Data.Grid currentGrid)
        {
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
            fileService.PostGameSaving(currentGrid);
        }
    }
}
