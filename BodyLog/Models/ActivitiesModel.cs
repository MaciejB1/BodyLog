using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BodyLog.Models
{
    [MetadataType(typeof(ActivitiesModels))]
    public class ActivitiesModels
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Typ")]
        [Required(ErrorMessage = "Musisz podać typ ćwiczenia")]
        public string Type { get; set; }

        

        [Display(Name = "Opis")]
        public string Description { get; set; }

        public virtual string UserId { get; set; }
    }

    public class Global_Model
    {
        public List<ActivitiesModels> Activities { get; set; }
        public TrainingPlansModel Training { get; set; }
        public List<TrainingPlansModel> TrainingsList { get; set; }
        public List<Activities_Plans> Activities_Plans { get; set; }
    }
}