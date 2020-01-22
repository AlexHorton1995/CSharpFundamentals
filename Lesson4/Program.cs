using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4
{
    /// <summary>
    /// Lesson 4 - Consuming a web API.  
    /// 
    /// In this lesson, we are going to 'consume' a web api by utlilizing what we've learned thus far.
    /// 
    /// By the end of this lesson, we should know:
    ///     1.  What an API is 
    ///     2.  What an API is used for
    ///     3.  Why we use APIs
    ///     4.  How to understand the logic behind the api
    ///     5.  Utilize the NuGet Package Manager to get RestSharp
    ///     6.  Understand what Libraries are for
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //1.  Download the NuGet Package for Newtonsoft.Json
            //2.  Download the NuGet Package for RestSharp
            //3.  do the coding

            var models = JsonConvert.DeserializeObject<TestClass>(SendAPI("http://dummy.restapiexample.com/api/v1/employees"));
            string outputStr = string.Empty;

            if (models.status == "success")
            {
                outputStr = @"EmployeeID,EmployeeName,EmployeeSalary,EmployeeAge,ProfileImage";
                outputStr += Environment.NewLine;
                foreach (var model in models.data)
                {
                    outputStr += string.Format(@"{0},{1},{2},{3},{4}",
                        model.id, model.employee_name, model.employee_salary, model.employee_age,
                        model.profile_image).TrimEnd(',');
                    outputStr += Environment.NewLine;
                }
            }

            Console.WriteLine(outputStr);


        }

        static string SendAPI(string url)
        {
            var client = new RestClient(url);
            var response = client.Execute(new RestRequest());
            return response.Content;
        }
    }

    public class TestClass
    {
        public string status { get; set; }
        public List<TestData> data { get; set; }
    }

    public class TestData
    {
        public string id { get; set; }
        public string employee_name { get; set; }
        public string employee_salary { get; set; }
        public string employee_age { get; set; }
        public string profile_image { get; set; }
    }

}
