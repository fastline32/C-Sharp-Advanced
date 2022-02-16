using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, List<char>> words = new Dictionary<string, List<char>>();
            words.Add("pear", "pear".ToList());
            words.Add("flour", "flour".ToList());
            words.Add("pork", "pork".ToList());
            words.Add("olive", "olive".ToList());

            char[] line = Console.ReadLine()!.Where(x => !Char.IsWhiteSpace(x)).ToArray();
            Queue<char> firstSequence = new Queue<char>(line);
            line = Console.ReadLine()!.Where(x => !Char.IsWhiteSpace(x)).ToArray();
            Stack<char> secondSequence = new Stack<char>(line);
            while (secondSequence.Count > 0)
            {
                foreach (var word in words)
                {
                    if (word.Value.Contains(firstSequence.Peek()))
                    {
                        word.Value.Remove(firstSequence.Peek());
                    }
                }
                firstSequence.Enqueue(firstSequence.Dequeue());
                foreach (var word in words)
                {
                    if (word.Value.Contains(secondSequence.Peek()))
                    {
                        word.Value.Remove(secondSequence.Peek());
                    }
                }

                secondSequence.Pop();
            }

            Console.WriteLine($"Words found: {words.Count(x => x.Value.Count == 0)}");
            foreach (var word in words.Where(x => x.Value.Count == 0))
            {
                Console.WriteLine($"{word.Key}");
            }
        }
    }
}
//100