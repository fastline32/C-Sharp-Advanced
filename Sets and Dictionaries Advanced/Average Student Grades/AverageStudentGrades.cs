using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Student_Grades
{
    internal class AverageStudentGrades
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine()!);
            Dictionary<string, List<decimal>> grades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine()!.Split().ToArray();
                string name = line[0];
                decimal grade = decimal.Parse(line[1]);
                if (grades.ContainsKey(name))
                {
                    grades[name].Add((grade));
                }
                else
                {
                    grades.Add(name,new List<decimal>());
                    grades[name].Add(grade);
                }
            }

            foreach (var name in grades)
            {
                Console.WriteLine($"{name.Key} -> {string.Join(' ',name.Value.Select(x => string.Format("{0:F2}",x)))} (avg: {name.Value.Average():F2})");
            }
        }
    }
}
