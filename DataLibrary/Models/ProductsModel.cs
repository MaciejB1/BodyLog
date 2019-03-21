using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class ProductsModel
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public int IdCategories { get; set; }
        public int IdAccount { get; set; }
    }
}
