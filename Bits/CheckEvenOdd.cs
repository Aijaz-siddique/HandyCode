namespace Templates
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Program program = new Program();

            program.PrintEvenOdd(15);

        }

        
        private  void PrintEvenOdd(int num)
        {
            
            /*
               A number when bitwise & with 1 returns 1 means it is odd.
               Becasue binary representation of all odd numbers has 1 in LSB
            
             */
            
            if ((num & 1) == 1)
            {
                Console.WriteLine("Odd");
            }
            else
            {
                Console.WriteLine("Even");
            }
        }
    }
}

