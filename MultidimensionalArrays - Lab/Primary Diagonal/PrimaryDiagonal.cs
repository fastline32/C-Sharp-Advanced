using System;
using System.Linq;

namespace Primary_Diagonal
{
    internal class PrimaryDiagonal
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine()!);
            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                int[] input = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += matrix[i, i];
            }

            Console.WriteLine(sum);
        }
    }
}
