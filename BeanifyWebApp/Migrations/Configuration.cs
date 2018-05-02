namespace BeanifyWebApp.Migrations
{
    using BeanifyWebApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BeanifyWebApp.Models.ProductContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BeanifyWebApp.Models.ProductContext context)
        {

            context.ProductModels.AddOrUpdate(
              p => p.Id,
              new ProductModel { Name = "Coffee1",Description="Good coffee",Price=5,ImagePath="coffee1.png" },
              new ProductModel { Name = "Coffee2", Description = "Good coffee 2", Price = 7, ImagePath = "coffee2.png" }

               );
            
        }
    }
}
