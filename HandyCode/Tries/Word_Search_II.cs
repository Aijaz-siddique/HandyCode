Problem: Given a 2D board and a list of words, find all words in the board.

Approach:

Use a trie to store the list of words.
Use backtracking to explore the board and search for words in the trie.
Implementation:

C#

using System;
using System.Collections.Generic;

class TrieNode
{
    public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
    public string Word = null;
}

class Trie
{
    public TrieNode Root = new TrieNode();

    public void Insert(string word)
    {
        TrieNode node = Root;
        foreach (char c in word)
        {
            if (!node.Children.ContainsKey(c))
            {
                node.Children[c] = new TrieNode();
            }
            node = node.Children[c];
        }
        node.Word = word;
    }
}

class WordSearchII
{
    private static readonly int[][] Directions = new int[][]
    {
        new int[] { 0, 1 }, new int[] { 1, 0 },
        new int[] { 0, -1 }, new int[] { -1, 0 }
    };

    public IList<string> FindWords(char[][] board, string[] words)
    {
        List<string> result = new List<string>();
        Trie trie = new Trie();
        foreach (string word in words)
        {
            trie.Insert(word);
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                Backtrack(board, i, j, trie.Root, result);
            }
        }

        return result;
    }

    private void Backtrack(char[][] board, int row, int col, TrieNode node, List<string> result)
    {
        char c = board[row][col];
        if (!node.Children.ContainsKey(c))
        {
            return;
        }

        TrieNode nextNode = node.Children[c];
        if (nextNode.Word != null)
        {
            result.Add(nextNode.Word);
            nextNode.Word = null; // Avoid duplicate entries
        }

        board[row][col] = '#'; // Mark the cell as visited
        foreach (int[] direction in Directions)
        {
            int newRow = row + direction[0];
            int newCol = col + direction[1];
            if (newRow >= 0 && newRow < board.Length && newCol >= 0 && newCol < board[0].Length)
            {
                Backtrack(board, newRow, newCol, nextNode, result);
            }
        }
        board[row][col] = c; // Unmark the cell
    }
}

class Program
{
    static void Main(string[] args)
    {
        char[][] board = new char[][]
        {
            new char[] { 'o', 'a', 'a', 'n' },
            new char[] { 'e', 't', 'a', 'e' },
            new char[] { 'i', 'h', 'k', 'r' },
            new char[] { 'i', 'f', 'l', 'v' }
        };
        string[] words = { "oath", "pea", "eat", "rain" };
        WordSearchII solver = new WordSearchII();
        IList<string> result = solver.FindWords(board, words);
        foreach (string word in result)
        {
            Console.WriteLine(word);
        }
    }
}
