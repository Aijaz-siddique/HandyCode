namespace Templates
{
    public class Program
    {
        
        public bool IsPrime(int n)
        {
            if(n <= 1) return false;

            for(int i = 2; i <= Math.Sqrt(n); i++)
            {
                if(n%i == 0)
                {
                    return false;
                }
                 
            }

            return true;

        }


        public static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine(program.IsPrime(53));

        }

    }
}
