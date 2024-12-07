using System.Diagnostics;

namespace Templates
{
    public class Program
    {
        static Stopwatch _stopWatch = new Stopwatch();

        public long Power(int x, int y)
        {
            if (y == 0)
            {
                return 1;
            }

            long val = Power(x, y / 2);

            if ((y & 1) != 1) //Odd number
            {
                return val * val;
            }
            else
            {
                return x * val * val;
            }
        }

        public static void Main(string[] args)
        {
            Program program = new Program();

            _stopWatch.Start();
            Console.WriteLine(program.Power(2, 12));
            _stopWatch.Stop();
            Console.WriteLine($"Elapsed Time = {_stopWatch.ElapsedMilliseconds} ms");
        }
    }
}
