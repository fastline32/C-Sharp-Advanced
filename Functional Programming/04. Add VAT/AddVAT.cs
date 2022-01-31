using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Add_VAT
{
    internal class AddVAT
    {
        static void Main(string[] args)
        {
            List<decimal> nums = Console.ReadLine().Split(", ").Select(decimal.Parse).ToList();
            
            nums = nums.Select(x =>x * 1.2m).ToList();

            nums.ForEach(x => Console.WriteLine($"{x:f2}"));
        }
    }
}
