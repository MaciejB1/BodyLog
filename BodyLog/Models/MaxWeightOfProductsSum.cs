using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BodyLog.Models
{
    public class MaxWeightOfProductsSum : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var product = (Product) validationContext.ObjectInstance;

            var weight = product.Fats + product.Proteins + product.Carbohydrates;

            return (weight <= 100 && weight >= 0)
                ? ValidationResult.Success
                : new ValidationResult("Suma makroskładników nie może być mniejsza niż 0 i większa niż 100");
        }
    }

    public class MinMaxWeightOfProductFats : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var product = (Product) validationContext.ObjectInstance;

            if (product.Fats > 100)
                return new ValidationResult("Za duża ilość tłuszczy");
            if (product.Fats < 0)
                return new ValidationResult("Tłuszcze nie mogą być ujemne");

            return ValidationResult.Success;
        }
    }

    public class MinMaxWeightOfProductProteins : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var product = (Product) validationContext.ObjectInstance;


            if (product.Proteins > 100)
                return new ValidationResult("Za duża ilość białka");
            if (product.Proteins < 0)
                return new ValidationResult("Białko nie może być ujemne");

            return ValidationResult.Success;
        }
    }

    public class MinMaxWeightOfProductCarbohydrates : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var product = (Product) validationContext.ObjectInstance;

            if (product.Carbohydrates > 100)
                    return new ValidationResult("Za duża ilość węglowodanów");
            if (product.Carbohydrates < 0)
                    return new ValidationResult("Weglowodany nie mogą być ujemne");

            return ValidationResult.Success;
        }
    }
    public class OnlyPositiveNumberOfCalories : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var product = (Product) validationContext.ObjectInstance;

            if (product.Calories < 0)
                    return new ValidationResult("Kalorie nie mogą być ujemne");

            return ValidationResult.Success;
        }
    }

    public class siemaValid : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var product = (Product)validationContext.ObjectInstance;

            if (product.GetType() != typeof(int))
                return new ValidationResult("Siema");

            return ValidationResult.Success;
        }
    }
}
