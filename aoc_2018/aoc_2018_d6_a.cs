using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2018
{
    public static class aoc_2018_d6_a
    {
        public static void Execute()
        {
            List<Tuple<int, int>> points = new List<Tuple<int, int>>();
            using (StreamReader reader = new StreamReader("../../../../../_Input/aoc_2018_d6_input.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] array = line.Split(',');
                    points.Add(new Tuple<int, int>(Int32.Parse(array[0]), Int32.Parse(array[1].Trim())));
                }
            }

            int maxX = points.Max(p => p.Item1);
            int maxY = points.Max(p => p.Item2);

            int[,] grid = new int[maxX + 1, maxY + 1];

            for (int x = 0; x < maxX + 2; x++)
            {
                for (int y = 0; y < maxY + 2; y++)
                {
                   
                }
            }
        }
    }
}
