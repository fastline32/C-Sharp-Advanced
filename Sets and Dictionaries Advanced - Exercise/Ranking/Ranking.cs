using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    internal class Ranking
    {
        static void Main()
        {
            string input = Console.ReadLine()!;
            Dictionary<string, string> contests = new Dictionary<string, string>();

            while (input != "end of contests")
            {
                string[] line = input.Split(':');
                contests.Add(line[0],line[1]);
                input = Console.ReadLine();
            }

            SortedDictionary<string, Dictionary<string, int>> candidates = new SortedDictionary<string, Dictionary<string, int>>();
            
            input = Console.ReadLine()!;
            while (input != "end of submissions")
            {
                string[] line = input.Split("=>");
                string course = line[0];
                string pass = line[1];
                string name = line[2];
                int points = int.Parse(line[3]);

                if (contests.ContainsKey(course) && contests[course] == pass)
                {
                    if (!candidates.ContainsKey(name))
                    {
                        AddName(candidates, name, course, points);
                    }
                    else if (candidates.ContainsKey(name) && !candidates[name].ContainsKey(course))
                    {
                        candidates[name].Add(course,points);
                    }
                    else if (candidates[name][course] < points)
                    {
                        candidates[name][course] = points;
                    }
                }
                input = Console.ReadLine()!;
            }

            string names = null;
            int point = 0;
            int countPoints = 0;
            foreach (var item in candidates)
            {
                foreach (var score in item.Value)
                {
                    countPoints += score.Value;
                }

                if (countPoints > point)
                {
                    point = countPoints;
                    names = item.Key;
                }

                countPoints = 0;
            }

            Console.WriteLine($"Best candidate is {names} with total {point} points.");
            Console.WriteLine("Ranking:");
            foreach (var item in candidates)
            {
                Console.WriteLine(item.Key);
                foreach (var i in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {i.Key} -> {i.Value}");
                }
            }
        }

        static void AddName(SortedDictionary<string, Dictionary<string, int>> dict, string name, string course, int points)
        {
            dict.Add(name, new Dictionary<string, int> { { course, points } });
            return;
        }

        static void GetBestCandidate(SortedDictionary<string, Dictionary<string, int>> dict, string name, int points)
        {
            int countPoints = 0;
            foreach (var item in dict)
            {
                foreach (var score in item.Value)
                {
                    countPoints += score.Value;
                }

                if (countPoints > points)
                {
                    points = countPoints;
                    name = item.Key;
                }
            }
            return;
        }
    }
}
