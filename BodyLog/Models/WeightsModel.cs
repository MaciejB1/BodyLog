using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BodyLog.Models
{
    public class Weights
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Waga")]
        [Required(ErrorMessage = "Musisz podać wagę")]
        [Range(1, 999, ErrorMessage = "Waga musi być dodatnia")]
        public float Weight { get; set; }

        [Display(Name = "Data ważenia")]
        [Required(ErrorMessage = "Musisz podać datę ważenia")]
        [DataType(DataType.Date, ErrorMessage = "Musisz wprowadzić prawidłową datę")]
        [DateValid]
        public DateTime Date { get; set; }

        public virtual string UserId { get; set; }
    }
}