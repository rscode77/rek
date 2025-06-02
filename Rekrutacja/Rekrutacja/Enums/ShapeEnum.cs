using Soneta.Types;
using System.ComponentModel;

namespace Rekrutacja.Enums
{
    public static class Enums
    {
        public enum ShapeEnum
        {
            [Caption("Kwadrat")]
            Square,

            [Caption("Prostokąt")]
            Rectangle,

            [Caption("Trójkąt")]
            Triangle,

            [Caption("Koło")]
            Circle
        }
    }
}
