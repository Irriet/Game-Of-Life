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
            int gridHeight = 10;
            int gridWidth = 20;
            bool areCellsAlive = true;

            GridService gridService = new GridService();
            var currentGrid = gridService.CreateGrid(gridHeight, gridWidth);

            WritingService writingService = new WritingService();
            writingService.DisplayCells(currentGrid);

            while (areCellsAlive)
                {
                    var nextGrid = gridService.CreateNextGenGrid(currentGrid);
                    writingService.DisplayCells(nextGrid);
                    currentGrid = nextGrid;
                }
        }








    }
}
