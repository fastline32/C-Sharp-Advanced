using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesIinArray
{
    class CountSameValuesIinArray
    {
        static void Main()
        {
            double[] nums = Console.ReadLine()?.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray();

            Dictionary<double, int> numbers = new Dictionary<double, int>();

            if (nums != null)
                for (int i = 0; i < nums.Length; i++)
                {
                    if (!numbers.ContainsKey(nums[i]))
                    {
                        numbers[nums[i]] = 0;
                    }

                    numbers[nums[i]]++;
                }

            foreach (var num in numbers)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}
