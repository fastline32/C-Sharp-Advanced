using System;
using System.Collections.Generic;

namespace Periodic_Table
{
    internal class PeriodicTable
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine()!);
            SortedSet<string> periodicItems = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();
                foreach (var item in line)
                {
                    periodicItems.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ",periodicItems));
        }
    }
}
