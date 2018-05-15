using BeanifyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeanifyWebApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            if (User.IsInRole("Admin"))
         
            {
                int newOrders = db.OrderModels.Where(o => o.IsNew).Count();
                ViewBag.NewOrders = newOrders;
            }

            return View();
        }
    }
}
