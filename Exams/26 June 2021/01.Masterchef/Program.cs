using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class Program
    {
        static void Main()
        {
            Queue<int> ingredient = new Queue<int>(Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            Stack<int> freshness = new Stack<int>(Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Dictionary<string, int> cooked = new Dictionary<string, int>();
            cooked.Add("Dipping sauce", 0);
            cooked.Add("Green salad", 0);
            cooked.Add("Chocolate cake", 0);
            cooked.Add("Lobster", 0);

            while (ingredient.Count > 0 && freshness.Count > 0)
            {
                int integer = ingredient.Peek();
                int fresh = freshness.Peek();
                if (integer == 0)
                {
                    ingredient.Dequeue();
                    if (ingredient.Count == 0)
                    {
                        break;
                    }
                    integer = ingredient.Peek();
                }

                int sum = integer * fresh;
                switch (sum)
                {
                    case 150:
                        cooked["Dipping sauce"]++;
                        ingredient.Dequeue();
                        freshness.Pop();
                        break;
                    case 250:
                        cooked["Green salad"]++;
                        ingredient.Dequeue();
                        freshness.Pop();
                        break;
                    case 300:
                        cooked["Chocolate cake"]++;
                        ingredient.Dequeue();
                        freshness.Pop();
                        break;
                    case 400:
                        cooked["Lobster"]++;
                        ingredient.Dequeue();
                        freshness.Pop();
                        break;
                    default:
                        ingredient.Enqueue(ingredient.Dequeue() + 5);
                        freshness.Pop();break;

                }
            }

            int count = 0;
            foreach (var dish in cooked)
            {
                if (dish.Value > 0)
                {
                    count++;
                }
            }

            if (count == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredient.Sum() > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredient.Sum()}");
            }

            foreach (var dish in cooked.OrderBy(x => x.Key).Where(x => x.Value > 0))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }
    }
}

//83
