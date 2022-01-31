using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class MaximumAndMinimumElement
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine()!);
            Stack<int> newStack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] commands = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

                switch (commands[0])
                {
                    case 1:
                        newStack.Push(commands[1]);break;
                    case 2:
                        if (newStack.Count > 0)
                        {
                            newStack.Pop();
                        }
                        break;
                    case 3:
                        if (newStack.Count > 0)
                        {
                            Console.WriteLine(newStack.Max());
                        }
                        break;
                    case 4:
                        if (newStack.Count>0)
                        {
                            Console.WriteLine(newStack.Min());
                        }
                        break;
                }
            }

            if (newStack.Count > 0)
            {
                Console.WriteLine(string.Join(", ",newStack));
            }
        }
    }
}
