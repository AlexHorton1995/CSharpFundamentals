using MainProjectApplication.Classes;
using System;

namespace MainProjectApplication
{
    class Program
    {
        public static ArithmeticClass aClass;

        static void Main(string[] args)
        {
            Console.WriteLine("Going to add two numbers together");
            Console.WriteLine();
            int a = 250;
            int b = 500;
            int c = 750;

            aClass = new ArithmeticClass();

            if (c == aClass.Add(a, b))
            {
                Console.WriteLine("They Match!");
            }
            else
            {
                Console.WriteLine("They don't match!");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
