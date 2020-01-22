using System;
using System.Collections.Generic;

namespace Lesson3
{
    /// <summary>
    /// Lesson 3 - More Algo Training
    /// 
    /// Today, we're going to study simple conditionals and some loops
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //1.  Setup some data in an explicit types
            string[] EmpireStrArr = new string[] { "Lucious", "Cookie", "Hakeem", "Jamal", "Andre" };
            Dictionary<string,bool> EmpireStillOnShow = new Dictionary<string, bool>();

            //2.1.  Create a boolean value that we can use as a 'flag'
            bool IsStillOnShow = true;

            //2.2.  Learn how to iterate through the test data using different loops and if conditionals
            for (int i = 0; i < EmpireStrArr.Length; i++)
            {
                if (EmpireStrArr[i] == "Lucious")
                    IsStillOnShow = false;

                if (EmpireStrArr[i] != "Lucious")
                    IsStillOnShow = true;

                EmpireStillOnShow.Add(EmpireStrArr[i], IsStillOnShow);
            }
            
            //3.  Output the data to the screen if the IsStillOnShow 'flag' is true!
            foreach(var person in EmpireStillOnShow)
            {
                if (!person.Value)
                    Console.WriteLine(person.Key + " is no longer on the show!");

                if (person.Value)
                    Console.WriteLine(person.Key + " is still on the show!");
            }

            Console.WriteLine("Any Questions?!?");
            Console.Read();
        }
    }
}
