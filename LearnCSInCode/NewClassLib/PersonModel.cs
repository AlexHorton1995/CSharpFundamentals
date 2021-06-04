using System;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;


namespace NewClassLib
{
    public class PersonModel
    {
        public static string myUrl = "https://personapi20210318000453.azurewebsites.net/v1/PersonModel/";

        public static string GetData()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("ApiKey", "B2DB5E35-58CD-48E1-8ADE-FA4B75A71F35");
                    var response = httpClient.GetStringAsync(new Uri(myUrl)).Result;
                    return response;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return null;
        }

    }

    public class ThisModel
    {
        [DataMember(Name = "ID")]
        public string ID { get; set; }

        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "midInit")]
        public string MidInit { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "dob")]
        public DateTime? DOB { get; set; }

        [DataMember(Name = "age")]
        public byte? Age => DOB.HasValue ? (byte)(DateTime.Now.Date.Year - DOB.Value.Year) : 0;

        [DataMember(Name = "address1")]
        public string Address1 { get; set; }

        [DataMember(Name = "address2")]
        public string Address2 { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "zipCode")]
        public string ZipCode { get; set; }

        [DataMember(Name = "phone1")]
        public string Phone1 { get; set; }

        [DataMember(Name = "phone2")]
        public string Phone2 { get; set; }

        [DataMember(Name = "eMail")]
        public string EMail { get; set; }

    }
}