using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2018
{
    public static class aoc_2018_d4_b
    {
        public class Status
        {
            public int Id { get; set; }
            public double MinutesAsleep { get; set; }
            public DateTime Timestamp { get; set; }

            public List<int> MinutesAsleepList { get; set; }
        }


        public static void Execute()
        {
           
            List<Tuple<DateTime, String>> tuples = new List<Tuple<DateTime, String>>();
            using (StreamReader reader = new StreamReader("../../../../../_Input/aoc_2018_d4_input.txt"))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    Tuple<DateTime, String> t = new Tuple<DateTime, String>(
                        DateTime.Parse(line.Substring(line.IndexOf('[') + 1, line.IndexOf(']') - 1).Trim()),
                        line.Substring(line.IndexOf(']') + 1, line.Length - line.IndexOf(']') - 1)
                        );

                    tuples.Add(t);
                }
            }

            List<Tuple<DateTime, String>> ordered = tuples.OrderBy(p => p.Item1).ToList();
            List<Status> statuses = new List<Status>();
            int currentId = 0;
            for (int i = 0; i < ordered.Count; i++)
            {
                Tuple<DateTime, String> tuple = ordered[i];
                Status status = new Status();
                status.Timestamp = tuple.Item1;
                status.MinutesAsleepList = new List<int>();
                string description = tuple.Item2.Substring(tuple.Item2.IndexOf(']') + 1, tuple.Item2.Length - tuple.Item2.IndexOf(']') - 1);

                if (description.Contains("#"))
                {
                    status.Id = Int32.Parse(new String(description.Where(Char.IsDigit).ToArray()));
                    currentId = status.Id;
                    status.MinutesAsleep = 0;
                }
                else if (description.Contains("wakes"))
                {
                    status.Id = currentId;
                    status.MinutesAsleep = status.Timestamp.Subtract(statuses[i - 1].Timestamp).TotalMinutes;

                    DateTime start = ordered[i - 1].Item1;
                    DateTime end = ordered[i].Item1;
                    for (DateTime counter = start; counter < end; counter = counter.AddMinutes(1))
                    {
                        status.MinutesAsleepList.Add(counter.Minute);
                    }

                }
                else if (description.Contains("asleep"))
                {
                    status.Id = currentId;
                    status.MinutesAsleep = 0;
                }

                statuses.Add(status);

            }
            Dictionary<int, Tuple<int,int>> dic = new Dictionary<int, Tuple<int, int>>();
            List<int> ids = statuses.Select(p => p.Id).Distinct().ToList();
            foreach (int id in ids)
            {
                List<int> list = new List<int>();
                foreach (Status status in statuses)
                {
                    if (status.Id == id && status.MinutesAsleepList != null)
                        list.AddRange(status.MinutesAsleepList);
                }

                int maxMinute = 0;
                int count = 0;
                if (list.Count > 0)
                {
                    maxMinute = list.GroupBy(i => i).OrderBy(g => g.Count()).Last().Key;
                    count = list.GroupBy(i => i).OrderBy(g => g.Count()).Select(c => c.Count()).Last();
                }

                dic.Add(id, new Tuple<int, int>(maxMinute , count));
            }

            KeyValuePair<int, Tuple<int, int>> pair = dic.OrderByDescending(p => p.Value.Item2).First();

            int result = pair.Key * pair.Value.Item1;
            Console.WriteLine($"The resu is {result}");

        }
    }
}
