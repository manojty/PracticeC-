
using System.Collections.Generic;
using System.Collections;

namespace PracticeC_
{

    public class Mixed
    {
        public Mixed()
        {

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