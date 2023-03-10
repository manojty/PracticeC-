using System;
using System.Collections.Generic;


public class Trie 
{
    public Trie()
    {
        key = new Dictionary<char, Trie>();
        isFinalNode = false;
    }
    
    Dictionary<char, Trie> key;
    bool isFinalNode = false;
    

    public void Insert(string str)
    {
        Trie node = this;
        Trie previous = node;
        foreach(char c in str)
        {
            previous = node;
            if (node.key.ContainsKey(c))
            {
                node = node.key[c];
            }
            else
            {
                node.key.Add(c,new Trie());
                node = node.key[c];
            }
        }
        previous.isFinalNode = true;
    }

    public bool Search(string word)
    {
        Trie node = this;
        Trie previous = node;
    
        foreach(char c in word)
        {
            if (node.key.ContainsKey(c))
            {
                previous = node;
                node = node.key[c];
            }
            else
            {
                return false;
            }
        }
        if (previous.isFinalNode)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool startsWith(string prifix)
    {
        
        Trie node = this;
        Trie previous = node;
    
        foreach(char c in prifix)
        {
            if (node.key.ContainsKey(c))
            {
                previous = node;
                node = node.key[c];
            }
            else
            {
                return false;
            }
        }
        if (previous.isFinalNode)
        {
            return true;
        }
        return isThisFinalNOde(node);        
    }
    
    bool isThisFinalNOde(Trie node)
    {
        if (node.isFinalNode) 
            return true;
        foreach(char key in node.key.Keys)
        {
            return isThisFinalNOde(node.key[key]);
        }
        return false;
    }
}

public class TestTrie
{
    public static void testInsert()
    {
        List<string> strings = new List<string>{"Trie", "insert", "search", "search", "startsWith", "search", "apple", "app", "app"};
        Trie trie = new Trie();
        foreach (string s in strings)
        {
            trie.Insert(s);            
        }
    }
    public static void testSearch()
    {
        List<string> strings = new List<string>{"Trie", "insert", "search", "search", "startsWith", "search", "apple", "app", "app"};
        Trie trie = new Trie();
        foreach (string s in strings)
        {
            trie.Insert(s);            
        }

        if (trie.Search("apple"))
        {
            Console.WriteLine("Found");
        }
        
        if (!trie.Search("appl"))
        {
            Console.WriteLine("not found");
        }
        if (trie.startsWith("appl"))
        {
            Console.WriteLine("Yes!!!");
        }
    }

}