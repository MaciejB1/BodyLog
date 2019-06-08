using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BodyLog.Models
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nazwa filmu")]
        [Required]
        public string name { get; set; }

        [Required]
        public string yt_id { get; set; }
    }
}