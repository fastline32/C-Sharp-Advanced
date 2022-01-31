using System;
using System.Collections.Generic;

namespace Count_Symbols
{
    internal class CountSymbols
    {
        static void Main()
        {
            string line = Console.ReadLine();
            SortedDictionary<char,int> items = new SortedDictionary<char,int>();

            foreach (var item in line)
            {
                if (items.ContainsKey(item))
                {
                    items[item]++;
                }
                else
                {
                    items.Add(item,1);
                }
            }

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
