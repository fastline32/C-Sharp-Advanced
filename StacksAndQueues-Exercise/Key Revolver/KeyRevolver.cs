using System;
using System.Collections.Generic;
using System.Linq;

namespace Key_Revolver
{
    internal class KeyRevolver
    {
        static void Main()
        {
            int bulletPrise = int.Parse(Console.ReadLine()!);
            int gunBarrel = int.Parse(Console.ReadLine()!);
            Stack<int> bullets = new Stack<int>(Console.ReadLine()!.Split(new[] {' '}).Select(int.Parse).ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine()!.Split(new[] {' '}).Select(int.Parse).ToArray());
            int intelligenceValue = int.Parse(Console.ReadLine()!);
            int currentBarel = gunBarrel;
            int firedBullets = 0;
            while (bullets.Count > 0 && locks.Count > 0)
            {
                if (bullets.Peek() > locks.Peek() && currentBarel > 0)
                {
                    Console.WriteLine("Ping!");
                    bullets.Pop();
                    currentBarel--;
                    firedBullets++;
                }
                else if (currentBarel == 0)
                {
                    Console.WriteLine("Reloading!");
                    currentBarel = gunBarrel;
                }
                else if (bullets.Peek() <= locks.Peek() && currentBarel > 0)
                {
                    Console.WriteLine("Bang!");
                    bullets.Pop();
                    locks.Dequeue();
                    currentBarel--;
                    firedBullets++;
                }
            }

            if (currentBarel == 0 && bullets.Count > 0)
            {
                Console.WriteLine("Reloading!");
            }

            if (bullets.Count > 0 && locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue - firedBullets*bulletPrise}");
            }
            else if (bullets.Count == 0 && locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue - firedBullets * bulletPrise}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
