using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;


namespace PersonAPI.Models
{
    [DataContract]
    public class PersonModel
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
