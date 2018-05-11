using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeanifyWebApp.Models;

namespace BeanifyWebApp.Controllers
{
    [Authorize(Roles ="Admin")]
    public class MvcOrderModelsController : Controller
    {
        private OrderContext db = new OrderContext();
        private ProductContext dbProduct = new ProductContext();
        private ApplicationDbContext dbUsers = new ApplicationDbContext();

        // GET: MvcOrderModels
        public ActionResult Index()
        {
            var orderViewModels = new List<OrderViewModel>();
            foreach (var orderModel in db.OrderModels.OrderByDescending(o => o.Date).ToList())
            {
                orderViewModels.Add(new OrderViewModel
                {
                    Id = orderModel.Id,
                    ClientName = "test",
                    //dbUsers.Users.Where(u => u.Id == orderModel.UserId).First().UserName,
                    ProductName = "test",
                     //dbProduct.ProductModels.Where(p => p.Id == orderModel.Id).First().Name,
                    Date = orderModel.Date,
                    Price = orderModel.Price,
                    Quantity = orderModel.Quantity,
                    IsNew = orderModel.IsNew
                });
            }

            return View(orderViewModels);
        }

        // GET: MvcOrderModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModel orderModel = db.OrderModels.Find(id);
            if (orderModel == null)
            {
                return HttpNotFound();
            }
            db.OrderModels.Find(id).IsNew = false;
            db.SaveChanges();
            return View(orderModel);
        }

        // GET: MvcOrderModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MvcOrderModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,UserId,Date,Quantity,Price,IsNew")] OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                db.OrderModels.Add(orderModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderModel);
        }

        // GET: MvcOrderModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModel orderModel = db.OrderModels.Find(id);
            if (orderModel == null)
            {
                return HttpNotFound();
            }
            return View(orderModel);
        }

        // POST: MvcOrderModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,UserId,Date,Quantity,Price,IsNew")] OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderModel);
        }

        // GET: MvcOrderModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModel orderModel = db.OrderModels.Find(id);
            if (orderModel == null)
            {
                return HttpNotFound();
            }
            return View(orderModel);
        }

        // POST: MvcOrderModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderModel orderModel = db.OrderModels.Find(id);
            db.OrderModels.Remove(orderModel);
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
