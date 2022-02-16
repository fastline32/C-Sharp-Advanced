using System;

namespace PawnWars
{
    class Program
    {
        static void Main()
        {
            char[,] field = new char[8, 8];
            int whiteRow = 0;
            int whiteCol = 0;
            int blackRow = 0;
            int blackCol = 0;
            for (int row = 0; row < 8; row++)
            {
                char[] line = Console.ReadLine()!.ToCharArray();
                for (int col = 0; col < 8; col++)
                {
                    field[row, col] = line[col];
                    if (line[col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }
                    if (line[col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }

            while (true)
            {
                if (IsInField(whiteRow- 1,whiteCol -1) && field[whiteRow - 1,whiteCol - 1] == 'b' )
                {
                    Console.WriteLine($"Game over! White capture on {Convert.ToChar((whiteCol - 1)+97)}{8 - (whiteRow - 1)}.");
                    break;
                }
                else if (IsInField(whiteRow - 1, whiteCol + 1) && field[whiteRow - 1, whiteCol + 1] == 'b')
                {
                    Console.WriteLine($"Game over! White capture on {Convert.ToChar((whiteCol + 1) + 97)}{8 - (whiteRow - 1)}.");
                    break;
                }

                else if (whiteRow - 1 == 0)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {Convert.ToChar(whiteCol + 97)}8.");
                    break;
                }
                else
                {
                    field[whiteRow, whiteCol] = '-';
                    whiteRow--;
                    field[whiteRow, whiteCol] = 'w';
                }

                if (IsInField(blackRow+1,blackCol-1) && field[blackRow + 1, blackCol - 1] == 'w')
                {
                    Console.WriteLine($"Game over! Black capture on {Convert.ToChar((blackCol - 1) + 97)}{8 - (blackRow + 1)}.");
                    break;
                }

                else if (IsInField(blackRow + 1,blackCol + 1 ) && field[blackRow+1,blackCol+1] == 'w')
                {
                    Console.WriteLine($"Game over! Black capture on {Convert.ToChar((blackCol + 1) + 97)}{8 - (blackRow + 1)}.");
                    break;
                }

                else if (whiteRow + 1 == 7)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {Convert.ToChar(blackCol + 97)}8.");
                    break;
                }
                else
                {
                    field[blackRow, blackCol] = '-';
                    blackRow++;
                    field[blackRow, blackCol] = 'b';
                }
            }
        }

        public static bool IsInField(int row, int col)
        {
            if (row >= 0 && row < 8 && col >= 0 && col < 8)
            {
                return true;
            }
            return false;
        }
    }
}
//80
