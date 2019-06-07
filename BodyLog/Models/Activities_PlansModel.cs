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
        public int Id_ActivitiesModels { get; set; }

        [Key, Column(Order = 1)]
        public int Training_Plans { get; set; }

    }

}