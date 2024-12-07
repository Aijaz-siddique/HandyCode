namespace Teamplate
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            //maxHeap
            var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));

            //minHeap
            var minHeap = new PriorityQueue<int, int>(); // PriorityQueue<int, int> minHeap = new(); }


    }

}
