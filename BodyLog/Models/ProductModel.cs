using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BodyLog.Models
{
    public class ProductModel
    {
        [Display(Name = "Name of product")]
        [Required(ErrorMessage = "You need to input a name of product")]
        public string Name { get; set; }

        [Display(Name = "Calories per 100g")]
        [Required(ErrorMessage = "You need to input the calories")]
        public int Calories { get; set; }

        [Display(Name = "Category")]
        public int IdCategory { get; set; }
    }
}