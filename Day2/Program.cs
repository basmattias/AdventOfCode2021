using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = System.IO.File.ReadAllLines(@"Input2.txt");

            var result = Part1(data);
            Console.WriteLine($"Position 1: horizontal: {result.Item1}, depth: {result.Item2}. Product: {result.Item1 * result.Item2}");

            result = Part2(data);
            Console.WriteLine($"Position 2: horizontal: {result.Item1}, depth: {result.Item2}. Product: {result.Item1 * result.Item2}");

            Console.ReadKey();
        }

        private static Tuple<int, int> Part1(string[] data)
        {
            var forwards = 0;
            var ups = 0;
            var downs = 0;

            foreach (var s in data)
            {
                var c = s.Split(' ');
                var v = int.Parse(c[1]);
                switch (c[0])
                {
                    case "forward":
                        forwards += v;
                        break;
                    case "up":
                        ups += v;
                        break;
                    case "down":
                        downs += v;
                        break;
                    default:
                        Console.WriteLine("STFU");
                        throw new ApplicationException();
                }
            }

            return Tuple.Create(forwards, downs - ups);
        }

        private static Tuple<int, int> Part2(string[] data)
        {
            var forwards = 0;
            var depth = 0;
            var aim = 0;

            foreach (var s in data)
            {
                var c = s.Split(' ');
                var v = int.Parse(c[1]);
    
                switch (c[0])
                {
                    case "forward":
                        forwards += v;
                        depth += aim * v;
                        break;
                    case "up":
                        aim -= v;
                        break;
                    case "down":
                        aim += v;
                        break;
                    default:
                        Console.WriteLine("STFU");
                        throw new ApplicationException();
                }
            }

            return Tuple.Create(forwards, depth);
        }
    }
}
