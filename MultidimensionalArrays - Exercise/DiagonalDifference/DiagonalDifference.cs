using System;
using System.Linq;

namespace DiagonalDifference
{
    internal class DiagonalDifference
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine() ?? string.Empty);
            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                int[] nums = Console.ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = nums[col];
                }
            }

            int firstDiagonal = 0;
            int secondDiagonal = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = row; col <= row; col++)
                {
                    firstDiagonal += matrix[row, col];
                }
            }
            for (int row = 0; row < n; row++)
            {
                for (int col = n - row - 1; col <= n - row - 1; col++)
                {
                    secondDiagonal += matrix[row, col];
                }
            }

            int sum = Math.Abs(firstDiagonal - secondDiagonal);

            Console.WriteLine(sum);
        }
    }
}
