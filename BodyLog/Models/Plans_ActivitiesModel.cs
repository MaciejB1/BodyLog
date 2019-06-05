using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BodyLog.Models
{
    public class Plans_ActivitiesModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Dzień")]
        [Required(ErrorMessage = "Wprowadz dzień")]
        public string Day { get; set; }
    }
}