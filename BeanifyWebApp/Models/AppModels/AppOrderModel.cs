using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeanifyWebApp.Models.AppModels
{
    public class AppOrderModel : AbstractBaseModel
    {

        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
        public bool IsNew { get; set; }
        public string ProductName { get; set; }
        

    }
}