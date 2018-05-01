namespace BeanifyWebApp.Migrations
{
    using Beanify.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BeanifyWebApp.Models.OrderContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BeanifyWebApp.Models.OrderContext context)
        {
            context.OrderModels.AddOrUpdate(
                p => p.Id,
                new OrderModel { ProductName = "test",ClientName="testClient",Quantity=5,Price=6,IsNew=true }
                
            );
            
        }
    }
}
