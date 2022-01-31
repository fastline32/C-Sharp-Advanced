using System;
using System.Collections.Generic;

namespace SongsQueue
{
    class SongsQueue
    {
        static void Main()
        {
            var songs = new Queue<string>(Console.ReadLine()!.Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries));

            while (songs.Count>0)
            {
                var command = new Queue<string>(Console.ReadLine()!.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries));

                switch (command.Dequeue())
                {
                    case "Play":
                        songs.Dequeue();break;
                    case "Add":
                        string songName = string.Join(" ", command);
                        if (songs.Contains(songName))
                        {
                            Console.WriteLine("{0} is already contained!",songName);
                        }
                        else
                        {
                            songs.Enqueue(songName);
                        };break;
                    case "Show":
                        Console.WriteLine(string.Join(", ",songs));break;
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
