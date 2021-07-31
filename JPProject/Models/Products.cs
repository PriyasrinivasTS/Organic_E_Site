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
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Quantity { get; set; }
        [Required]
        public bool isAvailable { get; set; }       
    }
}