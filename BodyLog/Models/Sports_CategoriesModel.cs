using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BodyLog.Models
{
    public class Sports_CategoriesModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Wprowadz nazwę")]
        public string Name { get; set; }
    }
}