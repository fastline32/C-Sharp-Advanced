using System;

namespace Bee
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine()!);
            char[,] beeField = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    beeField[row, col] = line[col];
                }
            }

            int beeRow = GetRow(beeField);
            int beeCol = GetCol(beeField);
            int flower = 0;

            string command = Console.ReadLine();
            while (command != "End")
            {
                if (CheckIfIsMatrix(beeField,beeRow,beeCol,command))
                {
                    char item = GetNextChar(beeField,beeRow, beeCol, command);
                    flower = CheckIfFlower(beeField,beeRow,beeCol,item,command,flower);
                    if (command == "left" || command == "right")
                    {
                        beeCol = GetCol(beeField);
                    }
                    else
                    {
                        beeRow = GetRow(beeField);
                    }
                    
                }
                else
                {
                    Console.WriteLine("The bee got lost!");
                    beeField[beeRow, beeCol] = '.';
                    if (flower < 5)
                    {
                        Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flower} flowers more");
                        PrintField(beeField);
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine($"Great job, the bee managed to pollinate {flower} flowers!");
                        PrintField(beeField);
                        Environment.Exit(0);
                    }
                    
                }

                command = Console.ReadLine();
            }

            if (flower < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flower} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flower} flowers!");
            }
            PrintField(beeField);
        }

        public static char GetNextChar(char[,] beeField, int beeRow, int beeCol, string command)
        {
            char item = ' ';
            switch (command)
            {
                case "left":
                    item = beeField[beeRow, beeCol - 1];break;
                case "right":
                    item = beeField[beeRow, beeCol + 1];break;
                case "up":
                    item = beeField[beeRow - 1, beeCol];break;
                case "down":
                    item = beeField[beeRow + 1, beeCol];break;
            }
            return item;
        }

        private static bool CheckIfIsMatrix(char[,] beeField, int beeRow, int beeCol, string command)
        {
            switch (command)
            {
                case "up":
                    if (beeRow - 1 >= 0 && beeRow - 1 < beeField.GetLength(0) && beeCol >= 0 && beeCol < beeField.GetLength(1))
                    {
                        return true;
                    }break;
                case "down":
                    if (beeRow + 1 >= 0 && beeRow + 1 < beeField.GetLength(0) && beeCol >= 0 && beeCol < beeField.GetLength(1))
                    {
                        return true;
                    }break;
                case "left":
                    if (beeRow >= 0 && beeRow < beeField.GetLength(0) && beeCol - 1 >= 0 && beeCol -1 < beeField.GetLength(1))
                    {
                        return true;
                    }break;
                case "right":
                    if (beeRow >= 0 && beeRow < beeField.GetLength(0) && beeCol+1 >= 0 && beeCol+1 < beeField.GetLength(1))
                    {
                        return true;
                    }break;
            }
            return false;
        }

        public static int GetRow(char[,] beeField)
        {
            int beeRow = 0;
            for (int row = 0; row < beeField.GetLength(0); row++)
            {
                for (int col = 0; col < beeField.GetLength(1); col++)
                {
                    if (beeField[row, col] == 'B')
                    {
                        beeRow = row;
                        break;
                    }
                }

            }
            return beeRow;
        }
        public static int GetCol(char[,] beeField)
        {
            int beeCol = 0;
            for (int row = 0; row < beeField.GetLength(0); row++)
            {
                for (int col = 0; col < beeField.GetLength(1); col++)
                {
                    if (beeField[row, col] == 'B')
                    {
                        beeCol = col;
                        break;
                    }
                }

            }

            return beeCol;
        }

        public static void MoveBee(char[,] beeField, int beeRow, int beeCol, string command)
        {
            beeField[beeRow, beeCol] = '.';
            switch (command)
            {
                case "left":
                    beeField[beeRow, beeCol - 1] = 'B';
                    beeField[beeRow, beeCol] = '.';break;
                case "right":
                    beeField[beeRow, beeCol + 1] = 'B';
                    beeField[beeRow, beeCol] = '.';break;
                case "up":
                     beeField[beeRow - 1, beeCol] = 'B';
                    beeField[beeRow, beeCol] = '.';break;
                case "down":
                    beeField[beeRow + 1, beeCol] = 'B';
                    beeField[beeRow, beeCol] = '.';break;
            }
        }

        private static int CheckIfFlower(char[,] beeField, int beeRow, int beeCol, char item, string command, int flower)
        {
            if (item == 'f')
            {
                switch (command)
                {
                    case "left":
                        if (beeField[beeRow,beeCol -1] == item)
                        {
                            flower++;
                            MoveBee(beeField,beeRow,beeCol,command);
                        } ;break;
                    case "right":
                        if (beeField[beeRow, beeCol + 1] == item)
                        {
                            flower++;
                            MoveBee(beeField, beeRow, beeCol, command);
                        } ; break;
                    case "up":
                        if (beeField[beeRow - 1, beeCol] == item)
                        {
                            flower++;
                            MoveBee(beeField, beeRow, beeCol, command);
                        } ; break;
                    case "down":
                        if (beeField[beeRow + 1, beeCol] == item)
                        {
                            flower++;
                            MoveBee(beeField, beeRow, beeCol, command);
                        } ; break;
                }
            }
            else if (item == 'O')
            {
                MoveBee(beeField,beeRow,beeCol,command);
                if (command == "left" || command == "right")
                {
                    beeCol = GetCol(beeField);
                }
                else
                {
                    beeRow = GetRow(beeField);
                }

                char nextChar = GetNextChar(beeField, beeRow, beeCol, command);
                flower = CheckIfFlower(beeField,beeRow,beeCol,nextChar,command,flower);
            }
            else
            {
                MoveBee(beeField,beeRow,beeCol,command);
            }
            return flower;
        }

        public static void PrintField(char[,] beeField)
        {
            for (int row = 0; row < beeField.GetLength(0); row++)
            {
                for (int col = 0; col < beeField.GetLength(1); col++)
                {
                    Console.Write(beeField[row,col]);
                }
                Console.WriteLine();
            }
        }

    }
}
