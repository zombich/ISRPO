using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace LabWork9
{
    public class Project
    {
        //Dictionary<int, int> _fibonacciCache

        public async Task ReadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }

            using (var reader = new StreamReader(filePath, Encoding.UTF8, true, 8192 ))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public async Task WriteToFile(string filePath, string data)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true, Encoding.UTF8, 8192))
            {
                await writer.WriteAsync(data);
            }
        }

        //public int Fibonacci(int n)
        //{
        //    if (n <= 1)
        //        return n;
        //    return Fibonacci(n - 1) + Fibonacci(n - 2);
        //}
    }
}
