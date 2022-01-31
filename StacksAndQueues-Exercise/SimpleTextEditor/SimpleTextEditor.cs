using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main()
        {
            int commandsCount = int.Parse(Console.ReadLine() ?? string.Empty);

            string text = string.Empty;

            Stack<string> stack = new Stack<string>();

            for (var i = 0; i < commandsCount; i++)
            {
                var line = Console.ReadLine()?.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (line != null)
                {
                    var command = int.Parse(line[0]);

                    switch (command)
                    {
                        case 1:
                            string charactersForAdd = line[1];
                            text += charactersForAdd;
                            stack.Push(text);
                            break;
                        case 2:
                            var charsForErase = int.Parse(line[1]);
                            text = text.Substring(0, text.Length - charsForErase);
                            stack.Push(text);
                            break;
                        case 3:
                            var index = int.Parse(line[1]);
                            Console.WriteLine(text[index - 1]);
                            break;
                        case 4:
                            stack.Pop();
                            text = stack.Count > 0 ? stack.Peek() : string.Empty;

                            break;
                    }
                }
            }
        }
    }
}