using System;
using System.Collections.Generic;
using System.Collections;


namespace PracticeC_
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestMergeSort.runAllTests();
            List<string> sets = Mixed.generatePermutation("abcd");
            foreach(string item in sets)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(sets.Count);
        }

    }
}
