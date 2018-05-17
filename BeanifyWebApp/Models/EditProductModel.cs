using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeanifyWebApp.Models
{
    public class EditProductModel:AbstractBaseModel
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
        public bool IsAvailable { get; set; }
    }
}