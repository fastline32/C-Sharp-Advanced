using System.Text;

namespace Parking
{
    public class Car
    {
        private string manufacturer;
        private string model;
        private int year;

        public Car(string manufacturer,string model, int year)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Year = year;

        }

        public string Manufacturer { get { return this.manufacturer;} set { this.manufacturer = value; } }
        public string Model { get { return this.model; } set { this.model = value; } }
        public int Year { get { return this.year; } set { this.year = value; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Manufacturer}" + " ");
            sb.Append($"{this.Model}" + " ");
            sb.Append($"({this.Year})");
            return sb.ToString().TrimEnd();
        }
    }
}
