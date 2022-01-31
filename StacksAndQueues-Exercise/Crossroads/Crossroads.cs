using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Crossroads
    {
        static void Main()
        {
            int greenSeconds = int.Parse(Console.ReadLine()!);
            int freeWindow = int.Parse(Console.ReadLine()!);
            Queue<string> cars = new Queue<string>();
            int count = 0;
            var line = Console.ReadLine();
            
            while (line != "END")
            {
                int sum = greenSeconds;
                if ( line!="green" )
                {
                    cars.Enqueue(line);
                    line = Console.ReadLine();
                    continue;
                }

                while (sum > 0 && cars.Count > 0  )
                {
                    
                    string car = cars.Dequeue();
                    if (sum - car.Length >= 0)
                    {
                        sum -= car.Length;
                        count++;
                        continue;
                    }

                    if (sum + freeWindow - car.Length >= 0)
                    {
                        sum = 0;
                        count++;
                        continue;
                    }

                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{car} was hit at {car[sum+freeWindow]}.");
                    Environment.Exit(0);
                }

                line = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{count} total cars passed the crossroads.");
        }
    }
}
