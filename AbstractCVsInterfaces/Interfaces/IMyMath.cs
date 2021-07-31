using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractCVsInterfaces.Interfaces
{
    public interface IMyMath
    {
        long Add(long i, long j);
        long Divide(long i, long j);
        long Multiply(long i, long j);
        long Subtract(long i, long j);
    }

}
