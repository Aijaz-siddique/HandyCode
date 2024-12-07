//Finding the lowest common ancestor in a tree.

//C#

class LCA {
    private int[] depth;
    private int[,] parent;

    public LCA(List<int>[] adjList, int root) {
        int n = adjList.Length;
        depth = new int[n];
        int log = (int)Math.Log2(n) + 1;
        parent = new int[n, log];
        DFS(adjList, root, -1, 0);
        for (int j = 1; j < log; j++) {
            for (int i = 0; i < n; i++) {
                if (parent[i, j - 1] != -1) {
                    parent[i, j] = parent[parent[i, j - 1], j - 1];
                }
            }
        }
    }

    private void DFS(List<int>[] adjList, int node, int par, int dep) {
        parent[node, 0] = par;
        depth[node] = dep;
        foreach (var neighbor in adjList[node]) {
            if (neighbor != par) {
                DFS(adjList, neighbor, node, dep + 1);
            }
        }
    }

    public int Query(int u, int v) {
        if (depth[u] < depth[v]) {
            int temp = u;
            u = v;
            v = temp;
        }
        int log = (int)Math.Log2(depth[u]) + 1;
        for (int i = log; i >= 0; i--) {
            if (depth[u] - (1 << i) >= depth[v]) {
                u = parent[u, i];
            }
        }
        if (u == v) return u;
        for (int i = log; i >= 0; i--) {
            if (parent[u, i] != -1 && parent[u, i] != parent[v, i]) {
                u = parent[u, i];
                v = parent[v, i];
            }
        }
        return parent[u, 0];
    }
}
