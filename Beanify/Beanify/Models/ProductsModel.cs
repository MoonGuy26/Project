using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Beanify.Models
{
    // THIS IS NOT A DUPLICATE : ITS PRODUCTS CATEGORIES
    // IT WILL BE RENAME BY THE END OF THE WEEK

    public class ProductsModel: AbstractBaseModel
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public ObservableCollection<ProductModel> Products
        {
            get; set;
        }
    }
}
