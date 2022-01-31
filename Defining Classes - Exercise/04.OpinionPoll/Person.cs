using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;
        private List<Person> family;

        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
            this.Family = new List<Person>();
        }

        public Person(int age):this()
        {
            this.Age = age;
            this.Family = new List<Person>();
        }

        public Person(string name,int age):this(age)
        {
            this.Name = name;
            this.Family = new List<Person>();
        }
        public string Name { get { return this.name; } set { this.name = value; } }

        public int Age { get { return this.age; } set { this.age = value; } }

        public List<Person> Family { get { return this.family; } set { this.family = value; } }

        public List<Person> OpinionPoll()
        {
            return Family.Where(x => x.Age > 30).OrderBy(x => Name).ToList();
        }
    }
}
