using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine()!);
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();
                Car car = new Car(line[0], double.Parse(line[1]), double.Parse(line[2]));
                cars.Add(car);
            }

            string inputData = Console.ReadLine();
            while (inputData != "End")
            {
                string[] line = inputData.Split();
                string model = line[1];
                double distance = double.Parse(line[2]);

                Car drivingCar = cars.Where(x => x.Model == model).ToList().First();
                drivingCar.Driving(distance);
                inputData = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
