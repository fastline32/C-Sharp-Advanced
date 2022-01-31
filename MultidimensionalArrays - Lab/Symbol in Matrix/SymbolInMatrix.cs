using System;

namespace Symbol_in_Matrix
{
    internal class SymbolInMatrix
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine()!);
            char[,] matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine()!;
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            char item = Char.Parse(Console.ReadLine()!);

            if (CheckIfExist(matrix,item))
            {
                Console.WriteLine($"({GetRow(matrix,item)}, {GetCol(matrix,item)})");
            }
            else
            {
                Console.WriteLine($"{item} does not occur in the matrix");
            }
        }

        static bool CheckIfExist(char[,] matrix, char item)
        {
            foreach (var ch in matrix)
            {
                if (ch == item)
                {
                    return true;
                }
            }
            return false;
        }

        static int GetRow(char[,] matrix, char n)
        {
            int h = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == n)
                    {
                        h = i;
                    }
                }
            }

            return h;
        }
        static int GetCol(char[,] matrix, char n)
        {
            int h = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == n)
                    {
                        h = j;
                    }
                }
            }

            return h;
        }
    }
}