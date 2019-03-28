using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BodyLog.Models
{
    public class ProductModel
    {
        [Display(Name = "Nazwa produktu")]
        [Required(ErrorMessage = "Wprowadź nazwę produktu.")]
        public string Name { get; set; }

        [Display(Name = "Kalorie na 100g")]
        [Required(ErrorMessage = "Wprowadź liczbę kalorii")]
        public int Calories { get; set; }
    }
}