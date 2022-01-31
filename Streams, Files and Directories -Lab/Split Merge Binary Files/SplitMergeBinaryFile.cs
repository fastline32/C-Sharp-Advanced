using System.IO;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string example = @"..\..\..\Files\example.png";
            string output1 = @"..\..\..\Files\part-1.bin";
            string output2 = @"..\..\..\Files\part-2.bin";
            string outputFinal = @"..\..\..\Files\example-joined.png";

            SplitBinaryFile(example, output1, output2);

            MergeBinaryFiles(output1,output2,outputFinal);

        }
        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using FileStream newFileStream = new FileStream(sourceFilePath,FileMode.Open);
            long size1 = 0;
            long size2 = 0;
            if (newFileStream.Length % 2 == 0)
            {
                size1 = size2 = newFileStream.Length / 2;
            }
            else
            {
                size1 = newFileStream.Length / 2 + 1;
                size2 = newFileStream.Length / 2;
            }

            byte[] data1 = new byte[size1];
            byte[] data2 = new byte[size2];

            newFileStream.Read(data1, 0, data1.Length);
            newFileStream.Read(data2, 0 , data2.Length);

            using (FileStream writer = new FileStream(partOneFilePath, FileMode.OpenOrCreate))
            {
                writer.Write(data1);
                writer.Close();
            }

            using (FileStream writer2 = new FileStream(partTwoFilePath,FileMode.OpenOrCreate))
            {
                writer2.Write(data2);
                writer2.Close();
            }
            newFileStream.Close();
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
           using (FileStream reader = new FileStream(partOneFilePath,FileMode.OpenOrCreate))
           {
               byte[] file1 = new byte[reader.Length];
               reader.Read(file1);
               using (FileStream reader1 = new FileStream(partTwoFilePath,FileMode.Open))
               {
                   byte[] file2 = new byte[reader1.Length];
                   reader1.Read(file2);
                    using (FileStream writer = new FileStream(joinedFilePath,FileMode.OpenOrCreate))
                    {
                        writer.Write(file1,0,file1.Length);
                        writer.Write(file2,0,file2.Length);
                        writer.Close();
                    }
                    reader1.Close();
               }
               reader.Close();
           }
        }
    }

}
