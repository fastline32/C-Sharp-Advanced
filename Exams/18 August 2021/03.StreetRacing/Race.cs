using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name,string type,int laps,int capacity,int maxHorsePower)
        {
            Name=name;
            Type=type;
            Laps=laps;
            Capacity=capacity;
            MaxHorsePower=maxHorsePower;
            Participants = new Dictionary<string, Car>();
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public Dictionary<string,Car> Participants { get; set; }
        public int Count => Participants.Count;

        public void Add(Car car)
        {
            if (!Participants.ContainsKey(car.LicensePlate)&& Count < Capacity && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car.LicensePlate,car);
            }
        }

        public bool Remove(string licensePlate)
        {
            return Participants.Remove(licensePlate);
        }

        public Car FindParticipant(string licensePlate)
        {
            return Participants.FirstOrDefault(x => x.Key == licensePlate).Value;
        }

        public Car GetMostPowerfulCar()
        {
            return Participants.OrderByDescending(x => x.Value.HorsePower).FirstOrDefault().Value;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var car in Participants)
            {
                sb.AppendLine(car.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
