using System;
using System.Linq;

namespace Miner
{
    internal class Miner
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine()!);
            string[] command = Console.ReadLine()!.Split(' ').ToArray();
            char[,] mineField = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                char[] lines = Console.ReadLine()!.Split().Select(char.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    mineField[i, j] = lines[j];
                }
            }

            int startRow = GetStartPositionRow(mineField);
            int startCol = GetStartPositionCol(mineField);
            int coals = 0;
            for (int i = 0; i < command.Length; i++)
            {
                switch (command[i])
                {
                    case "up":
                        if (startRow -1 >= 0)
                        {
                            mineField[startRow, startCol] = '*';
                            if (mineField[startRow - 1, startCol] == 'c')
                            {
                                coals++;
                            }
                            else if(mineField[startRow - 1, startCol] == 'e')
                            {
                                startRow--;
                                Console.WriteLine($"Game over! ({startRow}, {startCol})");
                                return;
                            }
                            mineField[startRow - 1, startCol] = 's';
                            startRow--;
                        };break;
                    case "left":
                        if (startCol - 1 >= 0)
                        {
                            mineField[startRow, startCol] = '*';
                            if (mineField[startRow, startCol -1] == 'c')
                            {
                                coals++;
                            }
                            else if (mineField[startRow, startCol-1] == 'e')
                            {
                                startCol--;
                                Console.WriteLine($"Game over! ({startRow}, {startCol})");
                                return;
                            }
                            mineField[startRow, startCol-1] = 's';
                            startCol--;
                        }; break;
                    case "right":
                        if (startCol + 1 < n)
                        {
                            mineField[startRow, startCol] = '*';
                            if (mineField[startRow, startCol + 1] == 'c')
                            {
                                coals++;
                            }
                            else if (mineField[startRow, startCol + 1] == 'e')
                            {
                                startCol++;
                                Console.WriteLine($"Game over! ({startRow}, {startCol})");
                                return;
                            }
                            mineField[startRow, startCol + 1] = 's';
                            startCol++;
                        }; break;
                    case "down":
                        if (startRow + 1 < n)
                        {
                            mineField[startRow, startCol] = '*';
                            if (mineField[startRow + 1, startCol] == 'c')
                            {
                                coals++;
                            }
                            else if (mineField[startRow + 1, startCol] == 'e')
                            {
                                startRow++;
                                Console.WriteLine($"Game over! ({startRow}, {startCol})");
                                return;
                            }
                            mineField[startRow + 1, startCol] = 's';
                            startRow++;
                        }; break;
                }
            }

            if (FindLeftCoals(mineField) == 0)
            {
                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
            }
            else
            {
                Console.WriteLine(FindLeftCoals(mineField) + $" coals left. ({startRow}, {startCol})");
            }

        }

        static int GetStartPositionRow(char[,] arr)
        {
            int row = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i,j] == 's')
                    {
                        row = i;
                    }
                }
            }
            return row;
        }

        static int GetStartPositionCol(char[,] arr)
        {
            int col = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 's')
                    {
                        col = j;
                    }
                }
            }
            return col;
        }

        static int FindLeftCoals(char[,] arr)
        {
            int lefted = 0;
            foreach (var i in arr)
            {
                if (i == 'c')
                {
                    lefted++;
                }
            }

            return lefted;
        }
    }
}
