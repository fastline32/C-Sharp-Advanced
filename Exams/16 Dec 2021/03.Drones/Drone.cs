using System.Reflection.Metadata;
using System.Text;

namespace Drones
{
    public class Drone
    {
        private string name;
        private string brand;
        private int range;
        private bool available;

        public Drone(string name,string brand,int range)
        {
            Name = name;
            Brand = brand;
            Range = range;
            Availabble = true;
        }

        public string Name { get { return this.name; } set { this.name = value; } }
        public string Brand { get { return this.brand; } set { this.brand = value; } }
        public int Range { get { return this.range; } set { this.range = value; } }
        public bool Availabble { get { return this.available; } set { this.available = value; } }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drone: {name}");
            sb.AppendLine($"Manufactured by: {brand}");
            sb.AppendLine($"Range: {range} kilometers");
            return sb.ToString().TrimEnd();
        }
    }
}
