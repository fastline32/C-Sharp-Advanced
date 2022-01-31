using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class FashionBoutique
    {
        static void Main()
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine()!
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int capacity = int.Parse(Console.ReadLine()!);
            int sum = 0;
            int numberOfRacks = 1;

            while (stack.Count > 0)
            {
                sum += stack.Peek();
                if (sum <= capacity)
                {
                    stack.Pop();
                }
                else
                {
                    numberOfRacks++;
                    sum = 0;
                }

            }
            Console.WriteLine(numberOfRacks);
        }
    }
}
