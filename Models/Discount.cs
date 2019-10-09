using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class Discount
    {
        //added these from the ERD-Discount
        //just typed in public+type+{get;set;}
        public int DiscountID { get; set;}
        public int Code { get; set;}
        public DateTime StartTime { get; set;}
        public DateTime EndTime { get; set;}
        public decimal DiscountPercent { get; set;}
        public String Title { get; set;}
        public String Description { get; set;}
        public int ProductId {get; set;}
        public Product Product {get; set;}
    }
}
