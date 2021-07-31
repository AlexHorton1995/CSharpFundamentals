using AbstractCVsInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractCVsInterfaces.Classes
{
    public class Initializer
    {
        public MainModel Initialize()
        {
            return new MainModel();
        }
    }
}
