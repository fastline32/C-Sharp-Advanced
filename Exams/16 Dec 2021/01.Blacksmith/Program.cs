using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steels = new Queue<int>(Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> carbons = new Stack<int>(Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string, int> swords = new Dictionary<string, int>();
            swords.Add("Gladius",0);
            swords.Add("Shamshir", 0);
            swords.Add("Katana", 0);
            swords.Add("Sabre", 0); 
            swords.Add("Broadsword", 0);

            while (steels.Count > 0 && carbons.Count > 0)
            {
                int steel = steels.Dequeue();
                int carbon = carbons.Pop();
                int sum = steel + carbon;
                switch (sum)
                {
                    case 70:
                        swords["Gladius"]++;break;
                    case 80:
                        swords["Shamshir"]++;break;
                    case 90:
                        swords["Katana"]++; break;
                    case 110:
                        swords["Sabre"]++;break;
                    case 150:
                        swords["Broadsword"]++; break;
                    default:
                        carbon += 5;
                        carbons.Push(carbon);break;
                }
            }

            if (swords.Values.Sum() != 0)
            {
                Console.WriteLine($"You have forged {swords.Values.Sum()} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steels.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine("Steel left: " + string.Join(", ",steels));
            }
            if (carbons.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine("Carbon left: " + string.Join(", ", carbons));
            }

            if (swords.Values.Sum()!=0)
            {
                foreach (var sword in swords.OrderBy(x=>x.Key).Where(x=>x.Value!=0))
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
        }
    }
}
//100
