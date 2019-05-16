using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BodyLog.Models
{
    public partial class User
    {
    }

    public class Body
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Waga")]
        [Required(ErrorMessage = "Wprowadz swoja wage")]
        public float Weight { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Wprowadz opis")]
        public string Description { get; set; }
    }
}