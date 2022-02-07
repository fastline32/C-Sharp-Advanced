using System;
using System.Linq;

namespace _03.GenericSwapMethodStrings
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                box.ListItem.Add(line);
            }

            int[] positions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            box.Swap(positions[0],positions[1]);

            Console.WriteLine(box.ToString());
        }
    }
}
