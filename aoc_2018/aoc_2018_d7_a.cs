using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2018
{
    public static class aoc_2018_d7_a
    {
        public class Step
        {
            public char beforeChar { get; set; }
            public char afterChar { get; set; }
        }

        public static void Execute()
        {
            List<Step> steps = new List<Step>();
            using (StreamReader reader = new StreamReader("../../../../../_Input/aoc_2018_d7_input.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Step step = new Step
                    {
                        beforeChar = line.ToCharArray()[5],
                        afterChar = line.ToCharArray()[36]
                    };

                    steps.Add(step);
                }
            }

           List<char> totalSteps = steps.Select(p => p.beforeChar).Concat(steps.Select(p => p.afterChar)).Distinct().OrderBy(p => p).ToList();
            string result = "";

            while (totalSteps.Any())
            {
                char ch = totalSteps.Where(p => !steps.Any(c => c.afterChar == p)).First();
                result += ch;

                totalSteps.Remove(ch);
                steps.RemoveAll(p => p.beforeChar == ch);
            }

            Console.WriteLine($"The correct order is {result}");
        }
    }
}
