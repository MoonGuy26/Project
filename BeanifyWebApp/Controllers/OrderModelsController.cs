﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Description;
using BeanifyWebApp.Models;
using Microsoft.AspNet.Identity;

namespace BeanifyWebApp.Controllers
{
    [Authorize]
    public class OrderModelsController : ApiController
    {
        private OrderContext db = new OrderContext();
        private ProductContext dbProduct = new ProductContext();

        // GET: api/OrderModels
        public IQueryable<OrderModel> GetOrderModels()
        {
            return db.OrderModels;
        }

        // GET: api/OrderModels/5
        [ResponseType(typeof(OrderModel))]
        public IHttpActionResult GetOrderModel(int id)
        {
            OrderModel orderModel = db.OrderModels.Find(id);
            if (orderModel == null)
            {
                return NotFound();
            }

            return Ok(orderModel);
        }

        // PUT: api/OrderModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderModel(int id, OrderModel orderModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderModel.Id)
            {
                return BadRequest();
            }

            db.Entry(orderModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OrderModels
        [ResponseType(typeof(OrderModel))]
        public IHttpActionResult PostOrderModel(OrderViewModel orderModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.Identity.GetUserId();
            var productId = dbProduct.ProductModels.Where(p => p.Name == orderModel.ProductName).First().Id;
            var model = new OrderModel { ProductId = productId, UserId = userId, Date = orderModel.Date, IsNew = true, Price = orderModel.Price, Quantity = orderModel.Quantity };



            EmailService email = new EmailService();
            IdentityMessage identityMessage = new IdentityMessage();
            identityMessage.Destination = User.Identity.GetUserName();
            identityMessage.Subject = "Order Confirmation";

            //Fetching Email Body Text from EmailTemplate File.  
            //string FilePath = Path.GetFullPath("OrderConfirmation.html");
            string FilePath = "C:\\inetpub\\wwwroot\\BeanifyWebApp\\EmailTemplates\\OrderConfirmation.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd().ToString();
            str.Close();

            //{0} : Subject  
            //{1} : DateTime  
            //{2} : Email  
            //{3} : Item  
            //{4} : Quantity  
            //{5} : Price  

            MailText = MailText.Replace("{0}", identityMessage.Subject);
            MailText = MailText.Replace("{1}", String.Format("{0:dddd, d MMMM yyyy}", DateTime.Now));
            MailText = MailText.Replace("{2}", User.Identity.GetUserName());
            MailText = MailText.Replace("{3}", orderModel.ProductName);
            MailText = MailText.Replace("{4}", orderModel.Quantity.ToString() + " items");
            MailText = MailText.Replace("{5}", orderModel.Price.ToString());

            identityMessage.Body = MailText;
            //identityMessage.Body = "You've just ordered " + orderModel.Quantity.ToString() + " " + orderModel.ProductName + ".\n\nYou've paid " + orderModel.Price + "£ for it. Order has been passed on the " + orderModel.Date.ToShortDateString() + " at " + orderModel.Date.ToShortTimeString() +". \nThanks for buying our delicious coffees.";

            email.Send(identityMessage);



            db.OrderModels.Add(model);
            db.SaveChanges();
            
            return CreatedAtRoute("DefaultApi", new { id = model.Id }, orderModel);
        }


        // DELETE: api/OrderModels/5
        [ResponseType(typeof(OrderModel))]
        public IHttpActionResult DeleteOrderModel(int id)
        {
            OrderModel orderModel = db.OrderModels.Find(id);
            if (orderModel == null)
            {
                return NotFound();
            }

            db.OrderModels.Remove(orderModel);
            db.SaveChanges();

            return Ok(orderModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderModelExists(int id)
        {
            return db.OrderModels.Count(e => e.Id == id) > 0;
        }
    }
}