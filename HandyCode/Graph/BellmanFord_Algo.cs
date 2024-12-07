//Bellman-Ford algorithm is used for finding the shortest path in graphs with negative weights.

//C#

void BellmanFord(int start, List<(int, int, int)> edges, int[] dist, int n) {
    dist[start] = 0;
    for (int i = 0; i < n - 1; i++) {
        foreach (var (u, v, weight) in edges) {
            if (dist[u] != int.MaxValue && dist[u] + weight < dist[v]) {
                dist[v] = dist[u] + weight;
            }
        }
    }
}
