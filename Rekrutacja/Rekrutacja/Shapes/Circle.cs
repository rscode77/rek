using Rekrutacja.Interfaces;
using System;

namespace Rekrutacja.Shapes
{
    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}