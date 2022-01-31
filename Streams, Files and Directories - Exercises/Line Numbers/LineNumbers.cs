using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFile = @"..\..\..\text.txt";
            string outputFile = @"..\..\..\output.txt";
            ProcessLines(inputFile,outputFile);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            string[] chars = new string[] { "-", ",", ".", "!", "?","'" };
            string[] lines1 = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                int countSpecialchars = 0;
                int countSpaces = 0;
                var count = lines[i].Length;
                foreach (var item in chars)
                {
                    foreach (var item2  in lines[i])
                    {
                        if (item2 == char.Parse(item))
                        {
                            countSpecialchars++;
                        }
                    }
                }

                foreach (var item in lines[i])
                {
                    if (item == ' ')
                    {
                        countSpaces++;
                    }
                }

                lines1[i] =
                    $"Line {i}: {lines[i]} ({count - countSpaces - countSpecialchars})({countSpecialchars})";
            }
            File.WriteAllLines(outputFilePath,lines1);
        }

    }
}
