
using System.Collections.Generic;
using System.Collections;

namespace PracticeC_
{

    public class Mixed
    {
        public Mixed()
        {

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