using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Extract_Special_Bytes
{
    public class ExtractBytes
    {
        static void Main(string[] args)
        {
            string firstBinary = @"..\..\..\Files\bytes.txt";
            string secondBinary = @"..\..\..\Files\example.png";
            string output = @"..\..\..\Files\output.bin";
            ExtractBytesFromBinaryFile(firstBinary,secondBinary,output);

        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using StreamReader streamReader = new StreamReader(binaryFilePath);
            int sum = 0;
            while (!streamReader.EndOfStream)
            {
                sum += int.Parse(streamReader.ReadLine());
            }

            byte[] buffer = new byte[sum];

            using FileStream fileStreamReadr = new FileStream(bytesFilePath, FileMode.Open, FileAccess.Read);

            using FileStream fileStreamWriter = new FileStream(outputPath, FileMode.Create, FileAccess.Write);


            int bytes = fileStreamReadr.Read(buffer, 0, buffer.Length);

            fileStreamWriter.Write(buffer, 0, bytes);
        }

    }
}
