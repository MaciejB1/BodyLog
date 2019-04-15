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
        public static int AddProduct(string name, float calories, float proteins,
            float carbohydrates, float fats)
        {
            ProductsModel data = new ProductsModel
            {
                Name = name,
                Calories = calories,
                Proteins = proteins,
                Carbohydrates = carbohydrates,
                Fats = fats
            };

            string sql = @"INSERT INTO Products (name, calories, proteins, carbohydrates, fats)
            values(@Name, @Calories, @Proteins, @Carbohydrates, @Fats);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int EditProduct(string name, float calories, float proteins,
            float carbohydrates, float fats, int id)
        {
            ProductsModel data = new ProductsModel
            {
                Name = name,
                Calories = calories,
                Proteins = proteins,
                Carbohydrates = carbohydrates,
                Fats = fats
            };

            string sql = @"UPDATE Products set calories = @Calories, name = @Name, 
                    proteins = @proteins, carbohydrates = @Carbohydrates, fats = @Fats
                    where id = (select id from products where name = @Name);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<ProductsModel> LoadProducts()
        {
            string sql = @"select id, name, calories, proteins, carbohydrates, fats from Products;";

            return SqlDataAccess.LoadData<ProductsModel>(sql);
        }
    }
}
