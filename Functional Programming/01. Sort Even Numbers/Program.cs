using System;
using System.Linq;

namespace Sort_Even_Numbers
{
    internal class Program
    {
        static void Main()
        {
            int[] nums = Console.ReadLine().Split(", ").Select(int.Parse).OrderBy(x => x).Where(x => x % 2 == 0)
                .ToArray();
            Console.WriteLine(string.Join(", ",nums));
        }
    }
}
