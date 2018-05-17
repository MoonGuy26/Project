using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using BeanifyWebApp.Models;

namespace BeanifyWebApp.Controllers
{
    //set authorize Admin when possible
    [Authorize(Roles = "Admin")]
    public class MvcProductModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MvcProductModels
        public ActionResult Index()
        {
            return View(db.ProductModels.ToList());
        }

        // GET: MvcProductModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModel productModel = db.ProductModels.Find(id);
            if (productModel == null)
            {
                return HttpNotFound();
            }
            return View(productModel);
        }

        // GET: MvcProductModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MvcProductModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,IsAvailable")]ProductModel productModel, 
            HttpPostedFileBase file)
        {
            if (productModel.Description != null)
            {
                ViewBag.EnteredDescription = productModel.Description;
            }

            if (file == null)
            {
                ViewBag.NoImageError = "An image is required!";
                return View(productModel);
            }

            productModel.ImagePath = "notdefined.png";

            if (!ModelState.IsValidField("Name")|| !ModelState.IsValidField("Price")|| !ModelState.IsValidField("IsAvailable"))
            {
                return View(productModel);
            }

            db.ProductModels.Add(productModel);
            db.SaveChanges();

            var id = productModel.Id;

            string pic = "product" + id  + Path.GetExtension(file.FileName);
            string path = System.IO.Path.Combine(
                                   Server.MapPath("~/Images/ProductModels"), pic);
            // file is uploaded
            file.SaveAs(path);


            productModel.ImagePath= System.IO.Path.Combine("~/Images/ProductModels", pic);

            db.Entry(productModel).State = EntityState.Modified;
            db.SaveChanges();
            ViewBag.NoImageError = null;
            ViewBag.EnteredDescription = null;
            return RedirectToAction("Index");

          
                
            
            //return View(productModel);
        }

        // GET: MvcProductModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModel productModel = db.ProductModels.Find(id);
            if (productModel == null)
            {
                return HttpNotFound();
            }

            EditProductModel editedProduct = new EditProductModel
            {
                Id = productModel.Id,
                Name=productModel.Name,
                Description=productModel.Description,
               
                IsAvailable=productModel.IsAvailable,
                Price=productModel.Price
            };

            ViewBag.CurrentImage = productModel.ImagePath;
            return View(editedProduct);
        }

        // POST: MvcProductModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,IsAvailable")]EditProductModel productModel,
            HttpPostedFileBase file)
        {
            ViewBag.CurrentImage = db.ProductModels.Find(productModel.Id).ImagePath;

            if (!ModelState.IsValidField("Name") || !ModelState.IsValidField("Price"))
            {
                return View(productModel);
            }
            

            ProductModel editedProduct = db.ProductModels.Find(productModel.Id);

            if (file != null)
            {
                string pic = "product" + productModel.Id+Path.GetExtension(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Images/ProductModels"), pic);
                // file is uploaded
                
                var previousFile = Server.MapPath(editedProduct.ImagePath);
                if (System.IO.File.Exists(previousFile))
                {
                    System.IO.File.Delete(previousFile);
                }

                file.SaveAs(path);

                editedProduct.ImagePath = System.IO.Path.Combine("~/Images/ProductModels", pic);
            }


            editedProduct.Name = productModel.Name;
            editedProduct.Description = productModel.Description;
            editedProduct.IsAvailable = productModel.IsAvailable;
            editedProduct.Price = productModel.Price;
            

            db.Entry(editedProduct).State = EntityState.Modified;
            db.SaveChanges();

            ViewBag.IsAvailable=null;

            return RedirectToAction("Index");
            
            //
        }


        // POST: MvcProductModels/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductModel productModel = db.ProductModels.Find(id);

            var x = (from o in db.OrderModels
                     where o.ProductModelId == id
                     select o);
            db.OrderModels.RemoveRange(x);

            var previousFile = Server.MapPath(db.ProductModels.Find(productModel.Id).ImagePath);
            
            if (System.IO.File.Exists(previousFile))
            {
                System.IO.File.Delete(previousFile);
            }

            db.ProductModels.Remove(productModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
