using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2018
{
    public static class aoc_2018_d7_b
    {
        public class Step
        {
            public char beforeChar { get; set; }
            public char afterChar { get; set; }
        }

        public class Work
        {
            public string step { get; set; }
            public int finish { get; set; }
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
            List<int> workers = new List<int>(5) { 0, 0, 0, 0, 0 };
            int currentSecond = 0;
            List<Work> done = new List<Work>();

            while (totalSteps.Any() || workers.Any(p => p > currentSecond))
            {

                done.Where(p => p.finish <= currentSecond).ToList().ForEach(x => steps.RemoveAll(d => d.beforeChar.ToString() == x.step));
                done.RemoveAll(d => d.finish <= currentSecond);

                List<char> chars = totalSteps.Where(p => !steps.Any(c => c.afterChar == p)).ToList();

                for (int i = 0; i < workers.Count && chars.Any(); i++)
                {
                    if (workers[i] <= currentSecond)
                    {
                        workers[i] = (chars.First() - 'A') + 61 + currentSecond;
                        totalSteps.Remove(chars.First());
                        done.Add(new Work { step = chars.First().ToString(), finish = workers[i] });
                        chars.RemoveAt(0);
                    }
                }

                currentSecond++;
            }

            string result = currentSecond.ToString();

            Console.WriteLine($"To complete all of the steps it takes {result} seconds.");
        }
    }
}
