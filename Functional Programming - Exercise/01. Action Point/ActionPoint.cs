using System;

namespace _01._Action_Point
{
    internal class ActionPoint
    {
        static void Main()
        {
            Action<string[]> printElement = x => Console.WriteLine(string.Join(Environment.NewLine, x));
            string[] names = Console.ReadLine()!.Split();
            printElement(names);
        }
    }
}
