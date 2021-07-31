using AbstractCVsInterfaces.Classes;
using AbstractCVsInterfaces.Interfaces;
using AbstractCVsInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractCVsInterfaces
{
    class Program
    {
        public static Initializer initialize = new Initializer();
        public static IMyMath myMathLogic { get; set; }

        public static MainModel MyModel { get; set; }

        static void Main()
        {
            bool retry = true;

            while (retry)
            {
                try
                {


                    initialize = new Initializer();
                    MyModel = initialize.Initialize();
                    Console.Clear();
                    Console.WriteLine("Input number one...");
                    MyModel.Number1 = long.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Input number two...");
                    MyModel.Number2 = long.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("And the Operation desired?");
                    Console.WriteLine("(A=Add|S=Subtract|M=Multiply|D=Divide)");
                    var op = Console.ReadLine();
                    NewMethod(MyModel, op);
                    Console.WriteLine();
                    Console.WriteLine("Would you like to try another number (Y,N)?");
                    retry = Console.ReadLine().ToUpper() == "Y";
                }
                catch (Exception)
                {
                    Console.WriteLine("There was an issue, try again");
                }
            }


        }

        static void NewMethod(MainModel model, string op)
        {
            myMathLogic = new MyMath();
            string methUsed = null;

            switch (op.ToUpper())
            {
                case "A": //Addition
                    model.Result = myMathLogic.Add(model.Number1, model.Number2);
                    methUsed = "Addition";
                    break;
                case "S": //Subtract
                    model.Result = myMathLogic.Subtract(model.Number1, model.Number2);
                    methUsed = "Subtraction";
                    break;
                case "M": //Multiply
                    model.Result = myMathLogic.Multiply(model.Number1, model.Number2);
                    methUsed = "Multiplication";
                    break;
                case "D": //Divide
                    model.Result = myMathLogic.Divide(model.Number1, model.Number2);
                    methUsed = "Division";
                    break;
                default:
                    Console.WriteLine($"No valid operation chosen...");
                    break;
            }

            Console.WriteLine($"Operation used: {methUsed}, Result is {model.Result}");
        }
    }
}
