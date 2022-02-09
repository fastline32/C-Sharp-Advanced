using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        public Clinic(int capacity)
        {
            Capacity = capacity;
            Pets = new List<Pet>();
        }
        public List<Pet> Pets { get; set; }

        public int Capacity { get; set; }

        public int Count => Pets.Count;

        public void Add(Pet pet)
        {
            if (Count < Capacity)
            {
                Pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = Pets.Where(x => x.Name == name).FirstOrDefault();
            if (pet != null)
            {
                Pets.Remove(pet);
                return true;
            }

            return false;
        }

        public Pet GetOldestPet()
        {
            Pet oldestPet = Pets.OrderByDescending(x => x.Age).First();
            return oldestPet;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet getPet = Pets.Where(x => x.Name == name && x.Owner == owner).FirstOrDefault();
            return getPet;
        }

        public string GetStatistic()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in Pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString();
        }
    }
}
