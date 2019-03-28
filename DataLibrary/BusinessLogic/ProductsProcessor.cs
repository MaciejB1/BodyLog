using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class ProductsProcessor
    {
        public static int AddProduct(string name, int calories)
        {
            ProductsModel data = new ProductsModel
            {
                Name = name,
                Calories = calories
            };

            string sql = @"INSERT INTO Foods (name, calories) values(@Name, @Calories);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<ProductsModel> LoadProducts()
        {
            string sql = @"select name, calories from Foods;";

            return SqlDataAccess.LoadData<ProductsModel>(sql);
        }
    }
}
