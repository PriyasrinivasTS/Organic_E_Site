using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace JPProject.Models
{
    public class Members
    {       
        [Required]
        public int PartnerID { get; set; }
        [Required]
        public string PartnerName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string EmailID { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]   
        
        [DataType(DataType.PostalCode)]
        public int Pincode { get; set; }
        [Required]
        public bool IsActive { get; set; }       
        
    }
}