using System;

namespace Lesson2
{
    /// <summary>
    /// Lesson 2: Implicit vs Strong Types
    /// 
    /// Let's learn the differences between implicit versus strong types of variables.
    /// </summary>
    
    class Program
    {
        static void Main(string[] args)
        {
            //1.  Explicit VARIABLES
            string MyString = "This is a strongly typed variable";

            //numeric fields
            byte MyByte = 255; //0 => 255 8 bit integer
            short MyShort = -1; //16BITS -32,768 to 32,767
            long MyLong = 1234567890; //64BITS -9,223,372,036,854,775,808 TO 9,223,372,036,854,775,807
            int MyInt = 0; //32BITS -2,147,483,648 TO 2,147,483,647
            var MyVariable = MyInt;

            MyInt += 1;
            MyVariable += 1;

            decimal MyDecimal = 0.00M;
            
            //boolean
            bool MyBool = true;

            //DateTime
            DateTime MyDate = new DateTime(2029, 1, 1);


            //3.  WHEN WOULD YOU USE ONE OVER THE OTHER AND WHY?

        }
    }
}
