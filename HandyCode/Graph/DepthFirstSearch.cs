//DFS is useful for exploring all possible paths in a graph, detecting cycles, and for backtracking problems.

void DFS(int node, List<int>[] adjList, bool[] visited) {
    visited[node] = true;
    Console.WriteLine(node);
    foreach (var neighbor in adjList[node]) {
        if (!visited[neighbor]) {
            DFS(neighbor, adjList, visited);
        }
    }
}
