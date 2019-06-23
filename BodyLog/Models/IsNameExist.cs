using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNet.Identity;

namespace BodyLog.Models
{
    public class IsNameEx : ValidationAttribute
    {
        private DefaultConnection db = new DefaultConnection();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var product = (Product)validationContext.ObjectInstance;

            var products = from p in db.Products
                select p;

            if(product.Name == null)
                return ValidationResult.Success;

            foreach (var pro in products)
            {
                if (pro.Name.ToLower() == product.Name.ToLower() && pro.UserId == System.Web.HttpContext.Current.User.Identity.GetUserId())
                    return new ValidationResult("Produkt o takiej nazwie już istnieje.");
            }

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