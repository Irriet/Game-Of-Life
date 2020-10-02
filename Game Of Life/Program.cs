using System;
using System.Threading;

namespace Game_Of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateStartingCells();
            //Thread.Sleep(1000);
            //Console.Clear();
            
           
            
            
        }
        static void GenerateStartingCells()
        {
            int gridWidth = 10;
            int gridHeight = 10;
            Random cellGenerator = new Random();
            int cell;

            for (int j = 0; j < gridHeight; j++)
            {
                Console.WriteLine();

                for (int i = 0; i < gridWidth; i++)
                {
                    cell = cellGenerator.Next(0, 2);
                    if (cell == 1)
                        Console.Write("o");
                    else
                        Console.Write(".");
                }
            }
        }
    }
}
