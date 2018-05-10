using System;
using System.Collections.Generic;
using System.Text;

namespace Beanify.Models
{
    public class OrderModel:AbstractBaseModel
    {
        //public string ImagePath { get; set; }

        public string ProductName { get; set; }
        public string ClientName { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
        public bool IsNew { get; set; }
    }
}
