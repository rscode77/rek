namespace Rekrutacja.Interfaces
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