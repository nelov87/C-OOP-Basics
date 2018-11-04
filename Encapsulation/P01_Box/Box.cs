using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Box
{
    public class Box
    {
        private double Length;
        private double Width;
        private double Height;

        public Box(double lenght, double width, double height)
        {
            Length = lenght;
            Width = width;
            Height = height;
        }

        public double GetSurface()
        {
            double surface = (2 * (Length * Width)) + (2 * Length * Height) + (2 * Width * Height);
            return surface;
        }

        public double GetLateralSurface()
        {
            double leteralSurface = (2 * Length * Height) + (2 * Width * Height);
            return leteralSurface;
        }

        public double GetVolume()
        {
            double volume = Length * Width * Height;
            return volume;
        }





    }
}
