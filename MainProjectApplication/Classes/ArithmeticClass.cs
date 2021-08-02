using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProjectApplication.Classes
{
    public class ArithmeticClass
    {
        private int iIntOne { get; set; }
        private int iIntTwo { get; set; }

        public ArithmeticClass()
        {
            this.iIntOne = 0;
            this.iIntTwo = 0;
        }

        public long Add(int iIntOne, int iIntTwo)
        {
            return iIntOne + iIntTwo;
        }

        public long Subtract(int sIntOne, int sIntTwo)
        {
            return sIntOne - sIntTwo;
        }
        public long Multiply(int mIntOne, int mIntTwo)
        {
            return mIntOne * mIntTwo;
        }
        public long Divide(int dIntOne, int dIntTwo)
        {
            return dIntOne / dIntTwo;
        }

    }
}
