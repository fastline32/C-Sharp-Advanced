using System;

namespace Parking
{
    public class StartUp
    {
        static void Main()
        {
            Parking parking = new Parking("Underground parking garage", 5);

            Car volvo = new Car("Volvo", "XC70", 2010);

            Console.WriteLine(volvo);

            parking.Add(volvo);

            Console.WriteLine(parking.Remove("Volvo", "XC90"));
            Console.WriteLine(parking.Remove("Volvo", "XC70"));

            Car peugeot = new Car("Peugeot", "307", 2011);
            Car audi = new Car("Audi", "S4", 2005);

            parking.Add(peugeot);
            parking.Add(audi);

            Car latestCar = parking.GetLatestCar();
            
            Console.WriteLine(latestCar); // Peugeot 307 (2011)

            Car audiS4 = parking.GetCar("Audi", "S4");
            Console.WriteLine(audiS4); // Audi S4 (2005)

            Console.WriteLine(parking.Count); // 2

            Console.WriteLine(parking.GetStatistics());
        }
    }
}
