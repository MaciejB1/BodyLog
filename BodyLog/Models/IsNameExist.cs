//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Runtime.Remoting.Metadata.W3cXsd2001;
//using System.Web;
//
//namespace BodyLog.Models
//{
//    public class IsNameExist : ValidationAttribute
//    {
//        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//        {
//            var product = (Product)validationContext.ObjectInstance;
//
//            return ValidationResult.Success;
//        }
//    }
//}