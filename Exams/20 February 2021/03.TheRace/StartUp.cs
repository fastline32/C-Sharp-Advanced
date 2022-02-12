using System;

namespace TheRace
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Initialize the repository
            Race race = new Race("Indianapolis 500", 10);

            //Initialzie cars
            Car car1 = new Car("ferrari", 150);
            Car car2 = new Car("lambo", 170);

            //Initialize racer1
            Racer racer1 = new Racer("Stephen", 40, "Bulgaria", car1);

            //Print Racer
            Console.WriteLine(racer1); //Racer: Stephen, 40 (Bulgaria)

            //Add Racer
            race.Add(racer1);

        }
    }
}
