using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
            identityMessage.Body = "You've just ordered " + orderModel.Quantity.ToString() + " " + orderModel.ProductName + ".\n\nYou've paid " + orderModel.Price + "£ for it. Order has been passed on the " + orderModel.Date.ToShortDateString() + " at " + orderModel.Date.ToShortTimeString() +". \nThanks for buying our delicious coffees.";
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