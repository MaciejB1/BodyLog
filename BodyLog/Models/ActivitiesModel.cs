using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BodyLog.Models
{
    public class ActivitiesModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Typ")]
        [Required(ErrorMessage = "Musisz podać typ ćwiczenia")]
        public string Type { get; set; }

        [Display(Name = "Czas")]
        [Required(ErrorMessage = "Musisz czas wykonywania ćwiczenia")]
        [Range(1, 999, ErrorMessage = "Czas musi być dodatni")]
        public int Time { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        public virtual string UserId { get; set; }
    }
}