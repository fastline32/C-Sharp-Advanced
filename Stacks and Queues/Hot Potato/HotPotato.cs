using System;
using System.Collections.Generic;
using System.Linq;

namespace Hot_Potato
{
    internal class HotPotato
    {
        static void Main()
        {
            string[] names = Console.ReadLine()!.Split(' ').ToArray();
            int n = int.Parse(Console.ReadLine()!);

            Queue<string> users = new Queue<string>();
            foreach (var name in names)
            {
                users.Enqueue(name);
            }

            while (users.Count > 1)
            {
                for (int i = 0; i < n -1; i++)
                {
                    users.Enqueue(users.Dequeue());
                }

                Console.WriteLine($"Removed {users.Dequeue()}");
            }

            Console.WriteLine($"Last is {users.Dequeue()}");
        }
    }
}
