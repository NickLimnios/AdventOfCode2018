using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2018
{
    public static class aoc_2018_d3_a
    {
        public class Position
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public class Claim
        {
            public int ID { get; set; }
            public int LeftMarging { get; set; }
            public int TopMarging { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }

        private static List<Position> CalculatePositions(List<Claim> claims)
        {
            List<Position> positions = new List<Position>();
            foreach (Claim claim in claims)
            {
                List<Position> claimPositions = new List<Position>();
                for (int h = 1; h < claim.Height + 1; h++)
                {
                    for (int w = 1; w < claim.Width + 1; w++)
                    {
                        Position position = new Position();
                        position.Y = 0 + claim.TopMarging + h;
                        position.X = 0 + claim.LeftMarging + w;

                        if (!claimPositions.Exists(p => p.X == position.X && p.Y == position.Y))
                            claimPositions.Add(position);
                    }
                }
                positions.AddRange(claimPositions);
            }

            return positions;
        }


        public static void Execute()
        {
            List<Claim> claims = new List<Claim>();
            using (StreamReader reader = new StreamReader("../../../../../_Input/aoc_2018_d3_input.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Claim claim = new Claim();
                    claim.ID = Int32.Parse(line.Substring(line.IndexOf('#') + 1, line.IndexOf('@') - 1).Trim());
                    claim.LeftMarging = Int32.Parse(line.Substring(line.IndexOf('@') + 1, line.IndexOf(',') - line.IndexOf('@') - 1).Trim());
                    claim.TopMarging = Int32.Parse(line.Substring(line.IndexOf(',') + 1, line.IndexOf(':') - line.IndexOf(',') - 1).Trim());
                    claim.Width = Int32.Parse(line.Substring(line.IndexOf(':') + 1, line.IndexOf('x') - line.IndexOf(':')- 1).Trim());
                    claim.Height = Int32.Parse(line.Substring(line.IndexOf('x')+ 1, line.Length -line.IndexOf('x') -1).Trim());

                    claims.Add(claim);
                }
            }

            List<Position> positions = CalculatePositions(claims);
            int result = positions.GroupBy(p => new { p.X, p.Y}).Where(p => p.Count() > 1).Count();

            Console.WriteLine($"{result} square inches of fabric are within two or more claims.");

        }
    }
}
