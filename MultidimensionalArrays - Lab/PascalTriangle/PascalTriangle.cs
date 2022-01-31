using System;

namespace PascalTriangle
{
    internal class PascalTriangle
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine()!);
            long[][] pascal = new long[n][];

            for (int i = 0; i < n; i++)
            {
                pascal[i] = new long[i + 1];
            }

            for (int row = 0; row < pascal.Length; row++)
            {
                pascal[row][0] = 1;
                pascal[row][pascal[row].Length -1] = 1;
                for (int col = 1; col < pascal[row].Length -1 ; col++)
                {
                    pascal[row][col] = pascal[row - 1][col - 1] + pascal[row - 1][col];
                }
            }

            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(String.Join(" ", pascal[row]));
            }
        }
    }
}
