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
        [Display(Name = "Partner ID")]
        public int PartnerID { get; set; }
        [Required]
        [Display(Name = "Partner Name")]
        public string PartnerName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,11}", ErrorMessage = "Your Password must be strong.")]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string EmailID { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression("([1-9][0-9]{5})", ErrorMessage = "Pincode must be 6 digits.")]
        [DataType(DataType.PostalCode)]
        public int Pincode { get; set; }
        [Required]
        public bool IsActive { get; set; }       
        
    }
}