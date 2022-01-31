using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car()
        {
            
        }

        public Car(string model,Engine engine,Cargo cargo, Tire[] tires) : this()
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }
        public string Model { get { return this.model;} set { this.model = value; } }

        public Engine Engine { get { return this.engine;} set { this.engine = value; } }

        public Cargo Cargo { get { return this.cargo; } set { this.cargo = value; } }

        public Tire[] Tires { get { return this.tires;} set { this.tires = value; } }

        public void AddCar(List<Car>cars ,string line)
        {
            string[] inputData = line.Split();
            string model = inputData[0];
            Engine engine = new Engine(int.Parse(inputData[1]), int.Parse(inputData[2]));
            Cargo cargo = new Cargo(inputData[4], int.Parse(inputData[3]));
            Tire[] tires = new Tire[4];
            tires[0] = new Tire(double.Parse(inputData[5]), int.Parse(inputData[6]));
            tires[1] = new Tire(double.Parse(inputData[7]), int.Parse(inputData[8]));
            tires[2] = new Tire(double.Parse(inputData[9]), int.Parse(inputData[10]));
            tires[3] = new Tire(double.Parse(inputData[11]), int.Parse(inputData[12]));

            Car car = new Car(model, engine, cargo, tires);
            cars.Add(car);
        }

        public static void Print(string type,List<Car> cars)
        {
            if (type == "flammable")
            {
                cars = cars.Where(x => x.Cargo.Type == "flammable" && x.Engine.Power > 250).ToList();
                foreach (var car in cars)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (type == "fragile")
            {
                cars = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(x => x.Pressure < 1)).ToList();
                foreach (var car in cars)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
