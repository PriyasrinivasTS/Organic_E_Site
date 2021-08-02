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
        public int OrderID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [DefaultValue(1)]
        public int Quantity { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]       
        public string Pincode { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime OrderdOn { get; set; }
    }
}