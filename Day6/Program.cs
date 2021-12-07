using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
//            var input = "3,4,3,1,2";
            var input = "1,1,3,5,3,1,1,4,1,1,5,2,4,3,1,1,3,1,1,5,5,1,3,2,5,4,1,1,5,1,4,2,1,4,2,1,4,4,1,5,1,4,4,1,1,5,1,5,1,5,1,1,1,5,1,2,5,1,1,3,2,2,2,1,4,1,1,2,4,1,3,1,2,1,3,5,2,3,5,1,1,4,3,3,5,1,5,3,1,2,3,4,1,1,5,4,1,3,4,4,1,2,4,4,1,1,3,5,3,1,2,2,5,1,4,1,3,3,3,3,1,1,2,1,5,3,4,5,1,5,2,5,3,2,1,4,2,1,1,1,4,1,2,1,2,2,4,5,5,5,4,1,4,1,4,2,3,2,3,1,1,2,3,1,1,1,5,2,2,5,3,1,4,1,2,1,1,5,3,1,4,5,1,4,2,1,1,5,1,5,4,1,5,5,2,3,1,3,5,1,1,1,1,3,1,1,4,1,5,2,1,1,3,5,1,1,4,2,1,2,5,2,5,1,1,1,2,3,5,5,1,4,3,2,2,3,2,1,1,4,1,3,5,2,3,1,1,5,1,3,5,1,1,5,5,3,1,3,3,1,2,3,1,5,1,3,2,1,3,1,1,2,3,5,3,5,5,4,3,1,5,1,1,2,3,2,2,1,1,2,1,4,1,2,3,3,3,1,3,5";
            Console.WriteLine(input);

            var numbers = input.Split(',');
            var fish = numbers.Select(x => int.Parse(x)).ToList();

            int day = 0;
            while (day++ < 80)
            {
                var newFish = 0;

                // See if there are new fish
                for (int i = 0; i < fish.Count; i++)
                {
                    if (fish[i] == 0)
                    {
                        fish[i] = 6;
                        newFish++;
                    }
                    else
                    {
                        fish[i]--;
                    }
                }

                // Add the new ones
                for (int i = 0; i < newFish; i++)
                {
                    fish.Add(8);
                }

                //Console.Write($"{day:D2}: ");
                //for (int i = 0; i < fish.Count; i++)
                //{
                //    Console.Write($"{fish[i]}");
                //    if (i < fish.Count - 1)
                //        Console.Write(",");
                //}

                //Console.WriteLine();
            }

            Console.WriteLine($"Total of {fish.Count} lanternfish");
            Console.ReadKey();
        }
    }
}
