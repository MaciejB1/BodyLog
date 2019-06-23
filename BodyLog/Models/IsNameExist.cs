using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace BodyLog.Models
{
    public class IsNameEx : ValidationAttribute
    {
        private DefaultConnection db;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            db = new DefaultConnection();
            var product = (Product) validationContext.ObjectInstance;
            List<Product> proListEdit = new List<Product>();
            List<Product> proList = new List<Product>();

            foreach (var row in db.Products)
            {
                proList.Add(row);
                if (row.Id == product.Id)
                    proListEdit.Add(row);
            }

//            var productsToEdit = from p in db.Products
//                select p;


            if (product.Name == null)
                return ValidationResult.Success;

            if (proListEdit.Count == 0)
            {
                proListEdit.Clear();
                foreach (var pro in proList)
                {
                    if (pro.Name.ToLower() == product.Name.ToLower() &&
                        pro.UserId == System.Web.HttpContext.Current.User.Identity.GetUserId())
                        return new ValidationResult("Produkt o takiej nazwie już istnieje.");
                }

                proList.Clear();
                return ValidationResult.Success;
            }

            else if (product.Name.ToLower() != proListEdit.First().Name.ToLower())
            {
                proListEdit.Clear();
                foreach (var pro in proList)
                {
                    if (pro.Name.ToLower() == product.Name.ToLower() &&
                        pro.UserId == System.Web.HttpContext.Current.User.Identity.GetUserId())
                        return new ValidationResult("Produkt o takiej nazwie już istnieje.");
                }

                proList.Clear();
                return ValidationResult.Success;
            }

            proList.Clear();
            proListEdit.Clear();
            return ValidationResult.Success;
        }
    }
    public class DateValid : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var weights = (Weights)validationContext.ObjectInstance;
            if (weights.Date > DateTime.Today)
                return new ValidationResult("Data nie może być późniejsza niż dzisiaj");
            return ValidationResult.Success;
        }
    }
}