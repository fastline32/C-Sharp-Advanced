using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    internal class Bombs
    {
        static void Main()
        {
            Queue<Tuple<int, int>> damageAreaLocations = new Queue<Tuple<int, int>>();
            damageAreaLocations.Enqueue(new Tuple<int, int>(-1, -1));
            damageAreaLocations.Enqueue(new Tuple<int, int>(-1, 0));
            damageAreaLocations.Enqueue(new Tuple<int, int>(-1, 1));
            damageAreaLocations.Enqueue(new Tuple<int, int>(0, -1));
            damageAreaLocations.Enqueue(new Tuple<int, int>(0, 1));
            damageAreaLocations.Enqueue(new Tuple<int, int>(1, -1));
            damageAreaLocations.Enqueue(new Tuple<int, int>(1, 0));
            damageAreaLocations.Enqueue(new Tuple<int, int>(1, 1));

            int n = int.Parse(Console.ReadLine()!);
            int[,] bombField = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                int[] rows = Console.ReadLine()!.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    bombField[i, j] = rows[j];
                }
            }

            string[] bobms = Console.ReadLine()!.Split(' ').ToArray();

            for (int i = 0; i < bobms.Length; i++)
            {
                int[] bomb = BombCoordinats(i, bobms);
                int bombValue = bombField[bomb[0], bomb[1]];
                if (bombValue > 0)
                {
                    bombField[bomb[0], bomb[1]] = 0;
                }

                for (int j = 0; j < damageAreaLocations.Count; j++)
                {
                    int damageRow = damageAreaLocations.Peek().Item1;
                    int damageCol = damageAreaLocations.Peek().Item2;
                    damageAreaLocations.Enqueue(damageAreaLocations.Dequeue());
                    try
                    {
                        if (bombField[bomb[0] + damageRow, bomb[1] + damageCol] > 0)
                        {
                            bombField[bomb[0] + damageRow, bomb[1] + damageCol] -= bombValue;
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
            int alive = 0;
            int score = 0;
            foreach (var i in bombField)
            {
                if (i > 0 )
                {
                    score += i;
                    alive ++;
                }
            }

            Console.WriteLine($"Alive cells: {alive}");
            Console.WriteLine($"Sum: {score}");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(bombField[i,j] + " ");
                }
                Console.WriteLine();
            }

        }
        static int[] BombCoordinats(int n, string[] line)
        {
            int[] bomb = line[n].Split(',').Select(int.Parse).ToArray();
            return bomb;
        }
    }
}