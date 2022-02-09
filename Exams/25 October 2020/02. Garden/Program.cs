using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main()
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            int[,] garden = new int[size[0], size[1]];
            for (int row = 0; row < size[0]; row++)
            {
                for (int col = 0; col < size[1]; col++)
                {
                    garden[row, col] = 0;
                }
            }

            List<int[]> coordinates = new List<int[]>();
            string command = Console.ReadLine();
            while (command != "Bloom Bloom Plow")
            {
                int[] plantSize = command.Split().Select(int.Parse).ToArray();

                if (plantSize[0] < 0 || plantSize[0] > size[0] || plantSize[1] < 0 || plantSize[1] > size[1])
                {
                    Console.WriteLine("Invalid coordinates.");
                    command = Console.ReadLine();
                }
                else
                {
                    if (garden[plantSize[0],plantSize[1]] != 0 )
                    {
                        command = Console.ReadLine();
                    }
                    else
                    {
                        coordinates.Add(plantSize);
                        command = Console.ReadLine();
                    }
                }
            }

            BloomFields(garden,coordinates);
            Print(garden);
            
        }

        private static void BloomFields(int[,] garden, List<int[]> coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                int rows = coordinate[0];
                int cols = coordinate[1];
                for (int row = 0; row < garden.GetLength(0); row++)
                {
                    garden[row, cols]++;
                }

                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    garden[rows, col]++;
                }

                garden[rows, cols] = 1;
            }
        }

        public static void Print(int[,]field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row,col] + " ");
                }

                Console.WriteLine();
            }

        }
    }
}
