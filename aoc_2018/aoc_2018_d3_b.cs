using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2018
{
    public static class aoc_2018_d3_b
    {
        public class Position
        {
            public int X { get; set; }
            public int Y { get; set; }
            public bool Overlapping { get; set; }
        }

        public class Claim
        {
            public int ID { get; set; }
            public int LeftMarging { get; set; }
            public int TopMarging { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }


        public static void Execute()
        {
            HashSet<Claim> claims = new HashSet<Claim>();
            using (StreamReader reader = new StreamReader("../../../../../_Input/aoc_2018_d3_input.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Claim claim = new Claim();
                    claim.ID = Int32.Parse(line.Substring(line.IndexOf('#') + 1, line.IndexOf('@') - 1).Trim());
                    claim.LeftMarging = Int32.Parse(line.Substring(line.IndexOf('@') + 1, line.IndexOf(',') - line.IndexOf('@') - 1).Trim());
                    claim.TopMarging = Int32.Parse(line.Substring(line.IndexOf(',') + 1, line.IndexOf(':') - line.IndexOf(',') - 1).Trim());
                    claim.Width = Int32.Parse(line.Substring(line.IndexOf(':') + 1, line.IndexOf('x') - line.IndexOf(':') - 1).Trim());
                    claim.Height = Int32.Parse(line.Substring(line.IndexOf('x') + 1, line.Length - line.IndexOf('x') - 1).Trim());

                    claims.Add(claim);
                }
            }

            var points = new int[1000, 1000];
            var idsWithNoOverlaing = new List<int>();

            foreach (Claim claim in claims)
            {
                idsWithNoOverlaing.Add(claim.ID);

                for (int i = 0; i < claim.Width; i++)
                {
                    for (int j = 0; j < claim.Height; j++)
                    {
                        var previousId = points[claim.LeftMarging + i, claim.TopMarging + j];
                        if (previousId == 0)
                            points[claim.LeftMarging + i, claim.TopMarging + j] = claim.ID;
                        else
                        {
                            idsWithNoOverlaing.Remove(claim.ID);
                            idsWithNoOverlaing.Remove(previousId);
                        }
                    }
                }
            }

            var result = idsWithNoOverlaing.First();

            Console.WriteLine($"The ID of the only claim that doesn't overlap is {result}");
        }
    }
}
