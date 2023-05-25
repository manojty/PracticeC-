using System;
using System.Collections.Generic;
using System.Collections;


namespace PracticeC_
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<int,int> dict = new Dictionary<int,int>();
            dict[2] = 1;
            dict[3] = 1;
            dict[7] = 1;
            Console.WriteLine("Total no of games: " + Mixed.CountNoOfGames(12, 2,3,7,dict));
            
            Console.WriteLine();
        }

    }
}
