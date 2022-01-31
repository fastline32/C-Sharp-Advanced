using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()!);
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()!.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                Engine.AddEngine(engines,input);
            }
            List<Car> cars = new List<Car>();
            n = int.Parse(Console.ReadLine()!);
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
                Car.AddCar(cars,engines,input);
            }

            foreach (var car in cars)
            {
                Car.Print(car);
            }
        }
    }
}
