using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeanifyWebApp.Models
{
    public class OrderViewModel
    {
        public string ProductName { get; set; }
        public string ClientName { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
        public bool IsNew { get; set; }
    }
}