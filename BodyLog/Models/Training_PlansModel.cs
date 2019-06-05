using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BodyLog.Models
{
    public class Training_PlansModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Wprowadz nazwę")]
        public string Name { get; set; }

        [Display(Name = "Data rozpoczęcia")]
        [DataType(DataType.Date)]
        public DateTime? Date_start { get; set; }

        [Display(Name = "Data zakończenia")]
        [DataType(DataType.Date)]
        public DateTime? Date_end { get; set; }
    }
}