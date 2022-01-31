using System;
using System.Linq;

namespace MaximalSum
{
    internal class MaximalSum
    {
        static void Main()
        {
            int[] options = Console.ReadLine()!.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[,] matrix = new int[options[0], options[1]];
            int currentRow = 0;
            int currentCol = 0;
            int maxSum = 0;
            for (int row = 0; row < options[0]; row++)
            {
                int[] numbers = Console.ReadLine()!.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < options[1]; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            for (int row = 0; row < options[0] - 2; row++)
            {
                for (int col = 0; col < options[1] - 2; col++)
                {
                    if (CurrentSum(matrix, row, col) > maxSum)
                    {
                        maxSum = CurrentSum(matrix, row, col);
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            Console.Write(matrix[currentRow, currentCol]);
            Console.Write($" {matrix[currentRow, currentCol + 1]}");
            Console.WriteLine($" {matrix[currentRow, currentCol + 2]}");
            Console.Write(matrix[currentRow + 1, currentCol]);
            Console.Write($" {matrix[currentRow + 1, currentCol + 1]}");
            Console.WriteLine($" {matrix[currentRow + 1, currentCol + 2]}");
            Console.Write(matrix[currentRow + 2, currentCol]);
            Console.Write($" {matrix[currentRow + 2, currentCol + 1]}");
            Console.WriteLine($" {matrix[currentRow + 2, currentCol + 2]}");
            
        }

        static int CurrentSum(int[,] matrix, int row, int col)
        {
            int sum = 0;
            sum += matrix[row, col];
            sum += matrix[row, col + 1];
            sum += matrix[row, col + 2];
            sum += matrix[row + 1, col];
            sum += matrix[row + 1, col + 1];
            sum += matrix[row + 1, col + 2];
            sum += matrix[row + 2, col];
            sum += matrix[row + 2, col + 1];
            sum += matrix[row + 2, col + 2];
            return sum;
        }
    }
}
