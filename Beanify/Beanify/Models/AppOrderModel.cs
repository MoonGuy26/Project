﻿using System;

namespace Beanify.Models
{


    public class AppOrderModel:AbstractBaseModel
    {
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
        public bool IsNew { get; set; }
        public string ProductName { get; set; }

    }
}
