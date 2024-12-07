//Useful for problems involving tree structures and dynamic programming.

void DFS(int node, int parent, List<int>[] adjList, int[] dp) {
    dp[node] = 1;
    foreach (var neighbor in adjList[node]) {
        if (neighbor != parent) {
            DFS(neighbor, node, adjList, dp);
            dp[node] += dp[neighbor];
        }
    }
}
