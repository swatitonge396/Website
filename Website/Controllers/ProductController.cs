using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    // [Authorize]
    public class ProductController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Products
        public ActionResult Index()
        {
            var list = (from product in db.Products
                        where product.Category == 1000
                        select product).ToList();
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var list = (from product in db.Products
                        where product.Category == id
                        select product).ToList();
            if (list == null)
            {
                return HttpNotFound();
            }
            return View("Index", list);
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
