using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BodyLog.Models
{
    public class Dishes
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nazwa Dania")]
        [Required(ErrorMessage = "Wprowadz nazwe Dania")]
        public string Name { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Display(Name = "Liczba kalorii")]
        [Required(ErrorMessage = "Wprow dź liczę Kalorii")]
        public float Calories { get; set; }

        [Display(Name = "Białko w gramach")]
        [Required(ErrorMessage = "Wprowadź białko")]
        public float Proteins { get; set; }

        [Display(Name = "Węglowodany w gramach")]
        [Required(ErrorMessage = "Wprowadź węglowodany")]
        public float Carbohydrates { get; set; }

        [Display(Name = "Tłuszcze w gramach")]
        [Required(ErrorMessage = "Wprowadź tłuszcze")]
        public float Fats { get; set; }
    }

}