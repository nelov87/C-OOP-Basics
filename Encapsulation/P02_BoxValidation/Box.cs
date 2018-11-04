using System;
using System.Collections.Generic;
using System.Text;

namespace P02_BoxValidation
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        private double Length
        {
            
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                else
                {
                    this.length = value;
                }
            }
        }

        private double Width
        {
            
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                else
                {
                    this.width = value;
                }
            }
        }

        private double Height
        {
            
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                else
                {
                    this.height = value;
                }
            }
        }

        public Box()
        {

        }

        public Box(double lenght, double width, double height)
        {
            Length = lenght;
            Width = width;
            Height = height;
        }

        public double GetSurface()
        {
            double surface = (2 * (length * width)) + (2 * length * height) + (2 * width * height);
            return surface;
        }

        public double GetLateralSurface()
        {
            double leteralSurface = (2 * length * height) + (2 * width * height);
            return leteralSurface;
        }

        public double GetVolume()
        {
            double volume = length * width * height;
            return volume;
        }





    }
}
