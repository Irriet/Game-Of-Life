using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Of_Life
{
    class GameRunner
    {
        public void Run()
        {
            int gridHeight = 10;
            int gridWidth = 10;

            GridService gridService = new GridService();
            var startingGrid = gridService.CreateGrid(gridHeight, gridWidth);

            WritingService writingService = new WritingService();
            writingService.DisplayCells(startingGrid);
        }








    }
}
