namespace Teamplate
{
    class Program
    {
        class Graph
        {
            public int V; // Number of Vertices

            public List<int>[] adj; // adjacency lists

            // Constructor
            public Graph(int V)
            {
                this.V = V;
                adj = new List<int>[V];

                for (int i = 0; i < adj.Length; i++)
                    adj[i] = new List<int>();

            }

            // To add an edge to graph
            public void addEdge(int v, int w)
            {
                adj[v].Add(w);
            }


            public void DFSUtil(int s, List<bool> visited)
            {
                Stack<int> stack = new Stack<int>();
                stack.Push(s);

                while (stack.Count != 0)
                {
                    s = stack.Peek();
                    stack.Pop();
                    if (visited[s] == false)
                    {
                        Console.Write(s + " ");
                        visited[s] = true;
                    }

                    foreach (int itr in adj[s])
                    {
                        int v = itr;
                        if (!visited[v])
                            stack.Push(v);
                    }

                }
            }


            public void DFS()
            {
                List<bool> visited = new List<bool>(V);

                for (int i = 0; i < V; i++)
                    visited.Add(false);

                for (int i = 0; i < V; i++)
                    if (!visited[i])
                        DFSUtil(i, visited);
            }
        }

        // Driver code
        public static void Main(String[] args)
        {
            Graph g = new Graph(5);
            g.addEdge(1, 0);
            g.addEdge(2, 1);
            g.addEdge(3, 4);
            g.addEdge(4, 0);

            Console.WriteLine("DFS Traversal:");
            g.DFS();
        }
    }

}
