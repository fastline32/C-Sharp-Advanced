using System;
using System.Collections.Generic;
using System.Linq;

namespace Bakery_Shop
{
    class Program
    {
        static void Main()
        {
            Queue<double> waters = new Queue<double>(Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));

            Stack<double> flours = new Stack<double>(Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));

            Dictionary<string, int> products = new Dictionary<string, int>();
            products.Add("Croissant",0);
            products.Add("Muffin", 0);
            products.Add("Baguette", 0);
            products.Add("Bagel", 0);

            while (waters.Count > 0 && flours.Count > 0)
            {
                double water = waters.Dequeue();
                double flour = flours.Pop();
                var percentages = GetPercentages(water, flour);
                switch (percentages)
                {
                    case 40:
                        products["Muffin"]++;break;
                    case 30:
                        products["Baguette"]++; break;
                    case 20:
                        products["Bagel"]++; break;
                    case 50:
                        products["Croissant"]++; break;
                    default:
                        products["Croissant"]++; 
                        flour -= water;
                        flours.Push(flour); break;
                }
            }

            foreach (var product in products.OrderByDescending(x=>x.Value).ThenBy(x => x.Key).Where(x => x.Value > 0))
            {
                Console.WriteLine($"{ product.Key}: { product.Value}");
            }

            if (waters.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine("Water left: " + string.Join(", ",waters));
            }
            if (flours.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine("Flour left: " + string.Join(", ", flours));
            }
        }

        public static double GetPercentages(double water, double flour)
        {
            var sum = water + flour;
            double percentages = (water * 100) / sum;

            return percentages;
        }
    }
}
