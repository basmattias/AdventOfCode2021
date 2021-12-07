using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines(@"Input3.txt");

            var columnCount = lines[0].Length;

            var gamma = string.Empty;
            var epsilon = string.Empty;

            for (int i = 0; i < columnCount; i++)
            {
                int ones = 0;

                foreach (var line in lines)
                {
                    if (line[i] == '1')
                        ones++;
                }

                if (ones > lines.Length / 2)
                {
                    gamma += '1';
                    epsilon += '0';
                }
                else
                {
                    gamma += '0';
                    epsilon += '1';
                }
            }

            Console.WriteLine($"Gamma: {gamma}  epsilon: {epsilon}");

            int gammaNr = GetDecimalFromBinary(gamma);
            int epsilonNr = GetDecimalFromBinary(epsilon);

            Console.WriteLine($"Gamma: {gammaNr}  epsilon: {epsilonNr}");
            Console.WriteLine($"Product: {gammaNr*epsilonNr}");
        }

        private static int GetDecimalFromBinary(string s)
        {
            int sum = 0;
            int factor = 1;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[s.Length - i - 1] == '1')
                    sum += factor;

                factor *= 2;
            }

            return sum;
        }
    }
}
