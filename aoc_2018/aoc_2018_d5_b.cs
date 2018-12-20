using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2018
{
    public static class aoc_2018_d5_b
    {
        public static void Execute()
        {
            using (StreamReader reader = new StreamReader("../../../../../_Input/aoc_2018_d5_input.txt"))
            {
                string polymer = reader.ReadToEnd();

                int minLength = polymer.Length; //init with full polymer length
                for (var i = 'a'; i < 'z'; i++)
                {
                    string modifiedPolymer = polymer.Replace(i.ToString(), "").Replace(char.ToUpper(i).ToString(), "");
                    Stack<char> units = new Stack<char>();
                    foreach (char c in modifiedPolymer)
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

                    if (units.Count < minLength)
                        minLength = units.Count; // keep the smallest polymer length
                }

                Console.WriteLine($"The length of the shortest polymer is {minLength} .");
            }
        }
    }
}
