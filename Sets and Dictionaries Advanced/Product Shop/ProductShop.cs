using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Shop
{
    internal class ProductShop
    {
        static void Main()
        {
            SortedDictionary<string, Dictionary<string, double>> shop =
                new SortedDictionary<string, Dictionary<string, double>>();
            string[] command = Console.ReadLine()!.Split(new []{", "},StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (command[0] != "Revision")
            {
                string shops = command[0];
                string product = command[1];
                double price = double.Parse(command[2]);
              if (!shop.ContainsKey(shops))
                {
                    shop.Add(shops,new Dictionary<string, double>());
                    shop[shops].Add(product,price);
                }
                else
                {
                    if (!shop[shops].ContainsKey(product))
                    {
                        shop[shops].Add(product, price);
                    }
                    else
                    {
                        shop[shops][product] = price;
                    }
                }
              command = Console.ReadLine()!.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            foreach (var item in shop)
            {
                Console.WriteLine(item.Key+"->");
                foreach (var n in item.Value)
                {
                    Console.WriteLine($"Product: {n.Key}, Price: {n.Value}");
                }
            }
        }
    }
}