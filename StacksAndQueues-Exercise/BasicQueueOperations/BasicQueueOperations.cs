using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class BasicQueueOperations
    {
        static void Main()
        {
            int[] nsx = Console.ReadLine()?.Split().Select(int.Parse).ToArray();
            Queue<int> forCheck = new Queue<int>();
            if (nsx != null)
            {
                int pushes = nsx[0];
                int pops = nsx[1];
                int target = nsx[2];
                int[] stekNumbers = Console.ReadLine()?.Split().Select(int.Parse).ToArray();
                for (int i = 0; i < pushes; i++)
                {
                    if (stekNumbers != null) forCheck.Enqueue(stekNumbers[i]);
                }

                for (int i = 0; i < pops; i++)
                {
                    forCheck.Dequeue();
                }

                if (forCheck.Contains(target))
                {
                    Console.WriteLine("true");
                }
                else if (forCheck.Count > 0)
                {
                    Console.WriteLine(forCheck.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
