using System.IO;

namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";
            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using StreamReader sr = new StreamReader(inputFilePath);
            using StreamWriter sw = new StreamWriter(outputFilePath);
            int rowCounter = 0;
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                if (rowCounter % 2 == 1)
                {
                    sw.WriteLine(line);
                }

                rowCounter++;
            }
        }
    }
}
