using Rekrutacja.Interfaces;

namespace Rekrutacja.Shapes
{
    public class Triangle : IShape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public Triangle(double triangleBase, double height)
        {
            Base = triangleBase;
            Height = height;
        }
        public double Area()
        {
            return (Base * Height) / 2;
        }
    }
}