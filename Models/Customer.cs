using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Northwind.Models
{
    public class Customer
    {
        //ERD
        public int CustomerID { get; set; }

        [RequiredAttribute]
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        [PhoneAttribute]
        public string Phone { get; set; }

        [PhoneAttribute]
        public string Fax { get; set; }
    }
}
