using System;
using System.Threading.Tasks;
using NewClassLib;
using System.Net.Http;
using System.IO;

namespace NewConsole
{
    public class Program 
    {

        static void Main(string[] args)
        {
            ThisModel model = new ThisModel();
            var someOtherTask = PersonModel.GetData();

        }
    }  
   
}
