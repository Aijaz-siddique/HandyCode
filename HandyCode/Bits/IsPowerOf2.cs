namespace Templates
{
    public class Program
    {
        /*
         * Check if the given number is power of 2
         * TC = O(1)
         */
        public bool IsPowerOf2(int n)
        {

            if( (n & (n-1)) == 0)
            {
                return true; //power of 2
            }
            
            
            return false; //not a power of 2
        }


        public static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine(p.IsPowerOf2(16));
        }
    }
}
