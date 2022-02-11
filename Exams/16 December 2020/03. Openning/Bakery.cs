using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> employees;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            employees = new List<Employee>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<Employee> Employees { get { return this.employees;} set { this.employees = value; } }

        public int Count => Employees.Count;

        public void Add(Employee employee)
        {
            if (Employees.Count < Capacity)
            {
                Employees.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee person = Employees.Where(x => x.Name == name).FirstOrDefault();
            if (person != null)
            {
                Employees.Remove(person);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Employee GetOldestEmployee() => Employees.OrderByDescending(x => x.Age).FirstOrDefault();

        public Employee GetEmployee(string name) => Employees.Where(x => x.Name == name).FirstOrDefault();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var person in Employees)
            {
                sb.AppendLine(person.ToString());
            }


            return sb.ToString();
        }
    }
}
