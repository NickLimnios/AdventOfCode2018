using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2018
{
    public static class aoc_2018_d10_a
    {
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int VX { get; set; }
            public int VY { get; set; }

            public void Move()
            {
                X += VX;
                Y += VY;
            }
        }

        public static void Execute()
        {
            List<Point> points = new List<Point>();
            using (StreamReader reader = new StreamReader("../../../../../_Input/aoc_2018_d10_input.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    points.Add(new Point {
                        X = int.Parse(line.Substring(10, 2)),
                        Y = int.Parse(line.Substring(14, 2)),
                        VX = int.Parse(line.Substring(28, 2)),
                        VY = int.Parse(line.Substring(32, 2))
                    });
                }
            }


         

        }
    }
}
