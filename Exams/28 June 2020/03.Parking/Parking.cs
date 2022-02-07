using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private string type;

        private int capacity;

        private List<Car> cars;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.cars = new List<Car>();
        }

        public string Type { get { return this.type; } set { this.type = value; } }

        public int Capacity { get { return this.capacity; } set { this.capacity = value; } }

        public List<Car> Cars { get { return this.cars; } set { this.cars = value; } }
        public void Add(Car car)
        {
                Cars.Add(car);
        }
        public bool Remove(string manufacturer, string model)
        {
            if (Cars.Any(x => x.Manufacturer == manufacturer))
            {
                if (Cars.Any(x => x.Manufacturer == manufacturer && x.Model == model))
                {
                    Car car = Cars.Where(x => x.Manufacturer == manufacturer && x.Model == model).FirstOrDefault();
                    Cars.Remove(car);
                    return true;
                }
            }
            return false;
        }

        public Car GetLatestCar()
        {
            if (Cars.Count == 0)
            {
                return null;
            }
            else
            {
                Car car = Cars.OrderByDescending(x => x.Year).FirstOrDefault();
                return car;
            }
            
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car car = Cars.Where(x => x.Manufacturer == manufacturer && x.Model == model).FirstOrDefault();

            return car;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {type}:");
            foreach (var item in Cars)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public int Count => Cars.Count;
    }
}
