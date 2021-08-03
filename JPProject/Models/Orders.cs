using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JPProject.Models
{
    public class Orders
    {
        [Required]
        [Display(Name = "Order ID")]
        public int OrderID { get; set; }
        [Required]
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [DefaultValue(1)]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Delivery Address")]
        public string DeliveryAddress { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        [RegularExpression("([1-9][0-9]{5})", ErrorMessage = "Pincode must be 6 digits.")]
        public string Pincode { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime OrderdOn { get; set; }
    }
}