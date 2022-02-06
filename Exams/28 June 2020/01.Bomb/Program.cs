using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomb
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> bombs = new Dictionary<string, int>();
            bombs.Add("Datura Bombs", 0);
            bombs.Add("Cherry Bombs", 0);
            bombs.Add("Smoke Decoy Bombs", 0);

            Queue<int> bombEfects = new Queue<int>(Console.ReadLine()!.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            Stack<int> bombCasing = new Stack<int>(Console.ReadLine()!
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            while (bombEfects.Count > 0 && bombCasing.Count > 0)
            {
                int bombEfect = bombEfects.Peek();
                int bombCast = bombCasing.Peek();
                int sum = bombEfect + bombCast;
                if (sum == 40 || sum == 60 || sum == 120)
                {
                    switch (sum)
                    {
                        case 40:
                            bombs["Datura Bombs"]++;
                            bombEfects.Dequeue();
                            bombCasing.Pop(); break;
                        case 60:
                            bombs["Cherry Bombs"]++;
                            bombEfects.Dequeue();
                            bombCasing.Pop(); break;
                        case 120:
                            bombs["Smoke Decoy Bombs"]++;
                            bombEfects.Dequeue();
                            bombCasing.Pop(); break;
                    }
                }
                else
                {
                    bombCasing = newCasting(bombCasing);
                }

                if (bombs["Datura Bombs"] >= 3 && bombs["Cherry Bombs"] >= 3 && bombs["Smoke Decoy Bombs"] >= 3)
                {
                    Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
                    PrintData(bombEfects, bombCasing, bombs);
                    Environment.Exit(0);
                }
            }

            Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            PrintData(bombEfects, bombCasing, bombs);

        }

        private static Stack<int> newCasting(Stack<int> bombCasing)
        {
            int count = bombCasing.Count;
            Stack<int> newCasting = new Stack<int>();
            newCasting.Push(bombCasing.Pop() - 5);
            for (int i = 0; i < count - 1; i++)
            {
                newCasting.Push(bombCasing.Pop());
            }

            bombCasing = newCasting;
            newCasting = new Stack<int>();
            for (int i = 0; i < count; i++)
            {
                newCasting.Push(bombCasing.Pop());
            }
            return newCasting;
        }

        private static void PrintData(Queue<int> bombEfects, Stack<int> bombCasing, Dictionary<string, int> bombs)
        {
            if (bombEfects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEfects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasing.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {bombs["Cherry Bombs"]}");
            Console.WriteLine($"Datura Bombs: {bombs["Datura Bombs"]}");
            Console.WriteLine($"Smoke Decoy Bombs: {bombs["Smoke Decoy Bombs"]}");
        }
    }
}
