using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.Linq;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BodyLog.Models;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using System.Web.Security;
using System.Web.UI;
using Microsoft.Ajax.Utilities;

namespace BodyLog.Controllers
{
    public class ProductsController : Controller
    {
        private DefaultConnection db = new DefaultConnection();
        private object _id = System.Web.HttpContext.Current.User.Identity.GetUserId();
        public string nameToEdit;


        public ActionResult Index(string searchString)
        {
            var products = from p in db.Products
                select p;

            if (!String.IsNullOrEmpty(searchString))        
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }

            return View(products);
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null || !UserIdentity(product))
            {
                return HttpNotFound();
            }
            return View(product);
        }

        
        public ActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Calories,Proteins,Carbohydrates,Fats,UserId")] Product product)
        {
            if (ModelState.IsValid)
            {
                //ModelState.Remove("UserId");
                product.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null || !UserIdentity(product))
            {
                return HttpNotFound();
            }

            nameToEdit = product.Name; /////////////////////
            return View(product);
        }

     
        [HttpPost]
        
        public ActionResult Edit([Bind(Include = "Id,Name,Calories,Proteins,Carbohydrates,Fats,UserId")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

/*
            return View(product);
*/
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null || !UserIdentity(product))
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Info()
        {
            return View();
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            List<Dishes_Products> dishList = new List<Dishes_Products>();

            foreach (var dish in db.Dishes_Products)
            {
                if (dish.Id_Product == product.Id) return RedirectToAction("Info", "Products");
            }

            db.Products.Remove(product);
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

//        public JsonResult IsNameExists(string Name)
//        {
//            var products = from p in db.Products
//                select p;
//
//            if (!String.IsNullOrEmpty(Name))
//            {
//                products = products.Where(s => s.Name.Contains(Name));
//            }
//
//            return Json(!db.Products.Any(x => x.Name == Name), JsonRequestBehavior.AllowGet);
//        }
        public bool UserIdentity(Product product)
        {
            if (product.UserId == System.Web.HttpContext.Current.User.Identity.GetUserId())
                return true;
            return false;

        }
    }
}
