using System;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public Car()
        {
            
        }

        public Car(string model,double fuelAmount,double fuelConsumptionPerKilometer):this()
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }
        public string Model { get { return this.model;} set { this.model = value; } } 
        public double FuelAmount { get { return this.fuelAmount; } set { this.fuelAmount = value; } }

        public double FuelConsumptionPerKilometer { get { return this.fuelConsumptionPerKilometer; } set { this.fuelConsumptionPerKilometer = value; } }

        public double TravelledDistance { get { return this.travelledDistance; } set { this.travelledDistance = value; } }

        public void Driving(double distance)
        {
            double neededFuel = FuelConsumptionPerKilometer * distance;
            if (FuelAmount - neededFuel >= 0)
            {
                FuelAmount -= neededFuel;
                TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

    }
}
