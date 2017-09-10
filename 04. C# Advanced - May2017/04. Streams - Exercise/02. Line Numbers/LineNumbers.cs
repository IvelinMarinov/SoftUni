using System.IO;

namespace _02.Line_Numbers
{
    public class LineNumbers
    {
        public static void Main()
        {
            using (StreamReader reader = new StreamReader("../../input.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../output.txt"))
                {
                    var line = reader.ReadLine();
                    var lineNumber = 1;

                    while (line != null)
                    {
                        writer.WriteLine($"Line {lineNumber}: {line}");
                        lineNumber++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
