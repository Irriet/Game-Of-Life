using System;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Game_Of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            int gridHeight = 10;
            int gridWidth = 10;

            Cell[,] startingGrid = new Cell[gridHeight, gridWidth];
            FillStartingGrid(startingGrid);

            foreach (var cell in startingGrid)
            {
                if (cell.isAlive)
                    Console.Write("o");
                else
                    Console.Write(".");
            }



            Console.WriteLine();


        }

        public static Cell CreateRandomCell(int positionX, int positionY)
        {
            bool isItAlive;
            Random aliveness = new Random();
            int aliveCode = aliveness.Next(0, 2);

            if (aliveCode == 0)
                isItAlive = false;
            else
                isItAlive = true;
            Cell cell = new Cell(isItAlive, positionX, positionY);
            return cell;
        }

        public static void FillStartingGrid(Cell[,] array)
        {
            int i;
            int j;
            for (i = 0; i < array.GetLength(0); i++)
            {
                for (j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = CreateRandomCell(i, j);
                }
            }
            //return array;
        }
    }
}
