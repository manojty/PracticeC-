using System;


class QuickSort
{
    
    int partition(int[] arr, int start, int end)
    {

        int mid = start + (end - start)/2;
        int pivot = arr[mid];
        while (start < end)
        {
            while(arr[start] < pivot)
            {
                start++;
            }
            while(arr[end] > pivot)
            {
                end--;
            }
            if(start < end)
            {
                int temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;end--;
            }
        }
        return start;
    }
    private void QSort(int[] arr, int start, int end)
    {
        if (start < end)
        {
            int partitionIndex = partition(arr, start, end);
            QSort(arr, start, partitionIndex - 1);
            QSort(arr, partitionIndex + 1, end);
        }
    }
    public QuickSort()
    {

    } 
    
    public void Sort(int[] arr, int size)
    {
        QSort(arr, 0, size - 1);
    }

}

class QSortTest
{
    public static void TestOddNumArray()
    {
        int[] arr = {3,5,2,4,1};
        Console.WriteLine("Before Quick Sort");
        Helper.PrintArray(arr, 5);
        QuickSort qs = new QuickSort();
        qs.Sort(arr, 5);
        Console.WriteLine("After Quick Sort");
        Helper.PrintArray(arr, 5);
    }

    public static void TestEvenNumArray()
    {
        int[] arr = {3,5,2,4,1,6};
        Console.WriteLine("Before Quick Sort");
        Helper.PrintArray(arr, 6);
        QuickSort qs = new QuickSort();
        qs.Sort(arr, 6);
        Console.WriteLine("After Quick Sort");
        Helper.PrintArray(arr, 6);
    }

    public static void TestUnsortedArray()
    {
        int[] arr = {10,9,8,7,6,5};
        Console.WriteLine("Before Quick Sort");
        Helper.PrintArray(arr, 6);
        QuickSort qs = new QuickSort();
        qs.Sort(arr, 6);
        Console.WriteLine("After Quick Sort");
        Helper.PrintArray(arr, 6);
    }
    public static void TestSortedArray()
    {
        int[] arr = {1,2,3,4,5,6};
        Console.WriteLine("Before Quick Sort");
        Helper.PrintArray(arr, 6);
        QuickSort qs = new QuickSort();
        qs.Sort(arr, 6);
        Console.WriteLine("After Quick Sort");
        Helper.PrintArray(arr, 6);
    }
 public static void TestSameArray()
    {
        int[] arr = {1,1,1,1,1,1};
        Console.WriteLine("Before Quick Sort");
        Helper.PrintArray(arr, 6);
        QuickSort qs = new QuickSort();
        qs.Sort(arr, 6);
        Console.WriteLine("After Quick Sort");
        Helper.PrintArray(arr, 6);
    }
    public static void TestDuplicateArray()
    {
        int[] arr = {10,9,9,5,10,5};
        Console.WriteLine("Before Quick Sort");
        Helper.PrintArray(arr, 6);
        QuickSort qs = new QuickSort();
        qs.Sort(arr, 6);
        Console.WriteLine("After Quick Sort");
        Helper.PrintArray(arr, 6);
    }
    public static void TestEdgeCaseArray()
    {
        int[] arr = {10};
        Console.WriteLine("Before Quick Sort");
        Helper.PrintArray(arr, 1);
        QuickSort qs = new QuickSort();
        qs.Sort(arr, 1);
        Console.WriteLine("After Quick Sort");
        Helper.PrintArray(arr, 1);
    }
}