using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Scheduling
    {
        static void Main()
        {
            int[] tasks = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] treads = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int target = int.Parse(Console.ReadLine());

            Stack<int> taskToDo = new Stack<int>(tasks);
            Queue<int> treadsToDo = new Queue<int>(treads);

            while (taskToDo.Count > 0 && treadsToDo.Count > 0)
            {
                if (isTrue(target, taskToDo.Peek()))
                {
                    Console.WriteLine("Thread with value {0} killed task {1}", treadsToDo.Peek(), target);
                    Console.WriteLine(string.Join(' ', treadsToDo));
                    break;
                }

                if (taskToDo.Peek() > treadsToDo.Peek())
                {
                    treadsToDo.Dequeue();
                }
                else
                {
                    taskToDo.Pop();
                    treadsToDo.Dequeue();
                }
            }
        }

        public static bool isTrue(int target, int task)
        {
            if (task == target)
            {
                return true;
            }
            return false;
        }
    }
}