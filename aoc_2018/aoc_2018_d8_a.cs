using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2018
{
    public static class aoc_2018_d8_a
    {
        public class Node
        {
            public List<int> Metadata { get; set; } 
            public List<Node> Nodes { get; set; }

            public Node()
            {
                Metadata = new List<int>();
                Nodes = new List<Node>();
            }
            public int Sum()
            {
                return Metadata.Sum() + Nodes.Sum(x => x.Sum());
            }
        }

        public static void Execute()
        {
            List<int> numbers = new List<int>();
            using (StreamReader reader = new StreamReader("../../../../../_Input/aoc_2018_d8_input.txt"))
            {
                numbers = reader.ReadToEnd().Split(' ').Select(int.Parse).ToList();
            }

            int i = 0;
            Node root = ReadNode(numbers, ref i);
            int result = root.Sum();

            Console.WriteLine($"The sum of all metadata entries is {result}");


        }

        public static Node ReadNode(List<int> numbers, ref int i)
        {
            Node node = new Node();
            int children = numbers[i++];
            int metadata = numbers[i++];
            for (int j = 0; j < children; j++)
            {
                node.Nodes.Add(ReadNode(numbers, ref i));
            }

            for (int j = 0; j < metadata; j++)
            {
                node.Metadata.Add(numbers[i++]);
            }

            return node;
        }


    }
}
