//Useful for handling path queries in trees.

//C#

class HLD {
    private int[] parent, depth, heavy, head, pos;
    private int curPos;
    private SegmentTree segTree;

    public HLD(List<int>[] adjList) {
        int n = adjList.Length;
        parent = new int[n];
        depth = new int[n];
        heavy = new int[n];
        head = new int[n];
        pos = new int[n];
        Array.Fill(heavy, -1);
        DFS(adjList, 0);
        Decompose(adjList, 0, 0);
        segTree = new SegmentTree(new int[n]);
    }

    private int DFS(List<int>[] adjList, int node) {
        int size = 1, maxSubtree = 0;
        foreach (var neighbor in adjList[node]) {
            if (neighbor != parent[node]) {
                parent[neighbor] = node;
                depth[neighbor] = depth[node] + 1;
                int subtreeSize = DFS(adjList, neighbor);
                if (subtreeSize > maxSubtree) {
                    maxSubtree = subtreeSize;
                    heavy[node] = neighbor;
                }
                size += subtreeSize;
            }
        }
        return size;
    }

    private void Decompose(List<int>[] adjList, int node, int h) {
        head[node] = h;
        pos[node] = curPos++;
        if (heavy[node] != -1) {
            Decompose(adjList, heavy[node], h);
        }
        foreach (var neighbor in adjList[node]) {
            if (neighbor != parent[node] && neighbor != heavy[node]) {
                Decompose(adjList, neighbor, neighbor);
            }
        }
    }

    public void Update(int node, int value) {
        segTree.Update(pos[node], value);
    }

    public int Query(int a, int b) {
        int res = 0;
        while (head[a] != head[b]) {
            if (depth[head[a]] > depth[head[b]]) {
                int temp = a;
                a = b;
                b = temp;
            }
            res = Math.Max(res, segTree.Query(pos[head[b]], pos[b] + 1));
            b = parent[head[b]];
        }
        if (depth[a] > depth[b]) {
            int temp = a;
            a = b;
            b = temp;
        }
        res = Math.Max(res, segTree.Query(pos[a], pos[b] + 1));
        return res;
    }
}
