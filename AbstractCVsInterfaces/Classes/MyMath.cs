using AbstractCVsInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractCVsInterfaces.Classes
{

    public class MyMath : IMyMath
    {
        public long Add(long i, long j)
        {
            return i + j;
        }

        public long Subtract(long i, long j)
        {
            return i - j;
        }

        public long Multiply(long i, long j)
        {
            return i * j;
        }

        public long Divide(long i, long j)
        {
            return i / j;
        }
    }
}
