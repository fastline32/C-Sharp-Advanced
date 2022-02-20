using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish = new List<Fish>();
        public string Material { get; set; }
        public int Capacity { get; set; }
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
        }
        public int Count => Fish.Count;
        public string AddFish(Fish fish)
        {
            if (fish.FishType == null || fish.FishType == " " || fish.Length <= 0 || fish.Weight <= 0)
            {
                return $"Invalid fish.";
            }
            else if (Fish.Count >= Capacity)
            {
                return $"Fishing net is full.";
            }
            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }
        public bool ReleaseFish(double weight) => Fish.Remove(Fish.FirstOrDefault(x => x.Weight == weight));
        public Fish GetFish(string fishType) => Fish.FirstOrDefault(x => x.FishType == fishType);
        public Fish GetBiggestFish() => Fish.OrderByDescending(x => x.Length).FirstOrDefault();
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");
            foreach (var fish in Fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().TrimEnd();

        }
    }
}