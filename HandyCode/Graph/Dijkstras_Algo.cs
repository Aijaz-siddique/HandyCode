//Dijkstra's algorithm is used for finding the shortest path in weighted graphs with non-negative weights.

void Dijkstra(int start, List<(int, int)>[] adjList, int[] dist) {
    int n = adjList.Length;
    bool[] visited = new bool[n];
    PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();
    pq.Enqueue((start, 0), 0);
    dist[start] = 0;

    while (pq.Count > 0) {
        var (u, d) = pq.Dequeue();
        if (visited[u]) continue;
        visited[u] = true;

        foreach (var (v, weight) in adjList[u]) {
            if (dist[u] + weight < dist[v]) {
                dist[v] = dist[u] + weight;
                pq.Enqueue((v, dist[v]), dist[v]);
            }
        }
    }
}
