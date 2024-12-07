//Useful for problems involving strings and prefix searches.

class TrieNode {
    public TrieNode[] Children = new TrieNode[26];
    public bool IsEndOfWord = false;
}

class Trie {
    private TrieNode root = new TrieNode();

    public void Insert(string word) {
        TrieNode node = root;
        foreach (char c in word) {
            int index = c - 'a';
            if (node.Children[index] == null) {
                node.Children[index] = new TrieNode();
            }
            node = node.Children[index];
        }
        node.IsEndOfWord = true;
    }

    public bool Search(string word) {
        TrieNode node = root;
        foreach (char c in word) {
            int index = c - 'a';
            if (node.Children[index] == null) {
                return false;
            }
            node = node.Children[index];
        }
        return node.IsEndOfWord;
    }

    public bool StartsWith(string prefix) {
        TrieNode node = root;
        foreach (char c in prefix) {
            int index = c - 'a';
            if (node.Children[index] == null) {
                return false;
            }
            node = node.Children[index];
        }
        return true;
    }
}
