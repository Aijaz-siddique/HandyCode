namespace Templates
{
    public class Program
    {
        /*
          TC = log(min(a,b)
          SC = O(log(min(a,b)) --> because of Stack used in memeory
         */
        public int GCD(int a, int b)
        {
            if(b == 0)
            {
                return a;
            }

            return GCD(b, a % b);
        }

        
        // Iterative version to return gcd of a and b
        /*
         * TC = log(min(a,b))
         * SC = O(1)
         */
        public int GCDIterative(int a, int b)
        {
            while (a > 0 && b > 0)
            {
                if (a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }
            if (a == 0)
            {
                return b;
            }
            return a;
        }



        public static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine(program.GCD(6, 10));
            Console.WriteLine(program.GCDIterative(6, 10));

        }

    }
}
