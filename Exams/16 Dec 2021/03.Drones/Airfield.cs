using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name,int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip  { get; set; }
        public List<Drone> Drones { get; set;  }
        public int Count => Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (Count == Capacity)
            {
                return "Airfield is full.";
            }
            else
            {
                if (drone.Name != null && drone.Range >= 5 && drone.Range <= 15)
                {
                    Drones.Add(drone);
                    return $"Successfully added {drone.Name} to the airfield.";
                }
                else
                {
                    return "Invalid drone.";
                }
            }
        }

        public bool RemoveDrone(string name)
        {
            Drone drone = Drones.FirstOrDefault(x => x.Name == name);
            return Drones.Remove(drone);
        }

        public int RemoveDroneByBrand(string brand)
        {
            List<Drone> drones = Drones.Where(x => x.Brand == brand).ToList();
            int count = drones.Count;
            foreach (var dron in Drones)
            {
                Drones.Remove(dron);
            }
            return count;
        }

        public Drone FlyDrone(string name)
        {
            Drone drone = Drones.FirstOrDefault(x => x.Name == name);
            if (drone != null)
            {
                drone.Availabble = false;
            }

            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> drones = new List<Drone>();
            foreach (var drone in Drones.Where(x=> x.Range >= range))
            {
                FlyDrone(drone.Name);
                drones.Add(drone);
            }

            return drones;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");
            foreach (var item in Drones.Where(x => x.Availabble))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}