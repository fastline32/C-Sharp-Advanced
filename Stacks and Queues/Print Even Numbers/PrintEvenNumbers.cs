using System;
using System.Collections.Generic;
using System.Linq;

namespace Print_Even_Numbers
{
    internal class PrintEvenNumbers
    {
        static void Main()
        {
            int[] nums = Console.ReadLine()!.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            Queue<int> forPrint = new Queue<int>();

            foreach (var item in nums)
            {
                if (item % 2 == 0)
                {
                    forPrint.Enqueue(item);
                }
            }

            Console.WriteLine(string.Join(", ",forPrint));
        }
    }
}
