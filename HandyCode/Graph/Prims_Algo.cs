//Prim's algorithm is used for finding the Minimum Spanning Tree (MST) of a graph.

//C#

void Prim(int start, List<(int, int)>[] adjList) {
    int n = adjList.Length;
    bool[] inMST = new bool[n];
    int[] key = new int[n];
    int[] parent = new int[n];
    for (int i = 0; i < n; i++) {
        key[i] = int.MaxValue;
        parent[i] = -1;
    }
    key[start] = 0;
    PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();
    pq.Enqueue((start, 0), 0);

    while (pq.Count > 0) {
        var (u, k) = pq.Dequeue();
        inMST[u] = true;

        foreach (var (v, weight) in adjList[u]) {
            if (!inMST[v] && weight < key[v]) {
                key[v] = weight;
                pq.Enqueue((v, key[v]), key[v]);
                parent[v] = u;
            }
        }
    }

    for (int i = 1; i < n; i++) {
        if (parent[i] != -1) {
            Console.WriteLine($"Edge ({parent[i]}, {i}) with weight {key[i]} added to MST");
        }
    }
}
