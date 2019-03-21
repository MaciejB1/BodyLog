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
        public static int AddProduct(string name, int calories,
            int idCategories, int idAccount)
        {
            ProductsModel data = new ProductsModel
            {
                Name = name,
                Calories = calories,
                IdCategories = idCategories,
                IdAccount = idAccount
            };

            string sql = @"INSERT INTO Food_Products (name, calories, Food_Categories_idFood_Categories, Account_idAccount)
                            values(@Name, @Calories, @IdCategories, @IdAccount);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<ProductsModel> LoadProducts()
        {
            string sql = @"select name, calories, Food_Categories_idFood_Categories, Account_idAccount from Food_Products;";

            return SqlDataAccess.LoadData<ProductsModel>(sql);
        }
    }
}
