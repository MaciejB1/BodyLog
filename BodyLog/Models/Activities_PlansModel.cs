using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BodyLog.Models
{
    public class Activities_Plans
    {
        [Key, Column(Order = 0)]
        public int Id_Activities { get; set; }

        [Key, Column(Order = 1)]
        public int Id_Training_Plans { get; set; }

        [Display(Name = "Czas w minutach")]
        [Required(ErrorMessage = "Musisz czas wykonywania ćwiczenia")]
        [Range(1, 999, ErrorMessage = "Czas musi być dodatni")]
        public int Time { get; set; }

    }

}