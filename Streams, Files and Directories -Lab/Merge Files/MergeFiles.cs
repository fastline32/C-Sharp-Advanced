using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            string input1 = @"..\..\..\Files\input1.txt";
            string input2 = @"..\..\..\Files\input2.txt";
            string outputFile = @"..\..\..\Files\output.txt";
            MergeTextFiles(input1, input2, outputFile);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using StreamWriter output = new StreamWriter(outputFilePath);
            string[] line1 = File.ReadAllLines(firstInputFilePath);
            string[] line2 = File.ReadAllLines(secondInputFilePath);
            for (int i = 0; i < line1.Length; i++)
            {
                output.WriteLine(line1[i]);
                output.WriteLine(line2[i]);
            }
        }
    }
}
