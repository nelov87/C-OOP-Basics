using System;

namespace P02_BoxValidation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            

            try
            {
                Box box = new Box(lenght, width, height);
                Console.WriteLine($"Surface Area - {box.GetSurface():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.GetLateralSurface():F2}");
                Console.WriteLine($"Volume - {box.GetVolume():f2}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            
            
        }
    }
}
