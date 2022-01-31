using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()!);
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                Car car = new Car();
                car.AddCar(cars,line);
            }

            string type = Console.ReadLine();
            Car.Print(type,cars);
        }
    }
}
