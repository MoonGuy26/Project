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

        /*public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/App_Data/Images"), pic);
                // file is uploaded
                file.SaveAs(path);

            }
            // after successfully uploading redirect the user
            return RedirectToAction("Edit", "MvdProductModels");
        }*/
    }
}
