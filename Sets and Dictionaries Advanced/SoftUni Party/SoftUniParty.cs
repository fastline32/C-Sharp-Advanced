using System;
using System.Collections.Generic;

namespace SoftUni_Party
{
    internal class SoftUniParty
    {
        static void Main()
        {
            string line = Console.ReadLine()!;
            HashSet<string> names = new HashSet<string>();
            while (line != "PARTY")
            {
                names.Add(line);
                line = Console.ReadLine()!;
            }
            line = Console.ReadLine()!;
            while (line!="END")
            {
                names.Remove(line);
                line= Console.ReadLine()!;
            }

            Console.WriteLine(names.Count);
            foreach (var item in names)
            {
                if (char.IsDigit(item[0]))
                {
                    Console.WriteLine(item);
                }
            }

            foreach (var item in names)
            {
                if (!char.IsDigit(item[0]))
                {
                    Console.WriteLine(item);
                        
                }
            }

        }
    }
}
