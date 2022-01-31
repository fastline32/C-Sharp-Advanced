using System;
using System.Linq;

namespace JuggedArrayCommands
{
    internal class JuggedArrayCommands
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine()!);
            int[][] arrs = new int[n][];
            for (int i = 0; i < n; i++)
            {
                arrs[i] = Console.ReadLine()!.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            var commandLine = Console.ReadLine()!.Split(' ').ToArray();
            var command = commandLine[0];
            while (command != "END")
            {
                int row = int.Parse(commandLine[1]);
                int col = int.Parse(commandLine[2]);
                int value = int.Parse(commandLine[3]);
                if (row  < 0 || arrs.Length <= row || col < 0 || arrs[row].Length <= col )
                {
                    Console.WriteLine("Invalid coordinates");
                    commandLine = Console.ReadLine()!.Split(' ').ToArray();
                    command = commandLine[0];
                    continue;
                }

                if (command == "Add")
                {
                    arrs[row][col] += value;
                }
                else if (command == "Subtract")
                {
                    arrs[row][col] -= value;
                }
                commandLine = Console.ReadLine()!.Split(' ').ToArray();
                command = commandLine[0];
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(' ',arrs[i])); 
            }
        }
    }
}
