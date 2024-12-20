using System;
using System.Collections.Generic;

class TrieNode
{
    public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
    public bool IsEndOfWord = false;
}

class Trie
{
    private TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    public void Insert(string word)
    {
        TrieNode node = root;
        foreach (char c in word)
        {
            if (!node.Children.ContainsKey(c))
            {
                node.Children[c] = new TrieNode();
            }
            node = node.Children[c];
        }
        node.IsEndOfWord = true;
    }

    public bool Search(string word)
    {
        TrieNode node = root;
        foreach (char c in word)
        {
            if (!node.Children.ContainsKey(c))
            {
                return false;
            }
            node = node.Children[c];
        }
        return node.IsEndOfWord;
    }

    public bool StartsWith(string prefix)
    {
        TrieNode node = root;
        foreach (char c in prefix)
        {
            if (!node.Children.ContainsKey(c))
            {
                return false;
            }
            node = node.Children[c];
        }
        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Trie trie = new Trie();
        trie.Insert("apple");
        Console.WriteLine(trie.Search("apple"));   // returns true
        Console.WriteLine(trie.Search("app"));     // returns false
        Console.WriteLine(trie.StartsWith("app")); // returns true
        trie.Insert("app");
        Console.WriteLine(trie.Search("app"));     // returns true
    }
}
