using System;
using System.Collections.Generic;
using System.Linq;

namespace Radioactive_Mutant_Vampire_Bunnies
{
    internal class RadioactiveMutantVampireBunnies
    {
        static void Main()
        {
            int[] line = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
            int row = line[0];
            int col = line[1];
            char[,] field = new char[row, col];
            field = FillUpField(row, col);

            int playerRow = FindPlayerRow(field, row, col);
            int playerCol = FindPlayerCol(field, row, col);
            char[] commands = Console.ReadLine()!.ToCharArray();
            Queue<int[]> bunnies = new Queue<int[]>();
            bunnies = bunnyPosition(field);
            for (int i = 0; i < commands.Length; i++)
            {
                if (CheckIfAlive(field))
                {
                    switch (commands[i])
                    {
                        case 'U':
                            if (playerRow - 1 < 0)
                            {
                                field[playerRow, playerCol] = '.';
                                MultiplayBunny(field, bunnies);
                                PrintField(field);
                                Console.WriteLine($"won: 0 {playerCol}");
                                return;
                            }
                            else if (playerRow - 1 >= 0 && field[playerRow - 1, playerCol] == 'B')
                            {
                                field[playerRow, playerCol] = '.';
                                playerRow--;
                                MultiplayBunny(field, bunnies);
                                PrintField(field);
                                Console.WriteLine($"dead: {playerRow} {playerCol}");
                                return;
                            }
                            else if (playerRow - 1 >= 0 && field[playerRow - 1, playerCol] == '.')
                            {
                                field[playerRow - 1, playerCol] = 'P';
                                field[playerRow, playerCol] = '.';
                                playerRow--;
                                MultiplayBunny(field, bunnies);
                                bunnies = bunnyPosition(field);
                                CheckIfAlive(field);
                            }
                            ; break;
                        case 'L':
                            if (playerCol - 1 < 0 )
                            {
                                field[playerRow, playerCol] = '.';
                                MultiplayBunny(field, bunnies);
                                PrintField(field);
                                Console.WriteLine($"won: {playerRow} 0");
                                return;
                            }
                            else if (playerCol - 1 >= 0 && field[playerRow, playerCol -1] == 'B')
                            {
                                field[playerRow, playerCol] = '.';
                                playerCol--;
                                MultiplayBunny(field, bunnies);
                                PrintField(field);
                                Console.WriteLine($"dead: {playerRow} {playerCol}");
                                return;
                            }
                            else if (playerCol - 1 >= 0 && field[playerRow , playerCol - 1] == '.')
                            {
                                field[playerRow, playerCol - 1] = 'P';
                                field[playerRow, playerCol] = '.';
                                playerCol--;
                                MultiplayBunny(field, bunnies);
                                bunnies = bunnyPosition(field);
                                CheckIfAlive(field);
                            }
                            ; break;
                        case 'R':
                            if (playerCol + 1 >= col)
                            {
                                field[playerRow, playerCol] = '.';
                                MultiplayBunny(field, bunnies);
                                PrintField(field);
                                Console.WriteLine($"won: {playerRow} {col-1}");
                                return;
                            }
                            else if (playerCol + 1 <= col -1 && field[playerRow, playerCol + 1] == 'B')
                            {
                                field[playerRow, playerCol] = '.';
                                playerCol++;
                                MultiplayBunny(field, bunnies);
                                PrintField(field);
                                Console.WriteLine($"dead: {playerRow} {playerCol}");
                                return;
                            }
                            else if (playerCol + 1 < col && field[playerRow, playerCol + 1] == '.')
                            {
                                field[playerRow, playerCol + 1] = 'P';
                                field[playerRow, playerCol] = '.';
                                playerCol++;
                                MultiplayBunny(field, bunnies);
                                bunnies = bunnyPosition(field);
                                CheckIfAlive(field);
                            }
                            ; break;
                        case 'D':
                            if (playerRow + 1 >= row)
                            {
                                field[playerRow, playerCol] = '.';
                                MultiplayBunny(field, bunnies);
                                PrintField(field);
                                Console.WriteLine($"won: {row -1} {playerCol}");
                                return;
                            }
                            else if (playerRow + 1 > row && field[playerRow +1, playerCol] == 'B')
                            {
                                field[playerRow, playerCol] = '.';
                                playerRow++;
                                MultiplayBunny(field, bunnies);
                                PrintField(field);
                                Console.WriteLine($"dead: {playerRow} {playerCol}");
                                return;
                            }
                            else if (playerRow + 1 < row && field[playerRow + 1, playerCol] == '.')
                            {
                                field[playerRow + 1, playerCol] = 'P';
                                field[playerRow, playerCol] = '.';
                                playerRow++;
                                MultiplayBunny(field, bunnies);
                                bunnies = bunnyPosition(field);
                                CheckIfAlive(field);
                            }
                            ; break;
                    }
                }
                else
                {
                    PrintField(field);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }
            }
        }

        static char[,] FillUpField(int row, int col)
        {
            char[,] field = new char[row, col];
            for (int i = 0; i < row; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < col; j++)
                {
                    field[i, j] = line[j];
                }
            }
            return field;
        }

        static int FindPlayerRow(char[,] arr, int row, int col)
        {
            int playerRow = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (arr[i,j] == 'P')
                    {
                        playerRow = i;
                    }
                }
            }
            return playerRow;
        }

        static int FindPlayerCol(char[,] arr, int row, int col)
        {
            int playerRow = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (arr[i, j] == 'P')
                    {
                        playerRow = j;
                    }
                }
            }
            return playerRow;
        }

        static Queue<int[]> bunnyPosition(char[,] arr)
        {
            Queue<int[]> bunnies = new Queue<int[]>();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i,j] == 'B')
                    {
                        bunnies.Enqueue(new []{i,j});
                    }
                }
            }

            return bunnies;
        }

        static char[,] MultiplayBunny(char[,] arr, Queue<int[]> bunny)
        {
            Queue < Tuple<int, int>> bunnyPosition = new Queue<Tuple<int, int>>();
            bunnyPosition.Enqueue(new Tuple<int, int>(-1,0));
            bunnyPosition.Enqueue(new Tuple<int, int>(0,-1));
            bunnyPosition.Enqueue(new Tuple<int, int>(1,0));
            bunnyPosition.Enqueue(new Tuple<int, int>(0,1));
            int count = bunny.Count;
            for (int i = 0; i < count; i++)
            {
                int[] stats = bunny.Dequeue();
                int row = stats[0];
                int col = stats[1];
                for (int j = 0; j < bunnyPosition.Count; j++)
                {
                    int bunnyRow = bunnyPosition.Peek().Item1;
                    int bunnyCol = bunnyPosition.Peek().Item2;
                    bunnyPosition.Enqueue(bunnyPosition.Dequeue());
                    try
                    {
                        arr[row + bunnyRow, col + bunnyCol] = 'B';
                    }
                    catch (Exception)
                    {
                       continue;
                    }
                }
            }
            return arr;
        }

        static void PrintField(char[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i,j]);
                }
                Console.WriteLine();
            }
        }

        static bool CheckIfAlive(char[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i,j]=='P')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
