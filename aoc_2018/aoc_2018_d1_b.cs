using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2018
{
    public static class aoc_2018_d1_b
    {
        public static void Execute()
        {
            List<int> numbers = new List<int>();
            using (StreamReader reader = new StreamReader("../../../../../_Input/aoc_2018_d1_input.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int num = 0;
                    Int32.TryParse(line, out num);

                    numbers.Add(num);
                }
            }

            HashSet<int> cachedFrequencies = new HashSet<int>();
            int? firstDuplicateFrequency = null;
            int frequency = 0;
            int loop = 0;
            bool flag = true;
            while (flag)
            {
                //Console.WriteLine($"LOOP ({loop}) : At this point, the device continues from the start of the list.");
                for (int i = 0; i < numbers.Count; i++)
                {
                    int newFrequency = frequency + numbers[i];
                    //Console.WriteLine($"Current frequency {frequency}, change of {numbers[i]}, resulting frequency {newFrequency}");
                    frequency = newFrequency;

                    if (loop > 0 && cachedFrequencies.Contains(frequency))
                    {
                        flag = false;
                        firstDuplicateFrequency = frequency;
                        break;

                    }

                    cachedFrequencies.Add(frequency);
                    
                }
                loop++;
            }

            int result = numbers.Sum();
            Console.WriteLine($"Final resulting frequency is : {result} .");
            Console.WriteLine($"First reach {firstDuplicateFrequency} twice.");

        }
    }
}
