using System;

namespace ReVolt
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine()!);
            char[,] field = new char[n, n];
            int commandCount = int.Parse(Console.ReadLine()!);
            int playerRow = 0;
            int playerCol = 0;
            bool isFinished = false;
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    field[i, j] = line[j];
                    if (line[j] == 'f')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            while (!isFinished && commandCount > 0)
            {
                string command = Console.ReadLine()!;
                commandCount--;
                field[playerRow, playerCol] = '-';
                if (command == "up")
                {
                    if (playerRow == 0 )
                    {
                        playerRow = n - 1;
                    }
                    else
                    {
                        playerRow--;
                    }
                }
                else if (command == "down")
                {
                    if (playerRow == n -1)
                    {
                        playerRow = 0;
                    }
                    else
                    {
                        playerRow++;
                    }
                }
                else if (command == "left")
                {
                    if (playerCol == 0)
                    {
                        playerCol = n -1;
                    }
                    else
                    {
                        playerCol--;
                    }
                }
                else if (command == "right")
                {
                    if (playerCol == n - 1)
                    {
                        playerCol = 0;
                    }
                    else
                    {
                        playerCol++;
                    }
                }

                if (field[playerRow,playerCol] == 'F')
                {
                    isFinished = true;
                    field[playerRow, playerCol] = 'f';
                    break;
                }
                if (field[playerRow, playerCol] == 'B')
                {
                    if (command == "up")
                    {
                        if (playerRow == 0)
                        {
                            playerRow = n - 1;
                        }
                        else
                        {
                            playerRow--;
                        }
                    }
                    else if (command == "down")
                    {
                        if (playerRow == n - 1)
                        {
                            playerRow = 0;
                        }
                        else
                        {
                            playerRow++;
                        }
                    }
                    else if (command == "left")
                    {
                        if (playerCol == 0)
                        {
                            playerCol = n - 1;
                        }
                        else
                        {
                            playerCol--;
                        }
                    }
                    else if (command == "right")
                    {
                        if (playerCol == n - 1)
                        {
                            playerCol = 0;
                        }
                        else
                        {
                            playerCol++;
                        }
                    }

                    field[playerRow, playerCol] = 'f';
                }
                else if (field[playerRow,playerCol] == 'T')
                {
                    if (command == "up")
                    {
                        if (playerRow == n - 1)
                        {
                            playerRow = 0;
                        }
                        else
                        {
                            playerRow++;
                        }
                    }
                    else if (command == "down")
                    {
                        if (playerRow == 0)
                        {
                            playerRow = n -1;
                        }
                        else
                        {
                            playerRow--;
                        }
                    }
                    else if (command == "left")
                    {
                        if (playerCol == n - 1)
                        {
                            playerCol = 0;
                        }
                        else
                        {
                            playerCol++;
                        }
                    }
                    else if (command == "right")
                    {
                        if (playerCol == 0)
                        {
                            playerCol = n - 1;
                        }
                        else
                        {
                            playerCol--;
                        }
                    }

                    field[playerRow, playerCol] = 'f';
                }
                else
                {
                    field[playerRow, playerCol] = 'f';
                }
            }

            if (isFinished)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(field[i,j]);
                }

                Console.WriteLine();
            }
        }
    }
}
