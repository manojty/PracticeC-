using System;

namespace PracticeC_
{
    class QuickSort
    {
        public static void  Sort(int[] array)
        {
            if (array.Length == 0)
            {
                return;
            }
            Sort(array, 0, array.Length-1);
        }

        static void Sort(int[] array, int left, int right)
        {
            if (left >= right) return;
            int pivot = array[left];
            int pivotIndex = left;
            int end = right;
            while (left <= right)
            {
                while ((left <= right) && (pivot >= array[left]))
                {
                    ++left;
                }
                
                while ((left <= right) && (pivot <= array[right]))
                {
                    --right;
                }

                if (left < right)
                {
                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                    left++;
                    right--;
                }
            }

            int tmp = array[left-1];
            array[left-1] = array[pivotIndex];
            array[pivotIndex] = tmp;
            Sort(array, pivotIndex, left-2);
            Sort(array, left,end);
        }

    }
}