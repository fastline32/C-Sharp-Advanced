using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> racers;

        public Race(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            Racers = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Racer> Racers { get { return this.racers;} set { this.racers = value; } }

        public void Add(Racer Racer)
        {
            if (Racers.Count < Capacity)
            {
                Racers.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            Racer racers = Racers.Where(x => x.Name == name).FirstOrDefault();
            if (racers != null)
            {
                Racers.Remove(racers);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Racer GetOldestRacer() => Racers.OrderByDescending(x => x.Age).First();

        public Racer GetRacer(string name) => Racers.First(x => x.Name == name);

        public Racer GetFastestRacer() => Racers.OrderByDescending(x => x.Car.Speed).First();

        public int Count => Racers.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");
            foreach (var racer in Racers)
            {
                sb.AppendLine(racer.ToString());
            }
            return sb.ToString();
        }
    }
}
