using System;

namespace PracticeC_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello Manoj!");
            int[] array = {4, 3, 1, 4, 6, 7, 5, 4, 32, 5, 26, 187, 8};
            QuickSort.Sort(array);
            foreach(int i in array)
            {
                Console.Write(i + " ");
            }

        }
    }
}
