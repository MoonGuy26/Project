using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beanify.Models
{
    public class OrderModel:AbstractBaseModel
    {
        [Required]
        public string ProductId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        [Required]
        public bool IsNew { get; set; }
    }
}
