using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BodyLog.Models
{
    public class DailyModel
    {
        [Display(Name = "Data")]
        [Required(ErrorMessage = "Wprowadź datę")]
        public DateTime date { get; set; }

        [Display(Name = "Waga w gramach")]
        [Required(ErrorMessage = "Wprowadź liczbę kalorii")]
        public float weight { get; set; }
    }
}