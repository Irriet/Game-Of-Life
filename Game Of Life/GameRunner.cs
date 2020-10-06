﻿using System;
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
            writingService.AskForWidth();
            int gridHeight = Convert.ToInt32(Console.ReadLine());
            writingService.AskForHeight();
            int gridWidth = Convert.ToInt32(Console.ReadLine());

            bool areCellsAlive = true;

            GridService gridService = new GridService();
            var currentGrid = gridService.CreateGrid(gridHeight, gridWidth);

            
            writingService.DisplayCells(currentGrid);

            while (areCellsAlive)
            {
                var nextGrid = gridService.CreateNextGenGrid(currentGrid);
                writingService.DisplayCells(nextGrid);
                currentGrid = nextGrid;

                for (int i = 0; i < nextGrid.GetLength(0); i++)
                {
                    for (int j = 0; j < nextGrid.GetLength(1); j++)
                    {
                        if (nextGrid[i, j].isAlive)
                            break;
                        else
                            areCellsAlive = false;
                    }
                }
            }
            writingService.GameOver(areCellsAlive);
        }








    }
}
