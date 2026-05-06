// Program: Trie
// Difficulty: High
// Description: Implements a Trie (prefix tree) for fast word lookup.
using System;
using System.Collections.Generic;

class Trie
{
    class TrieNode
    {
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        public bool IsEnd;
    }

    TrieNode root = new TrieNode();

    void Insert(string word)
    {
        var node = root;
        foreach (char c in word)
        {
            if (!node.Children.ContainsKey(c)) node.Children[c] = new TrieNode();
            node = node.Children[c];
        }
        node.IsEnd = true;
    }

    bool Search(string word)
    {
        var node = root;
        foreach (char c in word)
        {
            if (!node.Children.ContainsKey(c)) return false;
            node = node.Children[c];
        }
        return node.IsEnd;
    }

    bool StartsWith(string prefix)
    {
        var node = root;
        foreach (char c in prefix)
        {
            if (!node.Children.ContainsKey(c)) return false;
            node = node.Children[c];
        }
        return true;
    }

    static void Main(string[] args)
    {
        var trie = new Trie();
        trie.Insert("apple"); trie.Insert("app"); trie.Insert("application");
        Console.WriteLine(trie.Search("app"));         // True
        Console.WriteLine(trie.Search("appl"));        // False
        Console.WriteLine(trie.StartsWith("appl"));    // True
    }
}
