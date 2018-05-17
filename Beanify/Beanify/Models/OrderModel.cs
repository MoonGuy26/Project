using System;
using System.Collections.Generic;
using System.Text;

namespace Beanify.Models
{
    public class ApplicationUser
    {
        public string Company { get; set; }

        public virtual ICollection<OrderModel> OrderModels { get; set; }
    }
    
    public class OrderModel:AbstractBaseModel
    {
        //public string ImagePath { get; set; }

        public string ProductName { get; set; }
        public string ClientName { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
        public bool IsNew { get; set; }

        public int ProductModelId { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ProductModel ProductModel { get; set; }



        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
