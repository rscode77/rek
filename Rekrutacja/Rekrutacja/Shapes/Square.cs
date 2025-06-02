using Rekrutacja.Interfaces;

namespace Rekrutacja.Shapes
{
    public class Square : IShape
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }
        public double Area()
        {
            return Side * Side;
        }
    }
}