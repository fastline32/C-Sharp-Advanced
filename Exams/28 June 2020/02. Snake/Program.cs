using System;
using System.Runtime.InteropServices.ComTypes;

namespace Snake
{
    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] snakeField = new char[size,size];

            for (int row = 0; row < size; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    snakeField[row, col] = line[col];
                }
            }

            int snakeRow = GetRow(snakeField, 'S');
            int snakeCol = GetCol(snakeField, 'S');

            int countCommand = 0;
            int food = 0;
            while (food < 10)
            {
                if (IfExist(snakeField))
                {
                    string command = Console.ReadLine();
                    countCommand++;
                    snakeRow = GetRow(snakeField, 'S');
                    snakeCol = GetCol(snakeField, 'S');
                    if (CheckIfSpecial(snakeField, snakeRow, snakeCol, '*', command))
                    {
                        food++;
                        MoveSnake(snakeField, snakeRow, snakeCol, command);
                    }

                    else if (CheckIfSpecial(snakeField, snakeRow, snakeCol, 'B', command))
                    {
                        MoveSnake(snakeField, snakeRow, snakeCol, command);
                        snakeRow = GetRow(snakeField, 'S');
                        snakeCol = GetCol(snakeField, 'S');

                        snakeField[snakeRow, snakeCol] = '.';
                        snakeRow = GetRow(snakeField, 'B');
                        snakeCol = GetCol(snakeField, 'B');
                        snakeField[snakeRow, snakeCol] = 'S';
                    }
                    else if (CheckIfIsMatrix(snakeField, snakeRow, snakeCol))
                    {
                        MoveSnake(snakeField, snakeRow, snakeCol, command);
                        snakeRow = GetRow(snakeField, 'S');
                        snakeCol = GetCol(snakeField, 'S');
                    }
                    else
                    {
                        Console.WriteLine("Game over!");
                        Console.WriteLine($"Food eaten: {food}");
                    }
                }
                else
                {
                    Console.WriteLine("Game over!");
                    Console.WriteLine($"Food eaten: {food}");
                    PrintField(snakeField);
                    return;
                }
            }

            Console.WriteLine("You won! You fed the snake.");
            Console.WriteLine($"Food eaten: {food}");
            PrintField(snakeField);
        }

        private static bool IfExist(char[,] snakeField)
        {
            foreach (var item in snakeField)
            {
                if (item == 'S')
                {
                    return true;
                }
            }

            return false;
        }

        private static void MoveSnake(char[,] snakeField, int snakeRow, int snakeCol , string command)
        {
            snakeField[snakeRow, snakeCol] = '.';
            switch (command)
            {
                case "left":
                    if (CheckIfIsMatrix(snakeField,snakeRow,snakeCol -1))
                    {
                        snakeField[snakeRow, snakeCol - 1] = 'S';
                    }
                    else
                    {
                        snakeField[snakeRow, snakeCol] = '.';
                    }
                    break;
                case "right":
                    if (CheckIfIsMatrix(snakeField, snakeRow, snakeCol + 1))
                    {
                        snakeField[snakeRow, snakeCol + 1] = 'S';
                    }
                    else
                    {
                        snakeField[snakeRow, snakeCol] = '.';
                    } break;
                case "up":
                    if (CheckIfIsMatrix(snakeField, snakeRow -1, snakeCol))
                    {
                        snakeField[snakeRow - 1, snakeCol] = 'S';
                    }
                    else
                    {
                        snakeField[snakeRow, snakeCol] = '.';
                    } break;
                case "down":
                    if (CheckIfIsMatrix(snakeField, snakeRow +1 , snakeCol))
                    {
                        snakeField[snakeRow + 1, snakeCol ] = 'S';
                    }
                    else
                    {
                        snakeField[snakeRow, snakeCol] = '.';
                    }
                    break;
            }
        }

        private static bool CheckIfSpecial(char[,]snakeField, int snakeRow, int snakeCol, char item, string command)
        {
            switch (command)
            {
                case "left":
                    if (CheckIfIsMatrix(snakeField,snakeRow,snakeCol -1))
                    {
                        if (snakeField[snakeRow, snakeCol - 1] == item)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case "right":
                    if (CheckIfIsMatrix(snakeField, snakeRow, snakeCol + 1))
                    {
                        if (snakeField[snakeRow, snakeCol + 1] == item)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case "up":
                    if (CheckIfIsMatrix(snakeField, snakeRow -1, snakeCol))
                    {
                        if (snakeField[snakeRow - 1, snakeCol] == item)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case "down":
                    if (CheckIfIsMatrix(snakeField, snakeRow + 1, snakeCol))
                    {
                        if (snakeField[snakeRow + 1, snakeCol] == item)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                    break;
            }
            

            return false;
        }

        private static bool CheckIfIsMatrix(char[,]snakeField, int snakeRow, int snakeCol)
        {
            if (snakeRow >= 0 &&snakeRow < snakeField.GetLength(0) && snakeCol >= 0 && snakeCol < snakeField.GetLength(1))
            {
                return true;
            }
            return false;
        }

        public static int GetRow(char[,] snakeField, char item)
        {
            int snakeRow = 0;
            for (int row = 0; row < snakeField.GetLength(0); row++)
            {
                for (int col = 0; col < snakeField.GetLength(1); col++)
                {
                    if (snakeField[row,col] == item)
                    {
                        snakeRow = row;
                        break;
                    }
                }
                
            }
            return snakeRow;
        }
        public static int GetCol(char[,] snakeField, char item)
        {
            int snakeCol = 0;
            for (int row = 0; row < snakeField.GetLength(0); row++)
            {
                for (int col = 0; col < snakeField.GetLength(1); col++)
                {
                    if (snakeField[row, col] == item)
                    {
                        snakeCol = col;
                        break;
                    }
                }

            }

            return snakeCol;
        }

        public static void PrintField(char[,] snakefield)
        {
            for (int i = 0; i < snakefield.GetLength(0); i++)
            {
                for (int j = 0; j < snakefield.GetLength(1); j++)
                {
                    Console.Write(snakefield[i,j]);
                }

                Console.WriteLine();
            }
        }
    }
}
