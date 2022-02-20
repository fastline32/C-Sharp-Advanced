using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaverAtWork
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine()!);
            char[,] field = new char[n, n];

            int beaverRow = 0;
            int beaverCol = 0;
            List<char> woodForCollect = new List<char>();
            for (int row = 0; row < n; row++)
            {

                char[] line = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = line[col];
                    if (line[col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }

                    if (Char.IsLower(line[col]))
                    {
                        woodForCollect.Add(line[col]);
                    }

                }
            }

            List<char> collectedWood = new List<char>();
            string command = Console.ReadLine();
            while (command != "end" && woodForCollect.Count > 0)
            {
                if (!CanMove(n,beaverRow,beaverCol,command))
                {
                    if (collectedWood.Count > 0)
                    {
                        collectedWood.RemoveAt(collectedWood.Count -1);
                    }
                }
                else
                {
                    field[beaverRow, beaverCol] = '-';
                    if (command == "up")
                    {
                        beaverRow--;
                        if (Char.IsLower(field[beaverRow,beaverCol]))
                        {
                            collectedWood.Add(field[beaverRow, beaverCol]);
                            woodForCollect.Remove(field[beaverRow, beaverCol]);
                            if (woodForCollect.Count==0)
                            {
                                field[beaverRow, beaverCol] = 'B';
                                Console.WriteLine($"The Beaver successfully collect {collectedWood.Count} wood branches: {string.Join(", ", collectedWood)}.");
                                break;
                            }
                            field[beaverRow, beaverCol] = 'B';
                        }
                        else if (field[beaverRow, beaverCol] == 'F')
                        {
                            field[beaverRow, beaverCol] = '-';
                            MoveFish(n, field,ref beaverRow, ref beaverCol, command);
                            if (Char.IsLower(field[beaverRow, beaverCol]))
                            {
                                collectedWood.Add(field[beaverRow, beaverCol]);
                                field[beaverRow, beaverCol] = 'B';
                            }
                            else
                            {
                                field[beaverRow, beaverCol] = 'B';
                            }
                        }
                        else
                        {
                            field[beaverRow, beaverCol] = 'B';
                        }
                    }
                    if (command == "down")
                    {
                        beaverRow++;
                        if (Char.IsLower(field[beaverRow, beaverCol]))
                        {
                            collectedWood.Add(field[beaverRow, beaverCol]);
                            woodForCollect.Remove(field[beaverRow, beaverCol]);
                            if (woodForCollect.Count == 0)
                            {
                                field[beaverRow, beaverCol] = 'B';
                                Console.WriteLine($"The Beaver successfully collect {collectedWood.Count} wood branches: {string.Join(", ", collectedWood)}.");
                                break;
                            }
                            field[beaverRow, beaverCol] = 'B';
                        }
                        else if (field[beaverRow, beaverCol] == 'F')
                        {
                            field[beaverRow, beaverCol] = '-';
                            MoveFish(n, field, ref beaverRow, ref beaverCol, command);
                            if (Char.IsLower(field[beaverRow, beaverCol]))
                            {
                                collectedWood.Add(field[beaverRow, beaverCol]);
                                field[beaverRow, beaverCol] = 'B';
                            }
                            else
                            {
                                field[beaverRow, beaverCol] = 'B';
                            }
                        }
                        else
                        {
                            field[beaverRow, beaverCol] = 'B';
                        }
                    }
                    if (command == "left")
                    {
                        beaverCol--;
                        if (Char.IsLower(field[beaverRow, beaverCol]))
                        {
                            collectedWood.Add(field[beaverRow, beaverCol]);
                            woodForCollect.Remove(field[beaverRow, beaverCol]);
                            if (woodForCollect.Count == 0)
                            {
                                field[beaverRow, beaverCol] = 'B';
                                Console.WriteLine($"The Beaver successfully collect {collectedWood.Count} wood branches: {string.Join(", ", collectedWood)}.");
                                break;
                            }
                            field[beaverRow, beaverCol] = 'B';
                        }
                        else if (field[beaverRow, beaverCol] == 'F')
                        {
                            field[beaverRow, beaverCol] = '-';
                            MoveFish(n, field, ref beaverRow, ref beaverCol, command);
                            if (Char.IsLower(field[beaverRow, beaverCol]))
                            {
                                collectedWood.Add(field[beaverRow, beaverCol]);
                                field[beaverRow, beaverCol] = 'B';
                            }
                            else
                            {
                                field[beaverRow, beaverCol] = 'B';
                            }
                        }
                        else
                        {
                            field[beaverRow, beaverCol] = 'B';
                        }
                    }
                    if (command == "right")
                    {
                        beaverCol++;
                        if (Char.IsLower(field[beaverRow, beaverCol]))
                        {
                            collectedWood.Add(field[beaverRow, beaverCol]);
                            woodForCollect.Remove(field[beaverRow, beaverCol]);
                            if (woodForCollect.Count == 0)
                            {
                                field[beaverRow, beaverCol] = 'B';
                                Console.WriteLine($"The Beaver successfully collect {collectedWood.Count} wood branches: {string.Join(", ", collectedWood)}.");
                                break;
                            }
                            field[beaverRow, beaverCol] = 'B';
                        }
                        else if (field[beaverRow, beaverCol] == 'F')
                        {
                            field[beaverRow, beaverCol] = '-';
                            MoveFish(n, field, ref beaverRow, ref beaverCol, command);
                            if (Char.IsLower(field[beaverRow, beaverCol]))
                            {
                                collectedWood.Add(field[beaverRow, beaverCol]);
                                field[beaverRow, beaverCol] = 'B';
                            }
                            else
                            {
                                field[beaverRow, beaverCol] = 'B';
                            }
                        }
                        else
                        {
                            field[beaverRow, beaverCol] = 'B';
                        }
                    }
                }

                command = Console.ReadLine();
            }

            if (command == "end" && woodForCollect.Count > 0)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {woodForCollect.Count} branches left.");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(field[row,col]+ " ");
                }

                Console.WriteLine();
            }
        }

        private static void MoveFish(int i, char[,] field,ref int beaverRow,ref int beaverCol, string command)
        {
            if (command == "up" && beaverRow > 0)
            {
                beaverRow = 0;
                return;
            }
            else
            {
                beaverRow = i - 1;
                return;
            }
            if (command == "down" && beaverRow < i -1)
            {
                beaverRow = i -1;
                return;
            }
            else
            {
                beaverRow = 0;
                return;
            }
            if (command == "left" && beaverCol > 0)
            {
                beaverCol = 0;
                return;
            }
            else
            {
                beaverCol = i -1;
                return;
            }
            if (command == "right" && beaverCol < i - 1)
            {
                beaverCol = i - 1;
                return;
            }
            else
            {
                beaverCol = 0;
                return;
            }

        }

        public static bool CanMove(int n,int row, int col, string command)
        {
            if (command == "up" && row - 1 >= 0)
            {
                return true;
            }

            if (command == "down" && row + 1 < n)
            {
                return true;
            }

            if (command == "left" && col - 1 >= 0)
            {
                return true;
            }

            if (command == "right" && col + 1 < n)
            {
                return true;
            }

            return false;
        }
    }
}
