using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            string testString = "abcdefghijklmnopqrstuvwxyz";
            //This gets a count of characters in testString and returns it as an integer.
            Console.WriteLine("Number of Letters in testString is: " + testString.Count());
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.WriteLine("Hello World!");
        }
    }
}
