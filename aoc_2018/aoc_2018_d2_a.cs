using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2018
{
    public static class aoc_2018_d2_a
    {
        public static void Execute()
        {
            List<string> ids = new List<string>();
            int couplesCount = 0;
            int triplesCount = 0;
            using (StreamReader reader = new StreamReader("../../../../../_Input/aoc_2018_d2_input.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    ids.Add(line);

                    var couples = line.GroupBy(c => c).Where(c => c.Count() == 2).FirstOrDefault();
                    if (couples != null) couplesCount++; 

                    var triples = line.GroupBy(c => c).Where(c => c.Count() == 3).FirstOrDefault();
                    if (triples != null) triplesCount++;
                }
            }

            int checkSum = couplesCount * triplesCount;

            Console.WriteLine($"Checksum is {couplesCount} * {triplesCount} = {checkSum}");

        }

    }
}
