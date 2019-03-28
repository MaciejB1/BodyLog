using BodyLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.BusinessLogic;


namespace BodyLog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Foods()
        {
            var dataContext = new BodyLogDataContext();
            var foods = from m in dataContext.Foods select m;

            return View(foods);
        }

        public ActionResult AddProductForm()
        {
            return View();
        }

        public ActionResult AddProduct()
        {
            ViewBag.Message = "Add Product";

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                int RecordCreated = ProductsProcessor.AddProduct(model.Name, model.Calories);
                return RedirectToAction("Index");
            }

            return View();
            
        }

        public ActionResult AddDiaryLog()
        {
            ViewBag.Message = "Add Dialy Log";

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDiaryLog(DailyModel model)
        {
            if (ModelState.IsValid)
            {
               // int RecordCreated = ProductsProcessor.AddProduct(model.Name, model.Calories);
              //  return RedirectToAction("Index");
            }

            return View();

        }



        public ActionResult FoodDiaryView()
        {
            ViewBag.Message = "Choose an option";

            return View();
        }

        public ActionResult ViewProducts()
        {
            ViewBag.Message = "Products List";

            var data = ProductsProcessor.LoadProducts();
            List<ProductModel> products = new List<ProductModel>();

            foreach (var row in data)
            {
                products.Add(new ProductModel
                {
                    Name = row.Name,
                    Calories = row.Calories
                });
            }

            return View(products);
        }

    }
}