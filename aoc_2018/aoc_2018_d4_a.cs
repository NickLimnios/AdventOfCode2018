using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2018
{
    public static class aoc_2018_d4_a
    {
        public class Status
        {
            public int Id { get; set; }
            public double MinutesAsleep { get; set; }
            public DateTime Timestamp { get; set; }
        }


        public static void Execute()
        {
            List<Status> statuses = new List<Status>();
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
            int currentId = 0;
            for (int i = 0; i < ordered.Count; i++)
            {
                Tuple<DateTime, String> tuple = ordered[i];
                Status status = new Status();
                status.Timestamp = tuple.Item1;
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
                }
                else if (description.Contains("asleep"))
                {
                    status.Id = currentId;
                    status.MinutesAsleep = 0;
                }

                statuses.Add(status);

            }

            List<Status> sts = statuses.GroupBy(p => p.Id).Select(g => new Status { Id = g.Key, MinutesAsleep = g.Sum(r => r.MinutesAsleep)}).ToList();
            double maxValue = sts.Max(p => p.MinutesAsleep);
            Status maxStatus = sts.Where(p => p.MinutesAsleep == maxValue).FirstOrDefault();

            List<Status> maxStatusList = statuses.Where(p => p.Id == maxStatus.Id).ToList();
            List<int> minutes = new List<int>();

            for (int i = 0; i < maxStatusList.Count; i++)
            {
                if (maxStatusList[i].MinutesAsleep != 0)
                {
                    DateTime start = maxStatusList[i - 1].Timestamp;
                    DateTime end = maxStatusList[i].Timestamp;
                    for (DateTime counter = start; counter < end; counter = counter.AddMinutes(1))
                    {
                        minutes.Add(counter.Minute);
                    }
                }
            }

            int min = minutes.GroupBy(s => s).OrderByDescending(s => s.Count()).First().Key;

            int result = maxStatus.Id * min;
            Console.WriteLine($"The ID of the guard multiplied by the minute is {result}");
        }
    }
}
