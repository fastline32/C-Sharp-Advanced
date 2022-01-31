using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Exam_Results
{
    class SoftUniExamResults
    {
        static void Main()
        {
            SortedDictionary<string, int> contexts = new SortedDictionary<string, int>();
            SortedDictionary<string,int> names = new SortedDictionary<string, int>();
            string input = Console.ReadLine();
            while (input!= "exam finished")
            {
                string[] line = input.Split('-');
                if (line[1] == "banned")
                {
                    if (names.ContainsKey(line[0]))
                    {
                        names.Remove(line[0]);
                    }
                    input = Console.ReadLine();
                }
                else
                {
                    string name = line[0];
                    string context = line[1];
                    int points = int.Parse(line[2]);
                    if (!names.ContainsKey(name))
                    {
                        names.Add(name,points);
                    }
                    else if (names[name] < points)
                    {
                        names[name] = points;
                    }

                    if (!contexts.ContainsKey(context))
                    {
                        contexts.Add(context,1);
                    }
                    else
                    {
                        contexts[context]++;
                    }
                    input = Console.ReadLine();
                }
            }

            Console.WriteLine("Results:");
            foreach (var item in names.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var item in contexts)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
