using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beanify.Models
{
    public class OrderModel:AbstractBaseModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string ProductName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string ClientName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        [Required]
        public bool IsNew { get; set; }
    }
}
