using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    internal class CustomMinFunction
    {
        static void Main()
        {
            var nums = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            Func<int[], int> IsMin = x => x.Min();
            int result = IsMin(nums);
            Console.WriteLine(result);
        }
    }
}
