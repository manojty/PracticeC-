using System;

public class MergeSort
{
    public MergeSort()
    {

    }

    public int[] Mergesrt(int[] arr, int start, int end)
    {
        if (start == end)
        {
            int[] tempArray = new int[1]; 
            tempArray[0] = arr[start];
            return tempArray;
        }

        int mid = start + (end-start)/2;
        int[] leftArray = Mergesrt(arr, start, mid);
        int[] rightArray = Mergesrt(arr, mid+1, end);
        return mergeSortedArray(leftArray, rightArray);

    }

    int[] mergeSortedArray(int[] leftArray, int[] rightArray)
    {
        int left = 0;
        int right = 0;
        int counter = 0;
        int totalLength = leftArray.Length + rightArray.Length;
        int[] sortedArray = new int[totalLength];
        while (left<leftArray.Length && right < rightArray.Length)
        {
            if (leftArray[left] < rightArray[right])
            {
                sortedArray[counter++] = leftArray[left++];
            }
            else
            {
                sortedArray[counter++] = rightArray[right++];
            }
        }

        while(left<leftArray.Length)
        {
            sortedArray[counter++] = leftArray[left++];
        }
        while(right < rightArray.Length)
        {
            sortedArray[counter++] = rightArray[right++];
        }
        return sortedArray;

    }
    
    public void Mergesrt(int[] arr, int size)
    {
        if (size == 0) 
        {
            return;
        }
        
        int[] sortedArray = Mergesrt(arr, 0, size-1);
        int i = 0;
        foreach(int item in sortedArray)
        {
            arr[i++] =  item;
        }

    }


}

public class TestMergeSort
{
    public static void HappyPath()
    {
        int[] arr = {5,1,4,2,3};
        Console.WriteLine("Before Sort");
        Helper.PrintArray(arr, 5);
        MergeSort MergeSrt = new MergeSort();
        MergeSrt.Mergesrt(arr, 5);
        Console.WriteLine("After Sort");
        Helper.PrintArray(arr, 5);
    }

    public static void Unsorted()
    {
        int[] arr = {5,4,3,2,1};
        Console.WriteLine("Before Sort");
        Helper.PrintArray(arr, 5);
        MergeSort MergeSrt = new MergeSort();
        MergeSrt.Mergesrt(arr, 5);
        Console.WriteLine("After Sort");
        Helper.PrintArray(arr, 5);
    }

        public static void Duplicate()
    {
        int[] arr = {4,4,2,2,5};
        Console.WriteLine("Before Sort");
        Helper.PrintArray(arr, 5);
        MergeSort MergeSrt = new MergeSort();
        MergeSrt.Mergesrt(arr, 5);
        Console.WriteLine("After Sort");
        Helper.PrintArray(arr, 5);
    }

    public static void Empty()
    {
        int[] arr = {};
        Console.WriteLine("Before Sort");
        Helper.PrintArray(arr, 0);
        MergeSort MergeSrt = new MergeSort();
        MergeSrt.Mergesrt(arr, 0);
        Console.WriteLine("After Sort");
        Helper.PrintArray(arr, 0);
    }

    public static void One()
    {
        int[] arr = {1};
        Console.WriteLine("Before Sort");
        Helper.PrintArray(arr, 1);
        MergeSort MergeSrt = new MergeSort();
        MergeSrt.Mergesrt(arr, 1);
        Console.WriteLine("After Sort");
        Helper.PrintArray(arr, 1);
    }

    public static void Two()
    {
        int[] arr = {2,1};
        Console.WriteLine("Before Sort");
        Helper.PrintArray(arr, 2);
        MergeSort MergeSrt = new MergeSort();
        MergeSrt.Mergesrt(arr, 2);
        Console.WriteLine("After Sort");
        Helper.PrintArray(arr, 2);
    }
    public static void Even()
    {
        int[] arr = {6,2,5,3,2,1};
        Console.WriteLine("Before Sort");
        Helper.PrintArray(arr, 6);
        MergeSort MergeSrt = new MergeSort();
        MergeSrt.Mergesrt(arr, 6);
        Console.WriteLine("After Sort");
        Helper.PrintArray(arr, 6);
    }
    public static void runAllTests()
    {
        HappyPath();
        Unsorted();
        Duplicate();
        Empty();
        One();
        Two();
        Even();
    }

}