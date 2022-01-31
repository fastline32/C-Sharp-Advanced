using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            Dictionary<string ,Trainer> trainers = new Dictionary<string, Trainer>();
            string line = Console.ReadLine();
            while (line != "Tournament")
            {
                string[] inputData = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Trainer.AddTrainersAndPokemons(trainers,inputData);
                line = Console.ReadLine();
            }

            line = Console.ReadLine();
            while (line != "End")
            {
                foreach (var name in trainers)
                {
                    if (name.Value.Pokomens.Any(x => x.Element == line))
                    {
                        name.Value.Badges++;
                    }
                    else
                    {
                        foreach (var pokemon in name.Value.Pokomens)
                        {
                            pokemon.Health -= 10;
                        }
                        name.Value.Pokomens = name.Value.Pokomens.Where(x => x.Health > 0).ToList();
                    }
                }

                line = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.Value.Badges))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.Badges} {trainer.Value.Pokomens.Count}");
            }
        }
    }
}
