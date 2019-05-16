using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BodyLog.Models
{
    public class Dishes_Products    
    {
        [Key]
        [Required]
        public int Id_Dishes { get; set; }

        [Key]
        [Required]
        public int Id_Product { get; set; }

      
        public float gram { get; set; }
    }

}