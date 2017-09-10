using System.IO;

namespace _04.Copy_Binary_File
{
    public class CopyBinaryFile
    {
        public static void Main()
        {
            using (FileStream source = new FileStream("../../source.jpg", FileMode.Open))
            {
                using (FileStream destination = new FileStream("../../destination.jpg", FileMode.Create))
                {
                    var buffer = new byte[4096];
                    
                    while (true)
                    {
                        var readBytes = source.Read(buffer, 0, buffer.Length);

                        if (readBytes == 0)
                        {
                            break;
                        }

                        destination.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
