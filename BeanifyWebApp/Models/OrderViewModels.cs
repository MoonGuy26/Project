using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeanifyWebApp.Models
{
    public class OrderViewModel:AbstractBaseModel
    {
        public string ProductName { get; set; }

        public string ClientName { get; set; }

        public int Quantity { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [DataType(DataType.Currency)]
        public float Price { get; set; }

        public bool IsNew { get; set; }

        
    }
}