using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BodyLog.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa produktu")]
        [Required(ErrorMessage = "Wprowadz nazwe produktu")]
        public string Name { get; set; }

        [Display(Name = "Kalorie na 100g")]
        [Required(ErrorMessage = "Wprowadz kalorie")]
        public float Calories { get; set; }

        [Display(Name = "Białko na 100g")]
        [Required(ErrorMessage = "Wprowadz białko")]
        public float Proteins { get; set; }

        [Display(Name = "Węglowodany na 100g")]
        [Required(ErrorMessage = "Wprowadz węglowodany")]
        public float Carbohydrates { get; set; }

        [Display(Name = "Tłuszcze na 100g")]
        [Required(ErrorMessage = "Wprowadz tłuszcze")]
        public float Fats { get; set; }
    }

    public class MainDB : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}