using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class WarmWinter
    {
        static void Main()
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine()?.Split(" ").Select(int.Parse) ?? Array.Empty<int>());
            Queue<int> scarfs = new Queue<int>(Console.ReadLine()?.Split(" ").Select(int.Parse) ?? Array.Empty<int>());

            List<int> prices = new List<int>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                if (hats.Peek() > scarfs.Peek())
                {
                    int sum = hats.Pop() + scarfs.Dequeue();
                    prices.Add(sum);
                }
                else if (hats.Peek() == scarfs.Peek())
                {
                    hats = UpdatedS(hats);
                    scarfs.Dequeue();
                }
                else
                {
                    hats.Pop();
                }
            }

            Console.WriteLine("The most expensive set is: {0}", prices.Max());
            Console.WriteLine(string.Join(" ", prices));
        }

        public static Stack<int> UpdatedS(Stack<int> a)
        {
            int count = a.Count - 1;
            Stack<int> b = new Stack<int>();
            b.Push(a.Pop() + 1);
            for (int i = 0; i < count; i++)
            {
                b.Push(a.Pop());
            }
            a = b;
            count = a.Count;
            b = new Stack<int>();
            for (int i = 0; i < count; i++)
            {
                b.Push(a.Pop());
            }
            return b;
        }
    }
}