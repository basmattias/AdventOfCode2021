using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Line
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines(@"Input5test.txt");

            var lineList = new List<Line>();
            foreach (var line in lines)
            {
                var newLine = new Line();
                newLine.X1 = int.Parse(line.Substring(0, line.IndexOf(',')));
                var y1 = line.Substring(line.IndexOf(',') + 1, line.IndexOf(' ') - line.IndexOf(',') - 1);
                newLine.Y1 = int.Parse(y1);
                var part2 = line.Substring(line.IndexOf('>') + 2);
                newLine.X2 = int.Parse(part2.Substring(0, part2.IndexOf(',')));
                newLine.Y2 = int.Parse(part2.Substring(part2.IndexOf(',') + 1));

                lineList.Add(newLine);
            }

            var straightLines = lineList.Where(l => (l.X1 == l.X2) || (l.Y1 == l.Y2));

            var coordinates = GetCoordinates(straightLines);

            var count = 0;

            foreach (var coordinate in coordinates)
            {
                if (coordinate.Value >= 2)
                {
                    count++;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Total: {count}");
        }

        static Dictionary<Tuple<int, int>, int> GetCoordinates(IEnumerable<Line> lines)
        {
            var coordinates = new Dictionary<Tuple<int, int>, int>();

            foreach (var line in lines)
            {
                // Expand every line
                var xStart = (line.X1 < line.X2) ? line.X1 : line.X2;
                var xEnd = (xStart == line.X1) ? line.X2 : line.X1;

                var yStart = (line.Y1 < line.Y2) ? line.Y1 : line.Y2;
                var yEnd = (yStart == line.Y1) ? line.Y2 : line.Y1;

                var x = xStart;
                var y = yStart;

                while ((x <= xEnd) && (y <= yEnd))
                {
                    var position = Tuple.Create(x, y);

                    if (coordinates.ContainsKey(position))
                    {
                        coordinates[position]++;
                    }
                    else
                    {
                        coordinates.Add(position, 1);
                    }

                    if (xStart != xEnd)
                        x++;
                    if (yStart != yEnd)
                        y++;
                }
            }

            return coordinates;
        }
    }
}
