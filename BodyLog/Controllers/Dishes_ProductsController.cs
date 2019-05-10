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


        public ActionResult Index()
        {
            GlobalModel global = new GlobalModel();
   
            global.Products = db.Products.ToList();
           
            global.Dishes_Products = db.Dishes_Products.ToList();
            global.DishesList = db.Dishes.Where(dishes => db.Dishes_Products.ToList().Any(dp => dishes.Id == dp.Id_Dishes)).ToList<Dishes>();//.ToList<DishesList>(); ;

            return View(global);
        }

        public ActionResult Create()
        {
            GlobalModel global = new GlobalModel(); 
            global.Products = db.Products.ToList();
          
            return View(global);
        }


        [HttpPost]
        public ActionResult Create(GlobalModel list, Dishes dishes)
        {

            var selectedProducts = list.Products.Where(x => x.Volume > 0).ToList<Product>();


            float calories = 0, carbo = 0, proteins = 0, fats = 0;

            foreach (Product p in selectedProducts)
            {
                calories += p.Calories * p.Volume / 100;
                carbo += p.Carbohydrates * p.Volume / 100;
                proteins += p.Proteins * p.Volume / 100;
                fats += p.Fats * p.Volume / 100;
            }

            dishes.Calories = calories;
            dishes.Carbohydrates = carbo;
            dishes.Proteins = proteins;
            dishes.Fats = fats;
            dishes.Date = System.DateTime.Now;

            db.Dishes.Add(dishes);
            db.SaveChanges();

            int id = dishes.Id;


           
            foreach (Product p in selectedProducts) {
                Dishes_Products dishesProducts = new Dishes_Products();
                dishesProducts.Id_Dishes = id;

                dishesProducts.Id_Product = p.Id;
                dishesProducts.gram = p.Volume;
                db.Dishes_Products.Add(dishesProducts);
                db.SaveChanges();
            }

            


            return RedirectToAction("Index", "Dishes");
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


        public ActionResult Edit(int? id)
        {
            GlobalModel global = new GlobalModel();
            global.Products = db.Products.ToList();
            global.Dishes_Products = db.Dishes_Products.Where(x => x.Id_Dishes == id).ToList<Dishes_Products>();
            global.DishesList = db.Dishes.Where(x => x.Id == id).ToList<Dishes>();
          
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(global);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GlobalModel list, Dishes dishes)
        {
            var selectedProducts = list.Products.Where(x => x.Volume > 0).ToList<Product>();


            float calories = 0, carbo = 0, proteins = 0, fats = 0;

            foreach (Product p in selectedProducts)
            {
                calories += p.Calories * p.Volume / 100;
                carbo += p.Carbohydrates * p.Volume / 100;
                proteins += p.Proteins * p.Volume / 100;
                fats += p.Fats * p.Volume / 100;
            }

            dishes.Calories = calories;
            dishes.Carbohydrates = carbo;
            dishes.Proteins = proteins;
            dishes.Fats = fats;
            dishes.Date = System.DateTime.Now;

            db.Dishes.Add(dishes);
            db.SaveChanges();

            int id = dishes.Id;



            foreach (Product p in selectedProducts)
            {
                Dishes_Products dishesProducts = new Dishes_Products();
                dishesProducts.Id_Dishes = id;

                dishesProducts.Id_Product = p.Id;
                dishesProducts.gram = p.Volume;
                db.Dishes_Products.Add(dishesProducts);
                db.SaveChanges();
            }




            return RedirectToAction("Index", "Dishes");
        }


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
