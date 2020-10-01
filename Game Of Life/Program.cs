﻿using System;

namespace Game_Of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            //Making the grid
            int gridWidth = 40;
            int gridHeight = 20;
            Random cellGenerator = new Random();
            int cell;

            for (int j = 0; j < gridHeight; j++)
            {
                Console.WriteLine();

                for (int i = 0; i < gridWidth; i++)
                {
                    cell = cellGenerator.Next(0, 2);
                    if (cell == 1)
                        Console.Write(".");
                    else
                        Console.Write("o");
                }
            }
        }
    }
}
