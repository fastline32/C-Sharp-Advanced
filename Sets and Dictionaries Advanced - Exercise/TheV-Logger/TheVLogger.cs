using System;
using System.Collections.Generic;
using System.Linq;

namespace TheV_Logger
{
    class TheVLogger
    {
        static string l1 = "followers";
        static string l2 = "following";
        static void Main()
        {
            
            string[] input = Console.ReadLine()!.Split().ToArray();
            Dictionary<string, Dictionary<string,HashSet<string>>> vlogger = new Dictionary<string,Dictionary<string,HashSet<string>>>();

            while (input[0] != "Statistics")
            {
                if (input[1] == "joined" && !vlogger.ContainsKey(input[0]))
                {
                    CreateVloger(vlogger, input[0]);
                }
                else if (input[1] == "followed" && input[0] != input[2])
                {
                    if (vlogger.ContainsKey(input[2]) && vlogger.ContainsKey(input[0]))
                    {
                        vlogger[input[2]]["followers"].Add(input[0]);
                        vlogger[input[0]]["following"].Add(input[2]);
                    }
                }
                input = Console.ReadLine()!.Split().ToArray();
            }

            Console.WriteLine($"The V-Logger has a total of {vlogger.Count} vloggers in its logs.");
            var sorted = vlogger.OrderByDescending(x => x.Value[l1].Count)
                .ThenBy(x => x.Value[l2].Count);

            int i = 1;
            foreach (var currentVlogger in sorted)
            {
                Console.WriteLine($"{i}. {currentVlogger.Key} : {currentVlogger.Value[l1].Count} followers, {currentVlogger.Value[l2].Count} following");
                if (i == 1)
                {
                    foreach (var item in currentVlogger.Value[l1].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {item}");
                    } 
                }
                i++;
            }
        }

        static void CreateVloger(Dictionary<string, Dictionary<string, HashSet<string>>> vlogger, string p1)
        {
            vlogger.Add(p1,new Dictionary<string, HashSet<string>>());
            vlogger[p1].Add(l1,new HashSet<string>());
            vlogger[p1].Add(l2,new HashSet<string>());
            return;
        }
    }
}
