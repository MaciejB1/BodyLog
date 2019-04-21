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
        public int Id { get; set; }

        [Display(Name = "Nazwa Dania")]
        [Required(ErrorMessage = "Wprowadz nazwe Dania")]
        public string Name { get; set; }

        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        [Display(Name = "Liczba kalorii")]
        [Required(ErrorMessage = "Wprowadź liczę Kalorii")]
        public float Calories { get; set; }
    }

}