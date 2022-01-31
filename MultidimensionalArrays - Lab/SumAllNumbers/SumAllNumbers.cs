using System;
using System.Linq;

namespace SumAllNumbers
{
    internal class SumAllNumbers
    {
        static void Main()
        {
            int[] options = Console.ReadLine()!.Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[,] matrix = new int[options[0], options[1]];

            for (int row = 0; row < options[0]; row++)
            {
                int[] numbers = Console.ReadLine()!.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < options[1]; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int sum = 0;
            foreach (var num in matrix)
            {
                sum += num;
            }

            Console.WriteLine(options[0]);
            Console.WriteLine(options[1]);
            Console.WriteLine(sum);
        }
    }
}
