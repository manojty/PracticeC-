
using System;
using System.Collections.Generic;
using System.Collections;

namespace PracticeC_
{

    public class Mixed
    {
        public Mixed()
        {

        }

    public static int HowManyBsts(int nodes)
    {
        int totalBst = 0;
        if (nodes == 0)
        {
            return 1;
        }
        if (nodes == 1 || nodes == 2)
        {
            return nodes;
        }
        
        for(int i = 1; i <= nodes; i++)
        {
            int leftBst = HowManyBsts(i-1);
            int rightBst = HowManyBsts(nodes - i);
            totalBst += leftBst * rightBst;
        }
        return totalBst;

    }
  
    
    
    public static List<string> PalindromicDecomposition(String s)
    {
        List<string> result = new List<string>();
        if (String.IsNullOrEmpty(s))
        {
            return result;
        }
        _PalindromicDecomposition(s.Remove(0,1), s.Substring(0,1), result);
        return result;
    }

    public static void _PalindromicDecomposition(String s, String slate, List<string> result)
    {
        if (s.Length == 0)
        {
            string lastStr = GetLastDecomposedString(slate);
            if (isPalindrome(lastStr))
            {
                result.Add(slate);
            }
            return;
        }
        string leftSlate = slate + s[0];
        _PalindromicDecomposition(s.Remove(0,1), leftSlate, result);
        string str = GetLastDecomposedString(slate);
        if (isPalindrome(str))
        {
            string rightSlate = slate + "|" + s[0];
            _PalindromicDecomposition(s.Remove(0,1), rightSlate, result);
        }
    } 

    public static string GetLastDecomposedString(string slate)
    {
        if (String.IsNullOrEmpty(slate))
        {
            return slate;
        }
        int lastIndexOfDelimiter = slate.LastIndexOf('|');
        return slate.Substring(lastIndexOfDelimiter + 1, slate.Length - (lastIndexOfDelimiter + 1));
    }

    public static List<string> easyPalindromSubstrings(String s)
    {
        List<string> result = new List<string>();
        for (int i = 0; i < s.Length; i++)
        {
            for(int j = i; j < s.Length; j++)
            {
                string temp = s.Substring(i, j-i+1);
                if (isPalindrome(temp))
                {
                    result.Add(temp);
                }
            }
        }
        return result;
    }
    
    public static List<string> PalindromeSubstrings(String s)
    {
        List<string> allPalindromicSubStrings = new List<string>();
        Dictionary<string,bool> uniquePal = new Dictionary<string,bool>();
        int[][] deDup = new int[s.Length][];
        for(int i = 0; i < s.Length; i++)
        {
            deDup[i] = new int[s.Length];
        }
        //int[,] deDup = new int[size,size] {};
        _PalindromeSubstrings(s, 0, s.Length - 1, allPalindromicSubStrings, deDup);
        return allPalindromicSubStrings;
    }

    public static void _PalindromeSubstrings(string s, int startIndex, int endIndex, List<string> allPalindromicSubStrings, int[][] deDup)
    {
        if (s.Length == 0)
        {
            return;
        }
        
        if (deDup[startIndex][endIndex] == 1)
        {
            return;
        }
        
        if (isPalindrome(s))
        {
            deDup[startIndex][endIndex] = 1;
            allPalindromicSubStrings.Add(s);
        }
        else
        {
            _PalindromeSubstrings(s.Remove(0,1),startIndex + 1, endIndex, allPalindromicSubStrings, deDup );
            _PalindromeSubstrings(s.Remove(s.Length-1,1),startIndex, endIndex-1, allPalindromicSubStrings, deDup);
        }
    }

    public static bool isPalindrome(string s)
    {
        if (s.Length == 0)
        {
            return false;
        }

        int start = 0;
        int last = s.Length - 1;
        while ((start <= last) && (s[start] ==  s[last]))
        {
            start++;
            last--;
        }
        if (start > last)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public static void TowerOfHanoi(int disks, char source, char destination, char aux)
    {
        if (disks == 1)
        {
            Console.WriteLine("Move " + source + " to " + destination);
        }
        else
        {
            TowerOfHanoi(disks - 1, source, aux, destination);
            Console.WriteLine("Move " + source + " to " + destination);
            TowerOfHanoi(disks - 1, aux, destination, source);
        }
    }
    
    
    public static List<string> generatePermutation(string s)
    {
        List<string> permutation = new List<string>();
        _generatePermutation(s, "", permutation);
        return permutation;
    }
    
    public static void _generatePermutation(string s, string slate, List<string> permutation)
    {
        if (s.Length == 0)
        {
            permutation.Add(slate);
        }
        else
        {
            foreach(char item in s)
            {
                int index = s.IndexOf(item);
                _generatePermutation(s.Remove(index,1), slate + item, permutation);
            }
        }
    }
    
    public static List<string> generate_all_subsets(string s) 
    {
        // Write your code here.
        List<string> sets = new List<string>();
        _generate_all_subsets(s,"",sets);
        return sets;
    }

    public static void _generate_all_subsets(string s, string slate, List<string> sets)
    {
        // Base condition
        if (s.Length == 0)
        {
            sets.Add(slate);
        }
        else
        {
            _generate_all_subsets(s.Remove(0,1),slate, sets);
            _generate_all_subsets(s.Remove(0,1),slate + s[0], sets);
        }

    }    
        
        public static List<int> segregate_evens_and_odds(List<int> numbers) 
        {
            if (numbers == null)
            {
                return numbers;
            }
            int left = 0;
            int right = numbers.Count - 1;
            while (left < right)
            {
                while (numbers[left]%2 == 0 && left < right)
                {
                    left++;
                }
                while (numbers[right]%2 != 0 && left < right)
                {
                    right--;
                }
                
                if (left < right)
                {
                    int temp = numbers[left];
                    numbers[left] = numbers[right];
                    numbers[right] = temp;
                    left++;
                    right--;
                }
            }
            return numbers;
        }

    }
}