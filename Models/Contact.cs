using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//model
namespace Northwind.Models
{
    public class Contact
    {
        public int ContactID { get; set; }

        [Required]
        public String Name { get; set; }

        //use the dataAnnotations
        [EmailAddress]
        public String Email { get; set; }
    }
}
