using System;
using System.Linq;

namespace _02.SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int marioLives = int.Parse(Console.ReadLine()!);
            int row = int.Parse(Console.ReadLine()!);
            char[][] field = new char[row][];
            int marioRow = 0;
            int marioCol = 0;
            for (int i = 0; i < row; i++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                field[i] = line;
                if (line.Contains('M'))
                {
                    marioRow = i;
                    marioCol = line.ToList().IndexOf('M');
                }

            }

            while (true)
            {
                string[] command = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string move = command[0];
                int enemyRow = int.Parse(command[1]);
                int enemyCol = int.Parse(command[2]);
                field[enemyRow][enemyCol] = 'B';
                field[marioRow][marioCol] = '-';
                marioLives--;

                if (move == "W" && marioRow - 1 >= 0) //up
                {
                    marioRow--;
                }

                else if (move == "S" && marioRow + 1 < row) // down
                {
                    marioRow++;
                }

                else if (move == "A" && marioCol - 1 >= 0) // left
                {
                    marioCol--;
                }

                else if (move == "D" && marioCol + 1 < field[0].Length) //right
                {
                    marioCol++;
                }

                if (field[marioRow][marioCol] == 'B')
                {
                    marioLives -= 2;
                }
                else if (field[marioRow][marioCol] == 'P')
                {
                    field[marioRow][marioCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
                    break;
                }

                if (marioLives <= 0)
                {
                    field[marioRow][marioCol] = 'X';
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    break;
                }

                field[marioRow][marioCol] = 'M';
            }

            for (int i = 0; i < row; i++)
            {
                Console.WriteLine(new string(field[i]));
            }
        }
    }
}
