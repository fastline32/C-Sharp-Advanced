using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_of_Elements
{
    internal class SetsOfElements
    {
        static void Main()
        {
            int[] setsItems = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int[] firstSet = new int[setsItems[0]];
            int[] secondSet = new int[setsItems[1]];
            for (int i = 0; i < setsItems[0]; i++)
            {
                firstSet[i] = int.Parse(Console.ReadLine()!);
            }
            for (int i = 0; i < setsItems[1]; i++)
            {
                secondSet[i] = int.Parse(Console.ReadLine()!);
            }

            Dictionary<int, int> matches = new Dictionary<int, int>();
            foreach (var item in firstSet)
            {
                if (!matches.ContainsKey(item))
                {
                    matches.Add(item,0);
                }
            }

            foreach (var item in secondSet)
            {
                if (matches.ContainsKey(item))
                {
                    matches[item]++;
                }
            }

            foreach (var item in matches)
            {
                if (item.Value > 0)
                {
                    Console.Write($"{item.Key} ");
                }
            }
        }
    }
}
