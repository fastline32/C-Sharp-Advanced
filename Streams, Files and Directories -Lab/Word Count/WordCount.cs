using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordsFile = @"..\..\..\Files\words.txt";
            string textFile = @"..\..\..\Files\text.txt";
            string outputFile = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordsFile, textFile, outputFile);
        }

        public static void CalculateWordCounts(string wordsFile, string textFile, string outputFile)
        {
            using StreamReader sr = new StreamReader(wordsFile);
            string[] line = sr.ReadLine()!.Split(' ');
            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach (var item in line)
            {
                counts.Add(item,0);
            }
            List<string> words = new List<string>();
            foreach (var word in counts)
            {
                words.Add(word.Key);
            }
            using StreamReader sr1 = new StreamReader(textFile);
            {
                while (!sr1.EndOfStream)
                {
                    string line1 = sr1.ReadLine();
                    int counter = 0;
                    foreach (var word in words)
                    {
                        if (line1.ToLower().Contains(word.ToLower()))
                        {
                            counter++;
                        }
                        counts[word] = counter;
                    }
                }
            }

            using StreamWriter sw = new StreamWriter(outputFile);
            foreach (var item in counts.OrderByDescending(x=> x.Value))
            {
                string line2 = item.Key + " " + item.Value;
                sw.WriteLine(line2);
            }
        }
    }
}
