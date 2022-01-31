using System;
using System.Collections.Generic;
using System.Linq;

namespace Cups_and_Bottles
{
    class CupsAndBottles
    {
        static void Main()
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray());
            Stack<int> bottles = new Stack<int>(Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray());
            int wastedWoter = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                if (cups.Peek() <= bottles.Peek())
                {
                    wastedWoter += bottles.Pop() - cups.Dequeue();
                }
                else
                {
                    int currentCup = cups.Dequeue();
                    while (currentCup > 0)
                    {
                        if (currentCup - bottles.Peek() <= 0)
                        {
                            wastedWoter += bottles.Peek() - currentCup;
                            currentCup -= bottles.Pop();
                        }
                        else
                        {
                            currentCup -= bottles.Pop();
                        }
                        
                    }

                }
            }

            if (bottles.Count > 0)
            {
                Console.Write("Bottles: ");
                foreach (var item in bottles)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.Write("Cups: ");
                foreach (var item in cups)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Wasted litters of water: {wastedWoter}");
        }
    }
}
