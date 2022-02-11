using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    class TheFightForGondor
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            Queue<int> humans = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            Stack<int> orks = new Stack<int>();
            for (int i = 1; i <= waves; i++)
            {
                if (humans.Count > 0)
                {
                    if (i % 3 == 0)
                    {
                        orks = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));
                        humans.Enqueue(int.Parse(Console.ReadLine()));
                    }
                    else
                    {
                        orks = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));
                    }
                    while (humans.Count > 0 && orks.Count > 0)
                    {
                        if (humans.Peek() > orks.Peek())
                        {
                            humans = UpdatedQ(humans, orks.Peek());
                            orks.Pop();
                        }
                        else if (humans.Peek() < orks.Peek())
                        {
                            orks = UpdatetS(orks, humans.Dequeue());
                        }
                        else
                        {
                            humans.Dequeue();
                            orks.Pop();
                        }
                    }
                }
            }
            if (humans.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine("Plates left: {0}", string.Join(", ", humans));
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine("Orcs left: {0}", string.Join(", ", orks));
            }
        }

        public static Queue<int> UpdatedQ(Queue<int> a, int n)
        {
            int count = a.Count - 1;
            Queue<int> b = new Queue<int>();
            b.Enqueue(a.Dequeue() - n);
            for (int i = 0; i < count; i++)
            {
                b.Enqueue(a.Dequeue());
            }
            a = b;
            return a;
        }

        public static Stack<int> UpdatetS(Stack<int> a, int n)
        {
            int count = a.Count - 1;
            Stack<int> b = new Stack<int>();
            b.Push(a.Pop() - n);
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
