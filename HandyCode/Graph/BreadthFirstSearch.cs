//BFS is useful for finding the shortest path in unweighted graphs and for level-order traversal of trees.

void BFS(int start, List<int>[] adjList) {
    bool[] visited = new bool[adjList.Length];
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(start);
    visited[start] = true;
    while (queue.Count > 0) {
        int node = queue.Dequeue();
        Console.WriteLine(node);
        foreach (var neighbor in adjList[node]) {
            if (!visited[neighbor]) {
                visited[neighbor] = true;
                queue.Enqueue(neighbor);
            }
        }
    }
}
