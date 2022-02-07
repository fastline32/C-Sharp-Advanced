using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Generic_Box_of_String
{
    public class Box<T>
    {
        public Box()
        {
            this.ListItem = new List<T>();
        }

        public List<T> ListItem { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in ListItem)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString();
        }
    }
}
