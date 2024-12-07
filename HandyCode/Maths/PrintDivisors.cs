namespace Templates
{
    public class Program
    {
        
        //Print all the factors of a given number
        public void PrintDivisors(int n)
        {
            for(int i = 1; i <= Math.Sqrt(n); i++)
            {
                if(n%i == 0)
                {
                    Console.Write($"{i}, ");

                    int otherFactor = n / i;
                    if(otherFactor != i)
                    {
                        Console.Write($"{otherFactor}, ");
                    }
                }
            }

        }


        public static void Main(string[] args)
        {
            Program program = new Program();

            program.PrintDivisors(100);

        }

    }
}
