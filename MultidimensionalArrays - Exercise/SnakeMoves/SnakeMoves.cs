using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMoves
{
    class SnakeMoves
    {
        static void Main()
        {
            int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string inputWord = Console.ReadLine();
            char[,] matrix = new char[size[0], size[1]];
            Queue<char> sign = new Queue<char>();
            foreach (var item in inputWord)
            {
                sign.Enqueue(item);
            }
            for (int i = 0; i < size[0]; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < size[1]; j++)
                    {
                        matrix[i, j] = sign.Peek();
                        sign.Enqueue(sign.Dequeue());
                    }
                }
                else
                {
                    for (int j = size[1] - 1; j >= 0; j--)
                    {
                        matrix[i, j] = sign.Peek();
                        sign.Enqueue(sign.Dequeue());
                    }
                }
            }
            for (int i = 0; i < size[0]; i++)
            {
                for (int j = 0; j < size[1]; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}