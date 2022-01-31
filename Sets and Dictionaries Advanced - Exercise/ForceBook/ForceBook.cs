using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class ForceBook
    {
        static void Main()
        {
            string input = Console.ReadLine();
            SortedDictionary<string, HashSet<string>> users = new SortedDictionary<string, HashSet<string>>();
            while (input != "Lumpawaroo")
            {
                if (input != null && input.Contains('|'))
                {
                    string[] parts = input.Split(" | ");
                    string side = parts[0];
                    string name = parts[1];
                    if (!users.ContainsKey(side))
                    {
                        users.Add(side, new HashSet<string>());
                        users[side].Add(name);
                        input = Console.ReadLine();
                    }
                    else
                    {
                        users[side].Add(name);
                        input = Console.ReadLine();
                    }
                }
                else if (input != null && input.Contains('>'))
                {
                    string[] parts = input.Split(" -> ");
                    string name = parts[0];
                    string side = parts[1];
                    string itemSide = null;
                    foreach (var item in users)
                    {
                        foreach (var i in item.Value)
                        {
                            if (i == name)
                            {
                                itemSide = item.Key;
                            }
                        }
                    }

                    if (itemSide != null)
                    {
                        users[itemSide].Remove(name);
                    }

                    if (users.ContainsKey(side))
                    {
                        users[side].Add(name);
                    }
                    else
                    {
                        users.Add(side, new HashSet<string>());
                        users[side].Add(name);
                    }
                    Console.WriteLine($"{name} joins the {side} side!");
                    input = Console.ReadLine();
                }
            }

            var sorted = users.OrderByDescending(x => x.Value.Count);
            foreach (var item in sorted)
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                    foreach (var n in item.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {n}");
                    }
                }
            }
        }
    }
}
