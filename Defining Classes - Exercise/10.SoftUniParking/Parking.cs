using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;
        private List<Car> cars;

        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.Capacity = capacity;
        }

        public List<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }

        public int Capacity
        {
            set { this.capacity = value; }
        }

        public string AddCar(Car car)
        {
            int capacity = this.capacity;
            string regNumber = car.RegistrationNumber;
            string line = null;
            foreach (var item in Cars)
            {
                if (item.RegistrationNumber == regNumber)
                {
                    return "Car with that registration number, already exists!";
                }

                if (Cars.Count == capacity)
                {
                    return "Parking is full!";
                }
            }

            Cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public Car GetCar(string regNumber)
            => Cars.Where(x => x.RegistrationNumber == regNumber).ToList().FirstOrDefault();

        public string RemoveCar(string regNumber)
        {
            string line = null;
            if (Cars.Any(x => x.RegistrationNumber == regNumber))
            {
                Car car = Cars.Where(x => x.RegistrationNumber == regNumber).ToList().First();
                Cars.Remove(car);
                line = $"Successfully removed {regNumber}";
            }
            else
            {
                line = "Car with that registration number, doesn't exist!";
            }

            return line;
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (string regNumber in RegistrationNumbers)
            {
                if (Cars.Any(x => x.RegistrationNumber == regNumber))
                {
                    Car car = Cars.Where(x => x.RegistrationNumber == regNumber).ToList().First();
                    Cars.Remove(car);
                }
            }
        }

        public int Count => Cars.Count;
    }
}
