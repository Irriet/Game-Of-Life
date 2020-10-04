﻿using System;
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
            GameRunner gameRunner = new GameRunner();
            gameRunner.Run();
        }

       
    }
}
