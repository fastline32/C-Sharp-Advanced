using System;

namespace _01._Generic_Box_of_String
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                box.ListItem.Add(line);
            }

            Console.WriteLine(box.ToString());
        }
    }
}
