using System;
using System.Collections.Generic;

namespace Supermarket
{
    internal class Supermarket
    {
        static void Main()
        {
            string line = Console.ReadLine()!;
            Queue<string> customer = new Queue<string>();

            while (line != "End")
            {
                if (line == "Paid")
                {
                    foreach (var people in customer)
                    {
                        Console.WriteLine(people);
                    }
                    customer.Clear();
                    line = Console.ReadLine()!;
                }
                else
                {
                    customer.Enqueue(line);
                    line = Console.ReadLine()!;
                }
            }

            Console.WriteLine($"{customer.Count} people remaining.");
        }
    }
}
