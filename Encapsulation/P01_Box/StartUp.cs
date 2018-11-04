﻿using System;

namespace P01_Box
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = new Box(lenght, width, height);

            Console.WriteLine($"Surface Area - {box.GetSurface():f2}");
            Console.WriteLine($"Lateral Surface Area - {box.GetLateralSurface():F2}");
            Console.WriteLine($"Volume - {box.GetVolume():f2}");


        }
    }
}
