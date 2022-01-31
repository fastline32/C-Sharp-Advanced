using System;

namespace _02._Knights_of_Honor
{
    public class KnightsOfHonor
    {
        static void Main()
        {
            Action<string[]> printNames = x => Console.Write("Sir " + String.Join(Environment.NewLine + "Sir ", x));

            string[] names = Console.ReadLine()!.Split();
            printNames(names);
        }
    }
}
