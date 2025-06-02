using System;
using System.Text.RegularExpressions;

namespace Rekrutacja.Extensions
{
    public static class StringExtension
    {
        private static int GetIntValue(char ch)
        {
            switch (ch)
            {
                case '0': return 0;
                case '1': return 1;
                case '2': return 2;
                case '3': return 3;
                case '4': return 4;
                case '5': return 5;
                case '6': return 6;
                case '7': return 7;
                case '8': return 8;
                case '9': return 9;
                default: return 0;
            }
        }

        public static double ToDouble(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0.0d;

            var value = input.Split(',');

            int total = 0;            

            foreach (var ch in value[0])
            {
                total = total * 10 + GetIntValue(ch);
            }

            double result = total;
            int @decimal = 0;
            if (value.Length > 1)
            {
                foreach (var ch in value[1])
                {
                    @decimal = @decimal * 10 + GetIntValue(ch);
                }
                result += @decimal / Math.Pow(10, value[1].Length);
            }
            return result;
        }
    }
}