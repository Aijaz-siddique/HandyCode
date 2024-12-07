namespace Templates
{
    public class Program
    {
        /*
         * TC = O(1)
         */
        public int CountDigits(int n)
        {
            return (int) Math.Log10((double)n) + 1;
        }


        public static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine(program.CountDigits(89696));
        }

    }
}
