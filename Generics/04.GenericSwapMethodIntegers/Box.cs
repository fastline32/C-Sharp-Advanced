using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodIntegers
{
public class Box<T>
    {
        public Box()
        {
            this.ListItem = new List<T>();
        }

        public List<T> ListItem { get; set; }


        public void Swap(int firstIndex, int sekondIndex)
            => (ListItem[firstIndex], ListItem[sekondIndex]) = (ListItem[sekondIndex], ListItem[firstIndex]);

        public override string ToString()
         => String.Join(Environment.NewLine,ListItem.Select(x => $"{typeof(T)}: {x}"));
    }
}
