namespace CP;
public class CPTemplate
{

    #region Class Level Variables
    private static StreamReader input;
    private static StreamWriter output;
    private static bool _isMultipleTestCases = true;

    #endregion Class Level Variables
    #region Main
    public static void Main()
    {
        using (input = new StreamReader(Console.OpenStandardInput()))
        using (output = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false })
        {
            // Read number of test cases
            int testCases = int.Parse(input.ReadLine());

            if(_isMultipleTestCases == false){
                testCases = 1;
            }

            for (int t = 0; t < testCases; t++)
            {
                Solve();
            }



            output.Flush();
        }
    }
    #endregion Main



    static void Solve()
    {
        // output.WriteLine("Shams");

    }



}
