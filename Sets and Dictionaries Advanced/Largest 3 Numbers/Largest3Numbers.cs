using System;
using System.Linq;

namespace Largest_3_Numbers
{
    internal class Largest3Numbers
    {
        static void Main()
        {
            int[] line = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
            int[] sorted = line.OrderByDescending(n => n).ToArray();
            if (sorted.Length > 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(sorted[i] + " ");
                }
            }
            else
            {
                Console.WriteLine(string.Join(' ', sorted));
            }
        }
    }
}
