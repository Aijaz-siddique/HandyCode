//Floyd-Warshall algorithm is used for finding shortest paths between all pairs of vertices in a weighted graph.

//C#

void FloydWarshall(int[,] graph, int n) {
    int[,] dist = new int[n, n];
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            dist[i, j] = graph[i, j];
        }
    }

    for (int k = 0; k < n; k++) {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (dist[i, k] + dist[k, j] < dist[i, j]) {
                    dist[i, j] = dist[i, k] + dist[k, j];
                }
            }
        }
    }
}
