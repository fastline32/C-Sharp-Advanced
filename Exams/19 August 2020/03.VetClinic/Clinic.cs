using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> pets;
        
        public Clinic(int capacity)
        {
            this.pets = new List<Pet>();
            this.Capacity = capacity;
        }

        public int Capacity { get; set; }

        public int Count => pets.Count;

        public void Add(Pet pet)
        {
            if (pets.Count < Capacity)
            {
                pets.Add(pet);
            }
        }

        public bool Remove(string name) => pets.Remove(pets.FirstOrDefault(x => x.Name == name));

        public Pet GetPet(string name, string owner) => pets.FirstOrDefault(x => x.Name == name && x.Owner == owner);

        public Pet GetOldestPet() => pets.OrderByDescending(x => x.Age).FirstOrDefault();

        public string GetStatistic()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString();
        }
    }
}
