namespace Templates
{
    public class Program
    {
        /*
         * TC = log(n)
         * SC = log(n)
         * 
         */
        public long Power(int x, int y)
        {
            if(y == 0)
            {
                return 1;
            }

            long val = Power(x, y/ 2);

            if ((y&1) != 1) //Odd number
            {
                return  val * val;
            }
            else
            {
                return x * val * val;
            }
        }

        /*
         * Extend the Power function to work for negative n and float x:
         * 
         */
        public float NegativePower(float x, int y)
        {
            float val;
            if (y == 0)
                return 1;

            val = NegativePower(x, y / 2);

            if (y % 2 == 0)
                return val * val;
            else
            {
                if (y > 0)
                    return x * val * val;
                else
                    return (val * val) / x;
            }
        }


        public static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine(program.Power(2,10));

            float x = 2;
            int y = -3;
            Console.WriteLine(program.NegativePower(x,y));
        }

    }
}
