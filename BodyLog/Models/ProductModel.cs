using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BodyLog.Models
{
    [MetadataType(typeof(Product))]
    public partial class User
    {
    }

    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nazwa produktu")]
        [Required(ErrorMessage = "Wprowadz nazwe produktu")]
        [Remote("IsNameExists", "Products", ErrorMessage = "Produkt o takiej nazwie już istnieje")]
        public string Name { get; set; }

        [Display(Name = "Kalorie na 100g")]
        [Required(ErrorMessage = "Wprowadz kalorie")]
        public float Calories { get; set; }

        [Display(Name = "Białko na 100g")]
        [Required(ErrorMessage = "Wprowadz białko")]
        [MinMaxWeightOfProductProteins]
        public float Proteins { get; set; }

        [Display(Name = "Węglowodany na 100g")]
        [Required(ErrorMessage = "Wprowadz węglowodany")]
        [MinMaxWeightOfProductCarbohydrates]
        public float Carbohydrates { get; set; }

        [Display(Name = "Tłuszcze na 100g")]
        [Required(ErrorMessage = "Wprowadz tłuszcze")]
        [MinMaxWeightOfProductFats]
        public float Fats { get; set; }

        [NotMapped]
        [MaxWeightOfProductsSum]
        public byte weightValid { get; set; }       //prop only for valid

        [NotMapped]
        public bool IsChecked { get; set; }

        [Display(Name = "Ilość")]
        [Required(ErrorMessage = "Wprowadz ilość")]
        [NotMapped]
        public float Volume { get; set; } 
    }

    public class GlobalModel
    {
        public List<Product> Products { get; set; }
        public Dishes Dishes { get; set; }
        public List<Dishes> DishesList { get; set; }
        public List<Dishes_Products> Dishes_Products { get; set; }
        public Body Body { get; set; }
        public List<Body> BodyList { get; set; }
        public Training_PlansModel Training_Plans { get; set; }
        public List<Activities> Activities { get; set; }
        //   public List<Dishes_Products> Dishes_ProductsList { get; set; }
    }
}

