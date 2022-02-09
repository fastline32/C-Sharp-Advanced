using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class FlowerWreaths
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            int wreath = 0;
            int difference = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int count = lilies.Peek() + roses.Peek();
                if (count == 15)
                {
                    wreath++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                if (count > 15)
                {
                    int n = lilies.Count;
                    Stack<int> newStack = new Stack<int>();
                    newStack.Push(lilies.Pop() - 2);
                    for (int i = 0; i < n - 1; i++)
                    {
                        newStack.Push(lilies.Pop());
                    }

                    n = newStack.Count;
                    for (int i = 0; i < n; i++)
                    {
                        lilies.Push(newStack.Pop());
                    }
                }

                if (count < 15)
                {
                    difference += count;
                    lilies.Pop();
                    roses.Dequeue();
                }

            }

            wreath += difference / 15;
            if (wreath >= 5)
            {
                Console.WriteLine("You made it, you are going to the competition with {0} wreaths!", wreath);
            }
            else
            {
                Console.WriteLine("You didn't make it, you need {0} wreaths more!", 5 - wreath);
            }

        }
    }
}
