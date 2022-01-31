using System;
using System.Collections.Generic;

namespace TrafficJam
{
    internal class TrafficJam
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();

            string commands = Console.ReadLine()!;
            int passed = 0;
            while (commands != "end")
            {
                if (commands == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count == 0)
                        {
                           break;
                        }
                        var car = cars.Dequeue();
                        Console.WriteLine($"{car} passed!");
                        passed++;
                    }
                }
                else
                {
                    cars.Enqueue(commands);
                }
                commands = Console.ReadLine()!;
            }
            Console.WriteLine($"{passed} cars passed the crossroads.");
        }
    }
}
