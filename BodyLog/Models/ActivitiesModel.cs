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

    public class Activities
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Typ")]
        [Required(ErrorMessage = "Wprowadz typ aktywności")]
        public string Type { get; set; }

        [Display(Name = "Czas")]
        [Required(ErrorMessage = "Wprowadz czas aktywności")]
        public int Time { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Wprowadz opis")]
        public string Description { get; set; }
    }
}