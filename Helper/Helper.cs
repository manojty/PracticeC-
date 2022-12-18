using System;


class Helper
{
     public static void PrintArray(int[] arr, int size)
    {
        foreach (var item in arr)
        {
            Console.Write(item + ", ");
        }
        Console.WriteLine();
    }
}