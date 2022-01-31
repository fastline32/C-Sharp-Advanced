using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Sum
{
    internal class StackSum
    {
        static void Main()
           {
            Stack<int> nums = new Stack<int>();
            int[] line = Console.ReadLine()!.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            for (int i = 0; i < line.Length; i++)
            {
                nums.Push(line[i]);
            }

            string[] command = Console.ReadLine()!.Split(' ').ToArray();
            while (command[0].ToLower() != "end")
            {
                switch (command[0].ToLower())
                {
                    case "add":
                        nums.Push(int.Parse(command[1]));
                        nums.Push(int.Parse(command[2]));break;
                    case "remove":
                        if (int.Parse(command[1]) <= nums.Count)
                        {
                            for (int i = 0; i < int.Parse(command[1]); i++)
                            {
                                nums.Pop();
                            }
                        }

                        ;break;
                }
                command = command = Console.ReadLine()!.Split(' ').ToArray();
            }

            Console.WriteLine($"Sum: {nums.Sum()}");
        }
    }
}
