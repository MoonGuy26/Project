using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Beanify.Models;
using BeanifyWebApp.Models;

namespace BeanifyWebApp.Controllers
{
    [Authorize]
    public class OrderModelsController : ApiController
    {
        
        private OrderContext db = new OrderContext();

        // GET: api/OrderModels
        [AllowAnonymous]
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
        public IHttpActionResult PostOrderModel(OrderModel orderModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderModels.Add(orderModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = orderModel.Id }, orderModel);
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