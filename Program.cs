using System;
using System.Collections.Generic;
using System.Collections;


namespace PracticeC_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> result = Mixed.generate_all_expressions("1234567890", 100);
            foreach(string str in result)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();

        }

    }
}
