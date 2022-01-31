using System.Collections.Generic;

namespace DefiningClasses
{
    public class Trainer
    {
        private string name;
        private int badges;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.Name = name;
            this.Pokomens = new List<Pokemon>();
            this.Badges = 0;
        }

        public string Name { get { return this.name;} set { this.name = value; } }
        public int Badges { get { return this.badges; } set { this.badges = value; } }
        public List<Pokemon> Pokomens { get { return this.pokemons; } set { this.pokemons = value; } }

        public static void AddTrainersAndPokemons(Dictionary<string ,Trainer > trainers, string[] inputData)
        {
            string name = inputData[0];
            Pokemon pokemon = new Pokemon(inputData[1], inputData[2], int.Parse(inputData[3]));
            if (!trainers.ContainsKey(name))
            {
                Trainer newTrainer = new Trainer(name);
                trainers.Add(name,newTrainer);
            }
            trainers[name].Pokomens.Add(pokemon);
        }
    }
}
