using System;
using System.Collections.Generic;
using System.Linq;

namespace Parking_Lot
{
    internal class ParkingLot
    {
        static void Main()
        {
            string[] line = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string command = line[0];
            HashSet<string> cars = new HashSet<string>();
            while (command != "END")
            {
                string input = line[0];
                string carNumber = line[1];

                if (input == "IN")
                {
                    cars.Add(carNumber);
                }
                else if (input == "OUT" && cars.Contains(carNumber))
                {
                    cars.Remove(carNumber);
                }
                line = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                command = line[0];
            }

            if (cars.Count != 0)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
