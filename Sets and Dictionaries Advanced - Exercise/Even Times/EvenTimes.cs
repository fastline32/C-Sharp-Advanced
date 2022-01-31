using System;
using System.Collections.Generic;

namespace Even_Times
{
    internal class EvenTimes
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine()!);
            Dictionary<int,int> items = new Dictionary<int,int>();
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine()!);
                if (!items.ContainsKey(num))
                {
                    items.Add(num,1);
                }
                else
                {
                    items[num]++;
                }
            }

            foreach (var item in items)
            {
                if (item.Value%2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
