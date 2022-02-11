using System;
using System.Collections.Generic;

namespace Selling
{
    public class ProgramA
    {
        static void Main(string[] args)
        {
            int sizeOfsquareMatrix = int.Parse(Console.ReadLine());
            int rows = sizeOfsquareMatrix;
            int cols = sizeOfsquareMatrix;
            char[,] squareMatrix = new char[rows, cols];
            int playerRow = -1;
            int playerCol = -1;
            int collectedMoney = 0;
            List<int[]> pillars = new List<int[]>();

            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                char[] inputFill = Console.ReadLine().ToCharArray();

                for (int col = 0; col < squareMatrix.GetLength(1); col++)
                {
                    squareMatrix[row, col] = inputFill[col];
                    if (squareMatrix[row, col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    if (squareMatrix[row, col] == 'O')
                    {
                        pillars.Add(new[] { row, col });
                    }
                }
            }
            MoveForward(ref collectedMoney, squareMatrix, playerRow, playerCol, pillars);

            if (collectedMoney >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {collectedMoney}");
            PrintMatrix(squareMatrix);
        }

        private static void MoveForward(ref int collectedMoney, char[,] squareMatrix, int playerRow, int playerCol,
            List<int[]> pillars)
        {
            bool isInBakery = true;
            while (collectedMoney < 50 && isInBakery)
            {
                string command = Console.ReadLine();
                squareMatrix[playerRow, playerCol] = '-';

                if (command == "up")
                {
                    if (IsValidIndex(playerRow - 1, playerCol, squareMatrix))
                    {
                        playerRow -= 1;
                        if (char.IsDigit(squareMatrix[playerRow, playerCol]))
                        {
                            collectedMoney += int.Parse(squareMatrix[playerRow, playerCol].ToString());
                        }
                        else if (squareMatrix[playerRow, playerCol] == 'O')
                        {
                            foreach (var currentPilar in pillars)
                            {
                                int currentRow = currentPilar[0];
                                int currentCol = currentPilar[1];
                                squareMatrix[currentRow, currentCol] = '-';
                            }

                            int[] newIndexes = pillars[1];
                            int newRow = newIndexes[0];
                            int newCol = newIndexes[1];
                            squareMatrix[newRow, newCol] = 'S';
                            playerRow = newRow;
                            playerCol = newCol;
                        }

                        squareMatrix[playerRow, playerCol] = 'S';
                    }
                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        isInBakery = false;
                    }
                }
                else if (command == "down")
                {
                    if (IsValidIndex(playerRow + 1, playerCol, squareMatrix))
                    {
                        playerRow += 1;
                        if (char.IsDigit(squareMatrix[playerRow, playerCol]))
                        {
                            collectedMoney += int.Parse(squareMatrix[playerRow, playerCol].ToString());
                        }
                        else if (squareMatrix[playerRow, playerCol] == 'O')
                        {
                            foreach (var currentPilar in pillars)
                            {
                                int currentRow = currentPilar[0];
                                int currentCol = currentPilar[1];
                                squareMatrix[currentRow, currentCol] = '-';
                            }

                            int[] newIndexes = pillars[1];
                            int newRow = newIndexes[0];
                            int newCol = newIndexes[1];
                            squareMatrix[newRow, newCol] = 'S';
                            playerRow = newRow;
                            playerCol = newCol;
                        }

                        squareMatrix[playerRow, playerCol] = 'S';
                    }
                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        isInBakery = false;
                    }
                }
                else if (command == "right")
                {
                    if (IsValidIndex(playerRow, playerCol + 1, squareMatrix))
                    {
                        playerCol += 1;
                        if (char.IsDigit(squareMatrix[playerRow, playerCol]))
                        {
                            collectedMoney += int.Parse(squareMatrix[playerRow, playerCol].ToString());
                        }
                        else if (squareMatrix[playerRow, playerCol] == 'O')
                        {
                            foreach (var currentPilar in pillars)
                            {
                                int currentRow = currentPilar[0];
                                int currentCol = currentPilar[1];
                                squareMatrix[currentRow, currentCol] = '-';
                            }

                            int[] newIndexes = pillars[1];
                            int newRow = newIndexes[0];
                            int newCol = newIndexes[1];
                            squareMatrix[newRow, newCol] = 'S';
                            playerRow = newRow;
                            playerCol = newCol;
                        }

                        squareMatrix[playerRow, playerCol] = 'S';
                    }
                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        isInBakery = false;
                    }
                }
                else if (command == "left")
                {
                    if (IsValidIndex(playerRow, playerCol - 1, squareMatrix))
                    {
                        playerCol -= 1;
                        if (char.IsDigit(squareMatrix[playerRow, playerCol]))
                        {
                            collectedMoney += int.Parse(squareMatrix[playerRow, playerCol].ToString());
                        }
                        else if (squareMatrix[playerRow, playerCol] == 'O')
                        {
                            foreach (var currentPilar in pillars)
                            {
                                int currentRow = currentPilar[0];
                                int currentCol = currentPilar[1];
                                squareMatrix[currentRow, currentCol] = '-';
                            }

                            int[] newIndexes = pillars[1];
                            int newRow = newIndexes[0];
                            int newCol = newIndexes[1];
                            squareMatrix[newRow, newCol] = 'S';
                            playerRow = newRow;
                            playerCol = newCol;
                        }

                        squareMatrix[playerRow, playerCol] = 'S';
                    }
                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        isInBakery = false;
                    }
                }
            }
        }

        private static void PrintMatrix(char[,] squareMatrix)
        {
            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < squareMatrix.GetLength(1); col++)
                {
                    Console.Write(squareMatrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static bool IsValidIndex(int row, int col, char[,] squareMatrix)
        {
            return row >= 0 && row < squareMatrix.GetLength(0) && col >= 0 && col < squareMatrix.GetLength(1);
        }
    }
}