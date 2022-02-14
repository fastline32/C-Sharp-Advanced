using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    class BirthdayCelebration
    {
        static void Main()
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine()!
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> plates = new Stack<int>(Console.ReadLine()!
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int grams = 0;

            while (guests.Count > 0 && plates.Count > 0)
            {
                if (guests.Peek() == plates.Peek())
                {
                    guests.Dequeue();
                    plates.Pop();
                }
                else if (guests.Peek() < plates.Peek())
                {
                    grams += plates.Pop() - guests.Dequeue();
                }
                else
                {
                    Queue<int> newGuest = new Queue<int>();
                    newGuest.Enqueue(guests.Peek() - plates.Peek());
                    for (int i = 1; i < guests.Count; i++)
                    {
                        newGuest.Enqueue(guests.ElementAt(i));
                    }

                    for (int i = 0; i < guests.Count; i++)
                    {
                        guests.Dequeue();
                    }

                    guests = newGuest;
                    plates.Pop();
                }
            }

            if (guests.Count > 0)
            {
                Console.WriteLine("Guests: {0}", string.Join(" ", guests));
            }
            else
            {
                Console.WriteLine("Plates: {0}", string.Join(" ", plates));
            }

            Console.WriteLine("Wasted grams of food: {0}", grams);
        }
    }
}
//100