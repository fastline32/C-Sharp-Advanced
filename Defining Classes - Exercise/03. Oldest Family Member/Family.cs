using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> members;

        public List<Person> Members { get { return this.members; } set { this.members = value; } }

        public Family()
        {
            this.Members = new List<Person>();
        }

        public void AddMember(Person member)
        {
            Members.Add(member);
        }

        public Person GetOldestMember()
        {
            return Members.OrderByDescending(x => x.Age).FirstOrDefault();
        }
    }
}
