using System;
using System.Linq;

namespace Count_Uppercase_Words
{
    public class CountUppercaseWords
    {
        static void Main()
        {
            Func<string, bool> IsUpper = x => char.IsUpper(x[0]);
            string[] words = Console.ReadLine().Split(new []{' '},StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(String.Join("\n",words.Where(IsUpper)));
        }
    }
}
