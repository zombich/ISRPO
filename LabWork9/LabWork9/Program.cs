using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork9
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            string filePath = "data.txt";

            var project = new Project();
            await project.ReadFromFile(filePath);

            await project.WriteToFile(filePath, " Some data to be written to the file");

            //Console.WriteLine("Fibonacci Sequence:");
            //for (int i = 0; i < 20; i++)
            //{
            //    Console.WriteLine($"Fib({i}) = {project.Fibonacci(i)}");
            //}
        }
    }
}