using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeanifyWebApp.Models
{
    public class ProductModel:AbstractBaseModel
    {
        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0.01, 100000000.00,
            ErrorMessage = "Price must be between 0.01 and 100000000.00")]
        public float Price { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImagePath { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        //public virtual ICollection<OrderModel> OrderModels { get; set; }
    }
}
