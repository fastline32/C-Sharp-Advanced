using System;
using System.Linq;

namespace Sum_Numbers
{
    internal class SumNumbers
    {
        static void Main()
        {
            string line = Console.ReadLine();
            int[] newline = Parser(line);
            Console.WriteLine(newline.Length);
            Console.WriteLine(newline.Sum());
        }

        public static int[] Parser(string line)
        {
            int[] parsed = line.Split(", ").Select(int.Parse).ToArray();

            return parsed;
        }
    }
}
