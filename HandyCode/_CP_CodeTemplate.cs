using System;
using System.IO;
using System.Text;

class CPTemplate
{
    // Class-level variables for input and output
    private static StreamReader input;
    private static StreamWriter output;

    static void Main()
    {
        input = new StreamReader(Console.OpenStandardInput());
        output = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };

        try
        {
            // Read number of test cases
            int testCases = int.Parse(input.ReadLine());

            for (int t = 0; t < testCases; t++)
            {
                // Call the method to solve each test case
                Solve();
            }

            // Ensure all output is flushed
            output.Flush();
        }
        finally
        {
            input.Dispose();
            output.Dispose();
        }
    }

    static void Solve()
    {
        // Example: Read an integer
        int n = int.Parse(input.ReadLine());

        // Example: Read an array of integers
        string[] tokens = input.ReadLine().Split();
        int[] array = Array.ConvertAll(tokens, int.Parse);

        // Example: Process the data (this is where your solution logic goes)
        int result = ProcessData(n, array);

        // Example: Write the result
        output.WriteLine(result);
    }

    static int ProcessData(int n, int[] array)
    {
        // Implement your logic here
        // This is just a placeholder example that returns the sum of the array
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += array[i];
        }
        return sum;
    }
}
