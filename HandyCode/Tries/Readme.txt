Tries (also known as prefix trees) are a type of search tree used to store associative data structures. They are particularly useful for problems involving strings, such as autocomplete, spell checker, and longest prefix matching. Here are some famous algorithms and problems involving tries that are commonly asked in competitive programming (CP) and on platforms like LeetCode:

1. Insert and Search in a Trie
Problem: Implement a trie with insert, search, and startsWith methods.

Approach:

Use a nested dictionary or a custom TrieNode class to represent the trie.
For insert, traverse the trie and add nodes as needed.
For search, traverse the trie and check if the word exists.
For startsWith, traverse the trie and check if the prefix exists.
