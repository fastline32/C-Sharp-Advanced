using System;
using System.Linq;

namespace TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main()
        {
            int armyArmor = int.Parse(Console.ReadLine()!);
            int n = int.Parse(Console.ReadLine()!);
            char[][] field = new char[n][];
            int armyRow = 0;
            int armyCol = 0;

            for (int i = 0; i < n; i++)
            {
                char[] lineChars = Console.ReadLine()!.ToCharArray();
                field[i] = lineChars;
                if (lineChars.Contains('A'))
                {
                    armyRow = i;
                    armyCol = lineChars.ToList().IndexOf('A');
                }
            }

            while (true)
            {
                string[] commandLine = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commandLine[0];
                int spawnRow = int.Parse(commandLine[1]);
                int spawnCol = int.Parse(commandLine[2]);
                field[armyRow][armyCol] = '-';
                field[spawnRow][spawnCol] = 'O';
                armyArmor--;
                if (command == "up" && armyRow - 1 >= 0)
                {
                    armyRow--;
                }
                else if (command == "down" && armyRow + 1 < n)
                {
                    armyRow++;
                }
                else if (command == "left" && armyCol - 1 >= 0)
                {
                    armyCol--;
                }
                else if (command == "right" && armyCol + 1 < field[0].Length)
                {
                    armyCol++;
                }
                if (field[armyRow][armyCol] == 'O')
                {
                    armyArmor -= 2;
                }
                else if (field[armyRow][armyCol] == 'M')
                {
                    field[armyRow][armyCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
                    break;
                }
                if (armyArmor <= 0)
                {
                    field[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    break;
                }

                field[armyRow][armyCol] = 'A';
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string(field[i]));
            }
        }
    }
}
//100
