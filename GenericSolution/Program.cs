using System;
using System.Diagnostics;

namespace GenericSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            /*
             *         Dim someDecimal As Decimal = 100.1D
        Dim stringNum As String = Nothing

        someDecimal += Convert.ToDecimal(stringNum)
             */

            Decimal someDecimal = 100.00M;
            string stringNum = null;

            someDecimal += Convert.ToDecimal(stringNum);


            sw.Stop();

            Console.WriteLine("Number of millisecs to run: " + sw.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
