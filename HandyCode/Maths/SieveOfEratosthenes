namespace Templates
{
    public class Program
    {

        private bool[] _prime;

        public void SieveOfEratosthenes(int n)
        {
            _prime = new bool[n+1];

            for (int i = 2; i <= n; i++)
                _prime[i] = true;

            for (int p = 2; p * p <= n; p++)
            {

                if (_prime[p] == true)
                {
                    for (int i = p * p; i <= n; i += p)
                        _prime[i] = false;
                }
            }
        }

        public void PrintPrimeNumbers()
        {
            for(int i = 2; i < _prime.Length; i++)
            {
                if(_prime[i] == true)
                {
                    Console.Write($"{i}, ");
                }
            }
        }


        public static void Main(string[] args)
        {
            Program program = new Program();

            program.SieveOfEratosthenes(105);
            program.PrintPrimeNumbers();

        }

    }
}
