namespace Template
{
    class Program
    {

        public void DFS(List<List<int>> adj, bool[] visited, int s)
        {

            visited[s] = true;
            Console.Write(s + " ");

            foreach (int i in adj[s])
            {
                if (!visited[i])
                {
                    DFS(adj, visited, i);
                }
            }
        }


        public static void Main()
        {
            Program program = new Program();

            int V = 5;
            
            List<List<int>> adj = new List<List<int>>(V);
            for (int i = 0; i < V; i++)
            {
                adj.Add(new List<int>());
            }

            // Define the edges of the graph
            int[,] edges = {
            { 1, 2 }, { 1, 0 }, { 2, 0 }, { 2, 3 }, { 2, 4 }
        };

            // Populate the adjacency list with edges
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                program.AddEdge(adj, edges[i, 0], edges[i, 1]);
            }

            int source = 1; // Starting vertex for DFS
            Console.WriteLine("DFS from source: " + source);

            bool[] visited = new bool[adj.Count];
            // Call the recursive DFS function
            program.DFS(adj, visited, source);
        }


        public void AddEdge(List<List<int>> adj, int s, int t)
        {
            adj[s].Add(t);
            adj[t].Add(s);
        }
    }

}
