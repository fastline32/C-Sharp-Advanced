using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.GenericBoxofInteger
{
    public class Box<T>
    {
        public Box()
        {
            this.ListItem = new List<T>();
        }

        public List<T> ListItem { get; set; }


        public override string ToString()
         => String.Join(Environment.NewLine,ListItem.Select(x => $"{typeof(T)}: {x}"));
    }
}
