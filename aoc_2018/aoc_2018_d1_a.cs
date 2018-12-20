using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2018
{
    public static class aoc_2018_d1_a
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

            int frequency = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                int newFrequency = frequency + numbers[i];
                
                Console.WriteLine($"Current frequency {frequency}, change of {numbers[i]}, resulting frequency {newFrequency}");

                frequency = newFrequency;
            }

            Console.WriteLine($"Final resulting frequency is : {frequency} .");

            int result = numbers.Sum();
            Console.WriteLine($"Alternative the sum is : {result} .");
        }
    }
}
