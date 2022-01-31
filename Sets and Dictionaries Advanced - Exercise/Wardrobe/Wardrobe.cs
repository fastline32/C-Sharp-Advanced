using System;
using System.Collections.Generic;

namespace Wardrobe
{
    internal class Wardrobe
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine()!);
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine()!.Split(" -> ");
                string color = line[0];
                string[] clothes = line[1].Split(',');
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color,new Dictionary<string, int>());
                }

                foreach (var item in clothes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item,1);
                    }
                    else
                    {
                        wardrobe[color][item]++;
                    }
                }
            }

            string[] searches = Console.ReadLine()!.Split();
            string searchColor = searches[0];
            string searchClothes = searches[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var clothes in color.Value)
                {
                    if (color.Key == searchColor && clothes.Key == searchClothes)
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                    }
                }
            }
        }
    }
}
