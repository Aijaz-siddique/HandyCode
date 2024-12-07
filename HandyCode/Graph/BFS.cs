namespace Template
{
    class Program
    {
        // BFS from given source s
        public void BFS(List<List<int>> adj, int s, bool[] visited)
        {
            Queue<int> q = new Queue<int>();

            visited[s] = true;
            q.Enqueue(s);

            while (q.Count > 0)
            {
                int curr = q.Dequeue();
                Console.Write(curr + " ");

                foreach (int x in adj[curr])
                {
                    if (!visited[x])
                    {
                        visited[x] = true;
                        q.Enqueue(x);
                    }
                }
            }
        }

        
        public static void Main()
        {
            Program program = new Program();

            int V = 6;
            List<List<int>> adj = new List<List<int>>(V);

            for (int i = 0; i < V; i++)
            {
                adj.Add(new List<int>());
            }

            program.AddEdge(adj, 0, 1);
            program.AddEdge(adj, 0, 2);
            program.AddEdge(adj, 3, 4);
            program.AddEdge(adj, 4, 5);



            bool[] visited = new bool[adj.Count]; // Initialize every node to be non visited.
            for (int i = 0; i < adj.Count; i++)
            {
                if (!visited[i])
                {
                    program.BFS(adj, i, visited);
                }
            }

        }

        public void AddEdge(List<List<int>> adj, int u, int v)
        {
            adj[u].Add(v);
            adj[v].Add(u); // Undirected graph
        }

    }
}
