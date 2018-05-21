using System;
using System.Collections.Generic;
using System.Text;

namespace Beanify.Models
{
    public class OrderModel:AbstractBaseModel
    {
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
        public bool IsNew { get; set; }

        public int ProductModelId { get; set; }

        public string ApplicationUserId { get; set; }

        

    }
}
