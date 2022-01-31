using System;
using System.Collections.Generic;
using System.Linq;

namespace Cities_by_Continent_and_Country
{
    internal class CitiesByContinentAndCountry
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine()!);
            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine()!.Split(' ').ToArray();
                string continent = line[0]; 
                string country = line[1];
                string city = line[2];

                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent,new Dictionary<string, List<string>>());
                } 
                if (!continents[continent].ContainsKey(country))
                {
                        continents[continent].Add(country,new List<string>());
                }
                continents[continent][country].Add(city);
            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($" {country.Key} -> {String.Join(", ",country.Value)}");
                }
            }
        }
    }
}
