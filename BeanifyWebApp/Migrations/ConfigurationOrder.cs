using BeanifyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace BeanifyWebApp.Migrations
{
    public class ConfigurationOrder: DbMigrationsConfiguration<BeanifyWebApp.Models.OrderContext>
    {
        public ConfigurationOrder()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BeanifyWebApp.Models.OrderContext context)
        {

            context.OrderModels.AddOrUpdate(
              p => p.Id,
              new OrderModel { ProductId = 1, UserId = "156156155151156151561", Date = DateTime.Now, IsNew = true, Price = 156, Quantity = 5 },
              new OrderModel { ProductId = 1, UserId = "156156155151156151561", Date = DateTime.Now, IsNew = true, Price = 18, Quantity = 4 }


               );

        }
    }
}