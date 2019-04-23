using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BodyLog.Models;

namespace BodyLog.Controllers
{
    public class Dishes_ProductsController : Controller
    {
        private MainDB db = new MainDB();

        // GET: Dishes_Products
        public ActionResult Index()
        {
            return View(db.Dishes_Products.ToList());
        }

        // GET: Dishes_Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dishes_Products dishes_Products = db.Dishes_Products.Find(id);
            if (dishes_Products == null)
            {
                return HttpNotFound();
            }
            return View(dishes_Products);
        }

        // GET: Dishes_Products/Create
        public ActionResult Create()
        {
            ProductModel product = new ProductModel(); 
            product.Products = db.Products.ToList();
          
           
            return View(product);
        }

       
        [HttpPost]
        public ActionResult Create(ProductModel list, Dishes dishes)
        {
            var selectedProducts = list.Products.Where(x => x.isChecked == true).ToList<Product>();



            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create2([Bind(Include = "Id_Dishes,Id_Product,gram")] Dishes_Products dishes_Products)
        {
            if (ModelState.IsValid)
            {
                db.Dishes_Products.Add(dishes_Products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dishes_Products);
        }

        // GET: Dishes_Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dishes_Products dishes_Products = db.Dishes_Products.Find(id);
            if (dishes_Products == null)
            {
                return HttpNotFound();
            }
            return View(dishes_Products);
        }

        // POST: Dishes_Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Dishes,Id_Product,gram")] Dishes_Products dishes_Products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dishes_Products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dishes_Products);
        }

        // GET: Dishes_Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dishes_Products dishes_Products = db.Dishes_Products.Find(id);
            if (dishes_Products == null)
            {
                return HttpNotFound();
            }
            return View(dishes_Products);
        }

        // POST: Dishes_Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dishes_Products dishes_Products = db.Dishes_Products.Find(id);
            db.Dishes_Products.Remove(dishes_Products);
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
