using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new Dictionary<string, Ingredient>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public Dictionary<string,Ingredient> Ingredients { get; set; }

        public int CurrentAlcoholLevel => Ingredients.Sum(x => x.Value.Alcohol);
        

        public void Add(Ingredient ingredient)
        {
            if (Ingredients.Count < Capacity && !Ingredients.ContainsKey(ingredient.Name))
            {
                Ingredients.Add(ingredient.Name,ingredient);
            }
        }

        public bool Remove(string name)
        {
            if (!Ingredients.ContainsKey(name))
            {
                return false;
            }
            Ingredients.Remove(name);
            return true;
        }

        public Ingredient FindIngredient(string name)
        {
            if (!Ingredients.ContainsKey(name))
            {
                return null;
            }

            Ingredient ingredients = Ingredients.First(x => x.Key == name).Value;
            return ingredients;
        }

        public Ingredient GetMostAlcoholicIngredient() => Ingredients.OrderByDescending(x => x.Value.Alcohol).First().Value;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var item in Ingredients)
            {
                sb.AppendLine(item.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
