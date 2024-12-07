Problem: Given an array of numbers, find the maximum XOR of any two numbers.

Approach:

Use a trie to store the binary representations of the numbers.
For each number, find the maximum XOR by traversing the trie.
Implementation:

C#

using System;
using System.Collections.Generic;

class TrieNode
{
    public TrieNode[] Children = new TrieNode[2];
}

class Trie
{
    private TrieNode root = new TrieNode();

    public void Insert(int num)
    {
        TrieNode node = root;
        for (int i = 31; i >= 0; i--)
        {
            int bit = (num >> i) & 1;
            if (node.Children[bit] == null)
            {
                node.Children[bit] = new TrieNode();
            }
            node = node.Children[bit];
        }
    }

    public int GetMaxXOR(int num)
    {
        TrieNode node = root;
        int maxXOR = 0;
        for (int i = 31; i >= 0; i--)
        {
            int bit = (num >> i) & 1;
            if (node.Children[1 - bit] != null)
            {
                maxXOR |= (1 << i);
                node = node.Children[1 - bit];
            }
            else
            {
                node = node.Children[bit];
            }
        }
        return maxXOR;
    }
}

class MaximumXOR
{
    public int FindMaximumXOR(int[] nums)
    {
        Trie trie = new Trie();
        foreach (int num in nums)
        {
            trie.Insert(num);
        }

        int maxXOR = 0;
        foreach (int num in nums)
        {
            maxXOR = Math.Max(maxXOR, trie.GetMaxXOR(num));
        }

        return maxXOR;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 3, 10, 5, 25, 2, 8 };
        MaximumXOR solver = new MaximumXOR();
        int result = solver.FindMaximumXOR(nums);
        Console.WriteLine(result); // Output: 28
    }
}
