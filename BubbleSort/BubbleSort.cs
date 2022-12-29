using System;

public class BubbleSort
{
    public BubbleSort()
    {

    }

    public void Bubblesrt(int[] arr, int size)
    {
        for(int i=0; i<size-1; i++)
        {
            for(int j=0; j<size-1-i; j++)
            {
                if (arr[j]>arr[j+1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j+1];
                    arr[j+1] = temp;
                }
            }

        }
    }
}

public class TestBubbleSort
{
    public static void HappyPath()
    {
        int[] arr = {5,1,4,2,3};
        Console.WriteLine("Before Sort");
        Helper.PrintArray(arr, 5);
        BubbleSort BubbleSrt = new BubbleSort();
        BubbleSrt.Bubblesrt(arr, 5);
        Console.WriteLine("After Sort");
        Helper.PrintArray(arr, 5);
    }

    public static void Unsorted()
    {
        int[] arr = {5,4,3,2,1};
        Console.WriteLine("Before Sort");
        Helper.PrintArray(arr, 5);
        BubbleSort BubbleSrt = new BubbleSort();
        BubbleSrt.Bubblesrt(arr, 5);
        Console.WriteLine("After Sort");
        Helper.PrintArray(arr, 5);
    }

        public static void Duplicate()
    {
        int[] arr = {4,4,2,2,5};
        Console.WriteLine("Before Sort");
        Helper.PrintArray(arr, 5);
        BubbleSort BubbleSrt = new BubbleSort();
        BubbleSrt.Bubblesrt(arr, 5);
        Console.WriteLine("After Sort");
        Helper.PrintArray(arr, 5);
    }

    public static void Empty()
    {
        int[] arr = {};
        Console.WriteLine("Before Sort");
        Helper.PrintArray(arr, 0);
        BubbleSort BubbleSrt = new BubbleSort();
        BubbleSrt.Bubblesrt(arr, 0);
        Console.WriteLine("After Sort");
        Helper.PrintArray(arr, 0);
    }

    public static void One()
    {
        int[] arr = {1};
        Console.WriteLine("Before Sort");
        Helper.PrintArray(arr, 1);
        BubbleSort BubbleSrt = new BubbleSort();
        BubbleSrt.Bubblesrt(arr, 1);
        Console.WriteLine("After Sort");
        Helper.PrintArray(arr, 1);
    }

    public static void Two()
    {
        int[] arr = {2,1};
        Console.WriteLine("Before Sort");
        Helper.PrintArray(arr, 2);
        BubbleSort BubbleSrt = new BubbleSort();
        BubbleSrt.Bubblesrt(arr, 2);
        Console.WriteLine("After Sort");
        Helper.PrintArray(arr, 2);
    }
    public static void Even()
    {
        int[] arr = {6,2,5,3,2,1};
        Console.WriteLine("Before Sort");
        Helper.PrintArray(arr, 6);
        BubbleSort BubbleSrt = new BubbleSort();
        BubbleSrt.Bubblesrt(arr, 6);
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