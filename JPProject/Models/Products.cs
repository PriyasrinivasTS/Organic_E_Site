using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JPProject.Models
{
    public class Products
    {
        [Required]
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }
        [Required]
        public double Price { get; set; }
       [Required]
        [Display(Name = "Partner ID")]
        public int PartnerID { get; set; }

    }
}