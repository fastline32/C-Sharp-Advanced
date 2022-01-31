using System.IO;

namespace CopyFile
{
    internal class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputFile = @"..\..\..\copyMe.png";
            string outputFile = @"..\..\..\copyMe-copy.png";
            CopyFile(inputFile,outputFile);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using FileStream streamWriter = new FileStream(outputFilePath, FileMode.Create);
            byte[] middle = File.ReadAllBytes(inputFilePath);
            streamWriter.Write(middle);
        }

    }
}