using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

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

            if (models.Status == "success")
            {
                outputStr = @"EmployeeID,EmployeeName,EmployeeSalary,EmployeeAge,ProfileImage";
                outputStr += Environment.NewLine;
                foreach (var model in models.Data)
                {
                    outputStr += string.Format(@"{0},{1},{2},{3},{4}",
                        model.Id, model.Employee_Name, model.Employee_Salary, model.Employee_Age,
                        model.Profile_Image).TrimEnd(',');
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
        public string Status { get; set; }
        public List<TestData> Data { get; set; }
    }

    public class TestData
    {
        public string Id { get; set; }
        public string Employee_Name { get; set; }
        public string Employee_Salary { get; set; }
        public string Employee_Age { get; set; }
        public string Profile_Image { get; set; }
    }

}
