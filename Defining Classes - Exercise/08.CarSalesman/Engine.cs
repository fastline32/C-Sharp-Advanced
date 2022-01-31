using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine()
        {
            this.Displacement = 0;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power) : this()
        {
            this.Model = model;
            this.Power = power;
        }

        public Engine(string model, int power,int displacement) : this(model,power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency) : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement,string efficiency) : this(model,power,displacement)
        {
            this.Efficiency = efficiency;
        }
        public string Model { get { return this.model;} set { this.model = value; } }

        public int Power { get { return this.power; } set { this.power = value; } }

        public int Displacement { get { return this.displacement; } set { this.displacement = value; } }

        public string Efficiency { get { return this.efficiency; } set { this.efficiency = value; } }

        public static void AddEngine(List<Engine> engines, string[] data)
        {
            switch (data.Length)
            {
                case 2:
                    Engine engine = new Engine(data[0], int.Parse(data[1]));
                    engines.Add(engine);break;
                case 3:
                    try
                    {
                        int displacement = int.Parse(data[2]);
                        engine = new Engine(data[0], int.Parse(data[1]), displacement);
                        engines.Add(engine); break;
                    }
                    catch
                    {
                        engine = new Engine(data[0], int.Parse(data[1]), data[2]);
                        engines.Add(engine); break;
                    }
                    
                case 4:
                    engine = new Engine(data[0], int.Parse(data[1]), int.Parse(data[2]),data[3]);
                    engines.Add(engine);break;

            }
        }

    }
}
