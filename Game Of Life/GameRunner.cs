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
            int gridWidth = writingService.GetWidth();
            int gridHeight = writingService.GetHeight();

            GridService gridService = new GridService();
            var currentGrid = gridService.CreateGrid(gridHeight, gridWidth);

            writingService.DisplayGrid(currentGrid);

            while (currentGrid.numberOfLiveCells > 0)
            {
                var nextGrid = gridService.CreateNextGenGrid(currentGrid);
                writingService.DisplayGrid(nextGrid);
                currentGrid = nextGrid;
            }
            writingService.GameOver();
        }








    }
}
