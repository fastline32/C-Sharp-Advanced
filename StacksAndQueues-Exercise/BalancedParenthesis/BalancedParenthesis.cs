using System;
using System.Collections.Generic;

namespace BalancedParenthesis
{
    class BalancedParenthesis
    {
        static void Main(string[] args)
        {
            char[] parentheses = Console.ReadLine().ToCharArray();
            Dictionary<char, char> closingBrackets = new Dictionary<char, char>() { { ']', '[' }, { ')', '(' }, { '}', '{' } };
            Stack<char> stack = new Stack<char>();
            foreach (char bracket in parentheses)
            {
                if (stack.Count > 0 && closingBrackets.ContainsKey(bracket) && stack.Peek() == closingBrackets[bracket])
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(bracket);
                }
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
