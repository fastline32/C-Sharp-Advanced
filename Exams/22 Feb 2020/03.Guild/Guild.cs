

using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public Guild(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            Players = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Player> Players { get; set; }

        public int Count => Players.Count;

        public void AddPlayer(Player player)
        {
            if (Players.Count<Capacity)
            {
                Players.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = Players.FirstOrDefault(x => x.Name == name);
            if (player == null)
            {
                return false;
            }
            Players.Remove(player);
            return true;
        }

        public void PromotePlayer(string name)
        {
            Player player = Players.First(x => x.Name == name);
            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = Players.First(x => x.Name == name);
            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string cClass)
        {
            Player[] kikedPlayers = Players.Where(x => x.Class == cClass).ToArray();
            foreach (var player in kikedPlayers)
            {
                Players.Remove(player);
            }

            return kikedPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in Players)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
