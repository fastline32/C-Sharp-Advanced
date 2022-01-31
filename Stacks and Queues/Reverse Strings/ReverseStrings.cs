using System;
using System.Collections.Generic;

namespace Reverse_Strings
{
    internal class ReverseStrings
    {
        static void Main()
        {
            string line = Console.ReadLine()!;
            Stack<char> reversed = new Stack<char>();
            foreach (var item in line)
            {
                reversed.Push(item);
            }

            foreach (var item in reversed)
            {
                Console.Write(item);
            }
        }
    }
}
