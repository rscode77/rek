using System;

namespace Rekrutacja.Helpers
{
    public static class OperationHelper
    {
        public static double CalculateAB(double a, double b, string operation)
        {
            switch (operation)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    return a / b;
            }

            throw new ArgumentException($"Nieznana operacja: {operation}");
        }
    }
}