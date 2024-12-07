using System;
using System.IO;

class Program
{
    static void Main()
    {
        var input = new StreamReader(Console.OpenStandardInput());
        var output = new StreamWriter(Console.OpenStandardOutput());
        string line;
        while ((line = input.ReadLine()) != null)
        {
            // Process the line
            output.WriteLine(line);
        }
        output.Flush();
    }
}
