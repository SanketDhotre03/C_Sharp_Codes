// Program: HashTable
// Difficulty: Medium
// Description: Implements a simple hash table with chaining for collision resolution.
using System;
using System.Collections.Generic;

class HashTable
{
    const int SIZE = 10;
    List<(string Key, int Value)>[] buckets = new List<(string, int)>[SIZE];

    int Hash(string key) => Math.Abs(key.GetHashCode()) % SIZE;

    void Put(string key, int value)
    {
        int h = Hash(key);
        buckets[h] ??= new List<(string, int)>();
        for (int i = 0; i < buckets[h].Count; i++)
            if (buckets[h][i].Key == key) { buckets[h][i] = (key, value); return; }
        buckets[h].Add((key, value));
    }

    int Get(string key)
    {
        int h = Hash(key);
        if (buckets[h] == null) throw new Exception("Key not found");
        foreach (var (k, v) in buckets[h]) if (k == key) return v;
        throw new Exception("Key not found");
    }

    static void Main(string[] args)
    {
        var ht = new HashTable();
        ht.Put("name", 1); ht.Put("age", 25); ht.Put("score", 99);
        Console.WriteLine($"age = {ht.Get("age")}");
        Console.WriteLine($"score = {ht.Get("score")}");
    }
}
