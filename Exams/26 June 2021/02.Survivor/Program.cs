using System;
using System.Data;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine()!);
            string[][] field = new string[row][];
            for (int i = 0; i < row; i++)
            {
                string[] line = Console.ReadLine()!.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                field[i] = line;
            }

            int points = 0;
            int oponentPoints = 0;

            string commandLine = Console.ReadLine();
            while (commandLine != "Gong")
            {
                string[] line = commandLine.Split();
                string command = line[0];
                int findRow = int.Parse(line[1]);
                int findCol = int.Parse(line[2]);

                if (command == "Find")
                {
                    points = Move(field, findRow, findCol, points);
                }
                else if (command == "Opponent")
                {
                    string side = line[3];
                    if (side == "up")
                    {
                        oponentPoints = Move(field, findRow, findCol, oponentPoints);
                        findRow--;
                        oponentPoints = Move(field, findRow, findCol, oponentPoints);
                        findRow--;
                        oponentPoints = Move(field, findRow, findCol, oponentPoints);
                        findRow--;
                        oponentPoints = Move(field, findRow, findCol, oponentPoints);
                    }
                    if (side == "down")
                    {
                        oponentPoints = Move(field, findRow, findCol, oponentPoints);
                        findRow++;
                        oponentPoints = Move(field, findRow, findCol, oponentPoints);
                        findRow++;
                        oponentPoints = Move(field, findRow, findCol, oponentPoints);
                        findRow++;
                        oponentPoints = Move(field, findRow, findCol, oponentPoints);
                    }
                    if (side == "left")
                    {
                        oponentPoints = Move(field, findRow, findCol, oponentPoints);
                        findCol--;
                        oponentPoints = Move(field, findRow, findCol, oponentPoints);
                        findCol--;
                        oponentPoints = Move(field, findRow, findCol, oponentPoints);
                        findCol--;
                        oponentPoints = Move(field, findRow, findCol, oponentPoints);
                    }
                    if (side == "right")
                    {
                        oponentPoints = Move(field, findRow, findCol, oponentPoints);
                        findCol++;
                        oponentPoints = Move(field, findRow, findCol, oponentPoints);
                        findCol++;
                        oponentPoints = Move(field, findRow, findCol, oponentPoints);
                        findCol++;
                        oponentPoints = Move(field, findRow, findCol, oponentPoints);
                    }
                }
                commandLine = Console.ReadLine();
            }

            for (int i = 0; i < row; i++)
            {
                Console.WriteLine(string.Join(' ',field[i]));
            }

            Console.WriteLine($"Collected tokens: {points}");
            Console.WriteLine($"Opponent's tokens: {oponentPoints}");

        }

        public static bool IsInField(string[][] field, int row, int col)
        {
            if (row >= 0 && row < field.Length && col >= 0 && col < field[row].Length)
            {
                return true;
            }
            return false;
        }

        public static int Move(string[][] field, int row, int col, int points)
        {
            if (IsInField(field,row,col) && field[row][col] =="T")
            {
                points++;
                field[row][col] = "-";
            }

            return points;
        }
    }
}

//85
