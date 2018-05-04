using System;
using System.Collections.Generic;
using System.Text;

namespace Beanify.Models
{
    public class ProductModel : AbstractBaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string ImagePath { get; set; }
        //public bool IsSelected { get; set; } = false;
    }
}
