namespace Templates
{
    public class Program
    {
        /*
         * Definition: A number is an armstrong number is sum of each of its digit raised to the power of digitCount of the number
         * is euqal to the original number.
         * 
         * Mathematically:
         *  abcd... = Pow(a,n) + Pow(b, n) + Pow(c, n) + Pow(d, n) .... n times
         */
        public bool IsArmstrong(int n)
        {
            int digitCount = (int) Math.Log10((double)n) + 1;
            int sum = 0;
            int originalNum = n;
            while(n > 0)
            {
                int rem = n % 10;
                sum += (int) Math.Pow(rem, digitCount);
                n /= 10;
            }

            return sum == originalNum;
        }


        public static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine(program.IsArmstrong(153));
        }

    }
}
