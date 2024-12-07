// BFS
void BFS(int start, List<int>[] adjList) {
    bool[] visited = new bool[adjList.Length];
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(start);
    visited[start] = true;
    while (queue.Count > 0) {
        int node = queue.Dequeue();
        foreach (var neighbor in adjList[node]) {
            if (!visited[neighbor]) {
                visited[neighbor] = true;
                queue.Enqueue(neighbor);
            }
        }
    }
}

// DFS
void DFS(int node, List<int>[] adjList, bool[] visited) {
    visited[node] = true;
    foreach (var neighbor in adjList[node]) {
        if (!visited[neighbor]) {
            DFS(neighbor, adjList, visited);
        }
    }
}
