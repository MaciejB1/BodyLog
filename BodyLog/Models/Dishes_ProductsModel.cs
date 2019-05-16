using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BodyLog.Models
{
    public class Dishes_Products
    {
        [Key, Column(Order = 0)]
        public int Id_Dishes { get; set; }

        [Key, Column(Order = 1)]
        public int Id_Product { get; set; }

       public float gram { get; set; }
    }

}