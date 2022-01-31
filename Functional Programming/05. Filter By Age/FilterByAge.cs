using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Filter_By_Age
{
    class Student
    {
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class FilterByAge
    {

        static void Main()
        {
            int n = int.Parse(Console.ReadLine()!);
            List<Student> students = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()!.Split(", ");
                students.Add(new Student(input[0],int.Parse(input[1])));
            }

            string type = Console.ReadLine();
            int age = int.Parse(Console.ReadLine()!);
            string formatInput = Console.ReadLine();

            Func<Student, int, bool> filter = GetFiltered(type);
            students = students.Where(x => filter(x, age)).ToList();
            Action<Student> printer = GetPrinter(formatInput);
            students.ForEach(printer);
        }

        private static Action<Student> GetPrinter(string formatInput)
        {
            switch (formatInput)
            {
                case "name":
                    return s => Console.WriteLine(s.Name);
                case "age":
                    return s => Console.WriteLine(s.Age);
                case "name age":
                    return s => Console.WriteLine(s.Name+ " - " + s.Age);
                default:
                    return null;
            }
        }

        private static Func<Student, int, bool> GetFiltered(string type)
        {
            switch (type)
            {
                case "older":
                    return (s,age) => s.Age >= age;
                case "younger":
                    return (s, age) => s.Age < age;
                default:
                    return null;
            }
        }
    }
}
