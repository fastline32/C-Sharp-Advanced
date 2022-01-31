using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car()
        {
            this.Weight = 0;
            this.Color = "n/a";
        }

        public Car(string model,Engine engine): this()
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine,int weight):this(model,engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color): this(model,engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model,engine,weight)
        {
            this.Color = color;
        }

        public string Model { get { return this.model;} set { this.model = value; } }
        public Engine Engine { get { return this.engine; } set { this.engine = value; } }
        public int Weight { get { return this.weight; } set { this.weight = value; } }
        public string Color { get { return this.color; } set { this.color = value; } }

        public static void AddCar(List<Car> cars, List<Engine> engines, string[] input)
        {
            switch (input.Length)
            {
                case 2:
                    Engine engine = engines.Where(x => x.Model == input[1]).ToList().First();
                    Car car = new Car(input[0], engine);
                    cars.Add(car);
                    break;
                case 3:
                    try
                    {
                        engine = engines.Where(x => x.Model == input[1]).ToList().First();
                        int weight = int.Parse(input[2]);
                        car = new Car(input[0], engine, weight);
                        cars.Add(car);
                        break;
                    }
                    catch
                    {
                        engine = engines.Where(x => x.Model == input[1]).ToList().First();
                        car = new Car(input[0], engine, input[2]);
                        cars.Add(car);
                        break;
                    }

                case 4:
                    engine = engines.Where(x => x.Model == input[1]).ToList().First();
                    car = new Car(input[0], engine, int.Parse(input[2]), input[3]);
                    cars.Add(car);
                    break;
            }
        }

        public static void Print(Car car)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{car.Model}:");
            sb.AppendLine($"  {car.Engine.Model}:");
            sb.AppendLine($"    Power: {car.Engine.Power}");
            if (car.Engine.Displacement == 0)
            {
                sb.AppendLine($"    Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"    Displacement: {car.Engine.Displacement}");
            }
            sb.AppendLine($"    Efficiency: {car.Engine.Efficiency}");
            if (car.Weight == 0)
            {
                sb.AppendLine($"  Weight: n/a");
            }
            else
            {
                sb.AppendLine($"  Weight: {car.Weight}");
            }

            sb.Append($"  Color: {car.Color}");
            Console.WriteLine(sb.ToString().Trim());

        }
    }
}
