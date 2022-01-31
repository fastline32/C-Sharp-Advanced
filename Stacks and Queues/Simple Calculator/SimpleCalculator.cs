using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    internal class SimpleCalculator
    {
        static void Main()
        {
            string input = Console.ReadLine()!;
            int[] line = input.Split(new char[]{'+', '-' }).Select(int.Parse).ToArray();
            Queue<char> signs = new Queue<char>();
            foreach (var cha in input)
            {
                if (cha == '+')
                {
                    signs.Enqueue(cha);
                }
                else if (cha == '-')
                {
                    signs.Enqueue(cha);
                }
            }

            int sum = line[0];
            for (int i = 1; i < line.Length; i++)
            {
                if (signs.Peek()=='+')
                {
                    sum += line[i];
                    signs.Dequeue();
                }
                else if (signs.Peek() == '-')
                {
                    sum-=line[i];
                    signs.Dequeue();
                }
            }

            Console.WriteLine(sum);
        }
    }
}
