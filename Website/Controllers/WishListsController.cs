using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website.Models;
 

//Need to test code
namespace Website.Controllers
{
    public class WishListsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        /*// GET: WishLists
        public ActionResult Index()
        {
            return View(db.WishList.ToList());
        }
        */
        // GET: WishLists/Details
        public ActionResult Details()
        {
            string UserId = User.Identity.GetUserId(); //current User
            if (UserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var list = (from wishlist in db.WishList
                        where wishlist.User.Id == UserId
                        select wishlist).ToList();
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

         

        
        // GET: WishLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WishList wishList = db.WishList.Find(id);
            if (wishList == null)
            {
                return HttpNotFound();
            }
            return View(wishList);
        }

        // POST: WishLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WishList wishList = db.WishList.Find(id);
            db.WishList.Remove(wishList);
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
