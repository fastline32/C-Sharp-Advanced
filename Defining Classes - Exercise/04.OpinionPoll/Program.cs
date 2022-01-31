using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family myFamily = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();
                Person person =new Person(line[0],int.Parse(line[1]));
                myFamily.AddMember(person);
            }
            List<Person> newList = new List<Person>();
            newList = myFamily.OpinionPoll();

            foreach (var member in newList)
            {
                Console.WriteLine($"{member.Name} - {member.Age}");
            }
        }
    }
}
