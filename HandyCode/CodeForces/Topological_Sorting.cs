//Useful for problems involving Directed Acyclic Graphs (DAGs).

void TopologicalSort(List<int>[] adjList, int v, bool[] visited, Stack<int> stack) {
    visited[v] = true;
    foreach (var neighbor in adjList[v]) {
        if (!visited[neighbor]) {
            TopologicalSort(adjList, neighbor, visited, stack);
        }
    }
    stack.Push(v);
}

void TopologicalSortUtil(List<int>[] adjList, int vertices) {
    Stack<int> stack = new Stack<int>();
    bool[] visited = new bool[vertices];
    for (int i = 0; i < vertices; i++) {
        if (!visited[i]) {
            TopologicalSort(adjList, i, visited, stack);
        }
    }
    while (stack.Count > 0) {
        Console.Write(stack.Pop() + " ");
    }
}
