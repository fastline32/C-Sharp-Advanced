using System;
using System.Collections.Generic;
using System.Linq;

namespace Warships
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine()!);
            if (n < 4)
            {
                Environment.Exit(0);
            }

            char[,] warField = new char[n, n];
            string[] commands = Console.ReadLine()!.Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<int[]> bombCoordinates = new List<int[]>();
            List<int[]> firstPlayerShips = new List<int[]>();
            List<int[]> secondPlayerShips = new List<int[]>();
            foreach (var item in commands)
            {
                int[] coordinates = item.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                bombCoordinates.Add(coordinates);
            }
            int count = 0;
            
            for (int row = 0; row < n; row++)
            {
                char[] line = Console.ReadLine()!.Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    warField[row, col] = line[col];
                    if (line[col] == '<')
                    {
                        int[] shipCoordinates = { row, col };
                        firstPlayerShips.Add(shipCoordinates);
                    }
                    else if (line[col] == '>')
                    {
                        int[] shipCoordinates = { row, col };
                        secondPlayerShips.Add(shipCoordinates);
                    }
                }
            }
            int destroedShips = 0;
            while (bombCoordinates.Count > 0 && firstPlayerShips.Count > 0 && secondPlayerShips.Count > 0)
            {
                bool first = true;
                count++;
                if (count% 2 == 0)
                {
                    first = false;
                }
                int[] bomb = bombCoordinates[0];
                if (bomb[0] < 0 || bomb[0] > warField.GetLength(0) || bomb[1] < 0 || bomb[1] > warField.GetLength(1))
                {
                    bombCoordinates.Remove(bomb);
                    
                }
                else if (warField[bomb[0], bomb[1]] == '#')
                {
                    Queue<Tuple<int, int>> fields = new Queue<Tuple<int, int>>();
                    fields.Enqueue(new Tuple<int, int>(-1, -1));
                    fields.Enqueue(new Tuple<int, int>(-1, 0));
                    fields.Enqueue(new Tuple<int, int>(-1, +1));
                    fields.Enqueue(new Tuple<int, int>(0, -1));
                    fields.Enqueue(new Tuple<int, int>(0, +1));
                    fields.Enqueue(new Tuple<int, int>(+1, -1));
                    fields.Enqueue(new Tuple<int, int>(+1, 0));
                    fields.Enqueue(new Tuple<int, int>(+1, +1));

                    for (int i = 0; i < fields.Count; i++)
                    {
                        int row = fields.Peek().Item1;
                        int col = fields.Peek().Item2;
                        fields.Enqueue(fields.Dequeue());
                        try
                        {
                            if (warField[bomb[0] + row, bomb[1] + col] == '>' || warField[bomb[0] + row, bomb[1] + col] == '<')
                            {
                                destroedShips++;
                                foreach (var item in firstPlayerShips)
                                {
                                    if (item[0] == bomb[0] + row && item[1] == bomb[1] + col)
                                    {
                                        firstPlayerShips.Remove(item);
                                    }
                                }
                                foreach (var item in secondPlayerShips)
                                {
                                    if (item[0] == bomb[0] + row && item[1] == bomb[1] + col)
                                    {
                                        secondPlayerShips.Remove(item);
                                    }
                                }
                                warField[bomb[0] + row, bomb[1] + col] = '*';
                            }
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }

                    bombCoordinates.Remove(bomb);
                }
                else if (first && warField[bomb[0],bomb[1]] == '>')
                {
                    warField[bomb[0], bomb[1]] = '*';
                    destroedShips++;
                    bombCoordinates.Remove(bomb);
                    int shipCount = 0;
                    foreach (var ship in secondPlayerShips)
                    {
                        if (bomb[0] == ship[0] && bomb[1] == ship[1])
                        {
                            break;
                        }
                        shipCount++;
                    }
                    secondPlayerShips.RemoveAt(shipCount);
                }
                else if (!first && warField[bomb[0], bomb[1]] == '<')
                {
                    warField[bomb[0], bomb[1]] = '*';
                    destroedShips++;
                    bombCoordinates.Remove(bomb);
                    int shipCount = 0;
                    foreach (var ship in firstPlayerShips)
                    {
                        if (bomb[0] == ship[0] && bomb[1] == ship[1])
                        {
                            break;
                        }
                        shipCount++;
                    }
                    firstPlayerShips.RemoveAt(shipCount);
                }
                else
                {
                    bombCoordinates.Remove(bomb);
                }

            }

            if (bombCoordinates.Count == 0 && firstPlayerShips.Count > 0 && secondPlayerShips.Count > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShips.Count} ships left. Player Two has {secondPlayerShips.Count} ships left.");
            }
            else 
            {
                if (firstPlayerShips.Count == 0)
                {
                    Console.WriteLine($"Player Two has won the game! {destroedShips} ships have been sunk in the battle.");
                }
                else
                {
                    Console.WriteLine($"Player One has won the game! {destroedShips} ships have been sunk in the battle.");
                }
            }
        }
    }
}
