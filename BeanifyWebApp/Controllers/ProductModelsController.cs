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
using BeanifyWebApp.Models;

namespace BeanifyWebApp.Controllers
{
    public class ProductModelsController : ApiController
    {
        private ProductContext db = new ProductContext();

        // GET: api/ProductModels
        [AllowAnonymous]
        [ResponseType(typeof(ProductModel))]
        public IQueryable<ProductModel> GetProductModels()
        {
            ProductContext db1 = new ProductContext();
            return db1.ProductModels;
        }

        // GET: api/ProductModels/5
        [ResponseType(typeof(ProductModel))]
        public IHttpActionResult GetProductModel(int id)
        {
            ProductModel productModel = db.ProductModels.Find(id);
            if (productModel == null)
            {
                return NotFound();
            }

            return Ok(productModel);
        }

        // PUT: api/ProductModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductModel(int id, ProductModel productModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productModel.Id)
            {
                return BadRequest();
            }

            db.Entry(productModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductModelExists(id))
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

        // POST: api/ProductModels
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(ProductModel))]
        public IHttpActionResult PostProductModel(ProductModel productModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductModels.Add(productModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productModel.Id }, productModel);
        }

        // DELETE: api/ProductModels/5
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(ProductModel))]
        public IHttpActionResult DeleteProductModel(int id)
        {
            ProductModel productModel = db.ProductModels.Find(id);
            if (productModel == null)
            {
                return NotFound();
            }

            db.ProductModels.Remove(productModel);
            db.SaveChanges();

            return Ok(productModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductModelExists(int id)
        {
            return db.ProductModels.Count(e => e.Id == id) > 0;
        }
    }
}