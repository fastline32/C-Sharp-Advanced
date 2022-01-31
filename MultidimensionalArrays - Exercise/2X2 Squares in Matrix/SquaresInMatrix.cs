using System;
using System.Linq;

namespace _2X2_Squares_in_Matrix
{
    internal class SquaresInMatrix
    {
        static void Main()
        {
            int[] n = Console.ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrix = new char [n[0],n[1]];
            for (int i = 0; i < n[0]; i++)
            {
                char[] chars = Console.ReadLine()!.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int j = 0; j < chars.Length; j++)
                {
                    matrix[i, j] = chars[j];
                }
            }

            int squares = 0;
            for (int row = 0; row < n[0] -1; row++)
            {
                for (int col = 0; col < n[1]-1; col++)
                {
                    if (matrix[row,col] == matrix[row,col+1] && matrix[row,col] == matrix[row+1,col] && matrix[row,col] == matrix[row+1,col+1])
                    {
                        squares++;
                    }
                }
            }
            Console.WriteLine(squares);
        }
    }
}
