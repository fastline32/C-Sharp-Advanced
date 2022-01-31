using System;
using System.Linq;

namespace SumCols
{
    internal class SumCols
    {
        static void Main()
        {
            int[] options = Console.ReadLine()!.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[,] matrix = new int[options[0], options[1]];

            for (int row = 0; row < options[0]; row++)
            {
                int[] numbers = Console.ReadLine()!.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < options[1]; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int sum=0;
            for (int col = 0; col < options[1]; col++)
            {
                for (int row = 0; row < options[0]; row++)
                {
                    sum += matrix[row, col];
                }

                Console.WriteLine(sum);
                sum = 0;
            }
        }
    }
}
