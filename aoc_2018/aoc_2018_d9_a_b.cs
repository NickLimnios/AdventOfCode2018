using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2018
{
    public static class aoc_2018_d9_a_b
    {
        public static void Execute()
        {
            int players = 431;
            int last = 70950 * 100; // for part b multiple by 100

            long[] scores = new long[players];
            LinkedList<long> circle = new LinkedList<long>();
            var current = circle.AddFirst(0);

            for (int i = 1; i < last; i++)
            {
                if (i % 23 == 0)
                {
                    scores[i % players] += i;
                    for (int j = 0; j < 7; j++)
                    {
                        current = current.Previous ?? circle.Last;
                    }
                    scores[i % players] += current.Value;
                    var remove = current;
                    current = remove.Next;
                    circle.Remove(remove);
                }
                else
                {
                    current = circle.AddAfter(current.Next ?? circle.First, i);
                }
            }

            long result = scores.Max();

            Console.WriteLine($"The winning Elf's score is {result}");
        }
    }
}
