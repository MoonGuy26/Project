using System;
using System.Collections.Generic;
using System.Text;

namespace Beanify.Models
{
    
    
    public class AppOrderModel:AbstractBaseModel
    {
        //public string ImagePath { get; set; }

        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
        public bool IsNew { get; set; }
        public string ProductName { get; set; }

    }
}
