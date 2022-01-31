using System;
using System.Collections.Generic;

namespace MatchingBracket
{
    internal class MatchingBracket
    {
        static void Main()
        {
            string expressions = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < expressions.Length; i++)
            {
                if (expressions[i] == '(')
                {
                    stack.Push(i);
                }

                if (expressions[i] == ')')
                {
                    int starIndex = stack.Pop();
                    int ednIndex = i;
                    Console.WriteLine(expressions.Substring(starIndex,ednIndex - starIndex + 1));

                }
            }
        }
    }
}
