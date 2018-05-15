using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeanifyWebApp.Models
{
    public class OrderModel:AbstractBaseModel
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        [Required]
        public bool IsNew { get; set; }

        [Display(Name = "Product")]
        public int ProductModelId { get; set; }

        [Display(Name = "Customer")]
        public string ApplicationUserId { get; set; }

        public virtual ProductModel ProductModel { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
