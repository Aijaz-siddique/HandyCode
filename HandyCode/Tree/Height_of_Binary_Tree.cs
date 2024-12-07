/*
Concept: The height of a binary tree is the number of edges on the longest path from the root to a leaf.
It can be calculated using a recursive approach.

*/

using System;

class TreeNode
{
    public int Value;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

class BinaryTree
{
    public TreeNode Root;

    public BinaryTree()
    {
        Root = null;
    }

    public int GetHeight(TreeNode node)
    {
        if (node == null)
        {
            return -1; // Return -1 for height of an empty tree
        }

        int leftHeight = GetHeight(node.Left);
        int rightHeight = GetHeight(node.Right);

        return Math.Max(leftHeight, rightHeight) + 1;
    }

    public static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();
        tree.Root = new TreeNode(1);
        tree.Root.Left = new TreeNode(2);
        tree.Root.Right = new TreeNode(3);
        tree.Root.Left.Left = new TreeNode(4);
        tree.Root.Left.Right = new TreeNode(5);

        int height = tree.GetHeight(tree.Root);
        Console.WriteLine($"The height of the binary tree is {height}");
    }
}
