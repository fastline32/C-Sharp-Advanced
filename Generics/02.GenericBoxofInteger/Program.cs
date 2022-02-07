using System;

namespace _02.GenericBoxofInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();
            for (int i = 0; i < n; i++)
            {
                int line = int.Parse(Console.ReadLine());
                box.ListItem.Add(line);
            }

            Console.WriteLine(box.ToString());
        }
    }
}
