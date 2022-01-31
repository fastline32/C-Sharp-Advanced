using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            string line = Console.ReadLine();
            while (line != "No more tires")
            {
                string[] splitLine = line.Split(' ');
                Tire tire1 = new Tire(int.Parse(splitLine[0]), double.Parse(splitLine[1]));
                Tire tire2 = new Tire(int.Parse(splitLine[2]), double.Parse(splitLine[3]));
                Tire tire3 = new Tire(int.Parse(splitLine[4]), double.Parse(splitLine[5]));
                Tire tire4 = new Tire(int.Parse(splitLine[6]), double.Parse(splitLine[7]));
                tires.Add(new Tire[] {tire1,tire2,tire3,tire4});
                line = Console.ReadLine();
            }
            List<Engine> engines = new List<Engine>();
            line = Console.ReadLine();
            while (line != "Engines done")
            {
                string[] splitLine = line.Split(' ');
                engines.Add(new Engine(int.Parse(splitLine[0]),double.Parse(splitLine[1])));
                line = Console.ReadLine();
            }

            line = Console.ReadLine();
            List<Car> specialCars = new List<Car>();
            while (line != "Show special")
            {
                string[] splitLine = line.Split(' ');
                string make = splitLine[0];
                string model = splitLine[1];
                int year = int.Parse(splitLine[2]);
                double fuelQuantity = double.Parse(splitLine[3]);
                double fuelConsumption = double.Parse(splitLine[4]);
                Engine engineIndex = engines[int.Parse(splitLine[5])];
                Tire[] tireIndex = tires[int.Parse(splitLine[6])];
                Car car = new Car(make,model,year,fuelQuantity,fuelConsumption,engineIndex,tireIndex);
                specialCars.Add(car);
                line = Console.ReadLine();
            }

            Console.WriteLine(SpecialCar(specialCars));
        }

        public static string SpecialCar(List<Car> cars)
        {
            List<Car> spcialCars = cars
                .Where(x => x.Year >= 2017)
                .Where(x => x.Engine.HorsePower > 330)
                .Where(x => x.Tires.Sum(y => y.Pressure) >= 9 && x.Tires.Sum(y => y.Pressure) <= 10)
                .ToList();
            StringBuilder result = new StringBuilder();
            foreach (var car in spcialCars)
            {
                car.Drive(20);
                result.AppendLine($"Make: {car.Make}");
                result.AppendLine($"Model: {car.Model}");
                result.AppendLine($"Year: {car.Year}");
                result.AppendLine($"HorsePowers: {car.Engine.HorsePower}");
                result.AppendLine($"FuelQuantity: {car.FuelQuantity}");
            }
            return result.ToString();
        }
    }
}
