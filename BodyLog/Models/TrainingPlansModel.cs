using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BodyLog.Models
{
    public class TrainingPlansModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Musisz podać nazwę treningu")]
        public string Name { get; set; }

        [Display(Name = "Data rozpoczęcia")]
        [Required(ErrorMessage = "Musisz podać datę rozpoczęcia treningu")]
        [DataType(DataType.Date, ErrorMessage = "Musisz wprowadzić prawidłową datę")]
        public DateTime Date_start { get; set; }

        [Display(Name = "Data zakończenia")]
        [Required(ErrorMessage = "Musisz podać datę zakończenia treningu")]
        [DataType(DataType.Date, ErrorMessage = "Musisz wprowadzić prawidłową datę")]
        public DateTime Date_end { get; set; }

        public virtual string UserId { get; set; }
    }
}