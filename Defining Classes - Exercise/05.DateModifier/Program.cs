using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DateTime StartDate = DateTime.Parse(Console.ReadLine());
            DateTime EndDate = DateTime.Parse(Console.ReadLine());
            double difference = DateModifier.CalculateDates(StartDate,EndDate);

            Console.WriteLine(Math.Abs(difference));
        }
    }
}
