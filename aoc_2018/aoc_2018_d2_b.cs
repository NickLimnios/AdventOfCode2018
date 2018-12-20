using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2018
{
    public static class aoc_2018_d2_b
    {
        public static void Execute()
        {
            List<string> ids = new List<string>();
            using (StreamReader reader = new StreamReader("../../../../../_Input/aoc_2018_d2_input.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    ids.Add(line);
                }
            }

            string firstID = "";
            string secondID = "";
            foreach (string id in ids)
            {
                foreach (string id2 in ids)
                {
                    if (id == id2)
                    {
                        continue;
                    }

                    // For each index, find count of differences
                    int diff = id.Where((p, i) => p != id2[i]).Count();

                    if (diff == 1)
                    {
                        firstID = id;
                        secondID = id2;
         
                    }
                }
            }

            string commonletters = "";
            for (var i = 0; i < firstID.Length; ++i)
            {
                if (firstID[i] == secondID[i])
                {
                    commonletters += firstID[i].ToString();
                }
            }

            Console.WriteLine($"prototype fabric boxes: {firstID} , {secondID}");
            Console.Write($"Common Leters: {commonletters}");
            
        }
    }
}
