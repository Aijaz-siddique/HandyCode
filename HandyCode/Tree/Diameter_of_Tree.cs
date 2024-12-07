
/*
The diameter of a tree is the longest path between any two nodes in the tree. This path may or may not pass through the root. To find the diameter of a tree, you can use a two-pass Depth-First Search (DFS) approach:

Perform a DFS from any node to find the farthest node from it. Let's call this node A.
Perform another DFS from node A to find the farthest node from A. Let's call this node B.
The distance between A and B is the diameter of the tree.
*/

using System;
using System.Collections.Generic;

class TreeDiameter
{
    private List<int>[] adjList;
    private int maxDistance;
    private int farthestNode;

    public TreeDiameter(int n)
    {
        adjList = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            adjList[i] = new List<int>();
        }
    }

    public void AddEdge(int u, int v)
    {
        adjList[u].Add(v);
        adjList[v].Add(u);
    }

    private void DFS(int node, int parent, int distance)
    {
        if (distance > maxDistance)
        {
            maxDistance = distance;
            farthestNode = node;
        }

        foreach (var neighbor in adjList[node])
        {
            if (neighbor != parent)
            {
                DFS(neighbor, node, distance + 1);
            }
        }
    }

    public int GetDiameter()
    {
        // First DFS to find the farthest node from any node (let's start from node 0)
        maxDistance = -1;
        DFS(0, -1, 0);
        int startNode = farthestNode;

        // Second DFS from the farthest node found in the first DFS
        maxDistance = -1;
        DFS(startNode, -1, 0);

        return maxDistance;
    }

    public static void Main(string[] args)
    {
        int n = 7; // Number of nodes in the tree
        TreeDiameter tree = new TreeDiameter(n);

        // Adding edges to form the tree
        tree.AddEdge(0, 1);
        tree.AddEdge(0, 2);
        tree.AddEdge(1, 3);
        tree.AddEdge(1, 4);
        tree.AddEdge(2, 5);
        tree.AddEdge(2, 6);

        int diameter = tree.GetDiameter();
        Console.WriteLine($"The diameter of the tree is {diameter}");
    }
}

