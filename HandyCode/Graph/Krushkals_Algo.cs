//Kruskal's algorithm is used for finding the Minimum Spanning Tree (MST) of a graph.

//C#

void Kruskal(List<(int, int, int)> edges, int n) {
    edges.Sort((a, b) => a.Item3.CompareTo(b.Item3));
    UnionFind uf = new UnionFind(n);
    int mstWeight = 0;

    foreach (var (u, v, weight) in edges) {
        if (uf.Find(u) != uf.Find(v)) {
            uf.Union(u, v);
            mstWeight += weight;
            Console.WriteLine($"Edge ({u}, {v}) with weight {weight} added to MST");
        }
    }

    Console.WriteLine($"Total weight of MST: {mstWeight}");
}
