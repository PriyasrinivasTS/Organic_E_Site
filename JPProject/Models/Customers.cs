using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JPProject.Models
{
    public class Customers
    {
        [Required]       
        public int CustomerID { get; set; }
        [Required]
        public string CustomerName { get; set; }        
        [Required]
        [EmailAddress]
        public string EmailID { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]        
        [DataType(DataType.PostalCode)]
        public int Pincode { get; set; }
        
    }
}