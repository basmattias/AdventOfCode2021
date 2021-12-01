using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var depths = System.IO.File.ReadAllLines("Input1.txt");
            var depthList = new List<int>();

            foreach (var depth in depths)
            {
                depthList.Add(int.Parse(depth));
            }

            Part1(depthList.ToArray());
            Part2(depthList.ToArray());
            Console.ReadKey();
        }

        private static void Part2(int[] depths)
        {
            int increments = 0;

            for (int i = 0; i < depths.Length - 3; i++)
            {
                int firstSum = depths[i] + depths[i + 1] + depths[i + 2];
                int secondSum = depths[i + 1] + depths[i + 2] + depths[i + 3];

                if (secondSum > firstSum)
                    increments++;
            }

            Console.WriteLine(increments);
        }

        private static void Part1(int[] depths)
        {
            int increments = 0;

            for (int i = 1; i < depths.Length; i++)
            {
                int previous = depths[i - 1];
                int current = depths[i];
                if (current > previous)
                    increments++;
            }

            Console.WriteLine(increments);
        }
    }
}
