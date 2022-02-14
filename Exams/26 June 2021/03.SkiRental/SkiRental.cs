using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> ski;
        public SkiRental(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            ski = new List<Ski>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => ski.Count;

        public List<Ski> Ski => ski;

        public void Add(Ski ski)
        {
            if (Count < Capacity)
            {
                Ski.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski ski = Ski.First(x => x.Manufacturer == manufacturer && x.Model == model);
            if (ski != null)
            {
                return Ski.Remove(ski);
            }
            return false;
        }

        public Ski GetNewestSki()
        {
            if (Ski.Count == 0)
            {
                return null;
            }

            Ski ski = Ski.OrderByDescending(x => x.Year).First();
            return ski;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            Ski ski = Ski.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (ski == null)
            {
                return null;
            }
            return ski;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var ski in Ski)
            {
                sb.AppendLine(ski.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

//91