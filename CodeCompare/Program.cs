using System;

namespace CodeCompare
{
    public class Program
    {
        public static int MyProperty { get; set; }

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int myInt = 0;

            for (int x = 0; x < 10; x++)
            {
                myInt++;
            }

            Console.WriteLine("Value of myInt is:" + myInt);

            var outString = string.Format("Date is {0}", DateTime.Now.ToString("D"));

            Console.WriteLine(outString);

            MyProperty = 5; //setter
            var getIt = MyProperty; //getter


            string myString = "";
            float myFloat = 0.0f;
            long myLong = 0;
            decimal myDecimal = 0.00M;
            



        }
    }
}
