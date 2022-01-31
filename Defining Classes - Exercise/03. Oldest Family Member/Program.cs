using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int n = (int.Parse(Console.ReadLine()!));
            Family myFamily = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine()!.Split();
                Person person = new Person(line[0],int.Parse(line[1]));
                myFamily.AddMember(person);
            }

            Person oldestMember = myFamily.GetOldestMember();

            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}
