using System.Collections.Generic;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;
        private List<Family> family;

        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }

        public Person(int age):this()
        {
            this.Age = age;
        }

        public Person(string name,int age):this(age)
        {
            this.Name = name;
        }
        public string Name { get { return this.name; } set { this.name = value; } }

        public int Age { get { return this.age; } set { this.age = value; } }

        public List<Family> Family { get { return this.family; } set { this.family = value; } }
    }
}
