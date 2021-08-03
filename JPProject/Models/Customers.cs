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
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }
        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }        
        [Required]
        [EmailAddress]
        [Display(Name = "Email ID")]
        public string EmailID { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,11}", ErrorMessage = "Your Password must be strong.")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNo { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]  
        [RegularExpression("([1-9][0-9]{5})", ErrorMessage = "Pincode must be 6 digits.")]
        [DataType(DataType.PostalCode)]
        public string Pincode { get; set; }
        
    }
}