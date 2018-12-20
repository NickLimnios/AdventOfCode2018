using System;
using System.Collections.Generic;
using System.IO;

namespace aoc_2018
{
    public static class aoc_2018_d5_a
    {

        public static void Execute()
        {
            using (StreamReader reader = new StreamReader("../../../../../_Input/aoc_2018_d5_input.txt"))
            {
                string polymer = reader.ReadToEnd();

                Stack<char> units = new Stack<char>();
                foreach (char c in polymer)
                {
                    if (units.Count == 0)
                    {
                        units.Push(c);
                    }
                    else
                    {
                        char topUnit = units.Peek();
                        bool reaction = c != topUnit && char.ToUpper(c) == char.ToUpper(topUnit);
                        if (reaction)
                        {
                            units.Pop();
                        }
                        else
                        {
                            units.Push(c);
                        }
                    }
                }

                Console.WriteLine($"{ units.Count} units remain after fully reacting the polymer." );
            }
        }

    }
}
