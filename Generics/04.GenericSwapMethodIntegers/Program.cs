using System;
using System.Linq;

namespace _04.GenericSwapMethodIntegers
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

            int[] positions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            box.Swap(positions[0], positions[1]);

            Console.WriteLine(box.ToString());
        }
    }
}
