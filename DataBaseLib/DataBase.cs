using System;
using System.Collections.Generic;
using DataModelLib;

namespace DataBaseLib
{
    public class DataBase
    {
        private DbConnectionLib.DataBase _db;

        public DataBase()
        {
            _db = new DbConnectionLib.DataBase();
            _db.Init();
        }

        public List<Product> GetAllProducts()
        {
            var sql = "SELECT * FROM view_products";
            var res = _db.ExecuteSelect(in sql, out var outputData);

            if (!res) throw new Exception(); //TODO Продумать свой тип исключения

            if (!outputData.HasRows) throw new Exception(); //TODO Продумать свой тип исключения

            var products = new List<Product>();
            
            while (outputData.Read())
            {
                products.Add(new Product
                {
                    Id = outputData.GetInt32("id"),
                    Name = outputData.GetString("name"),
                    Price = outputData.GetDouble("price"),
                    Amount = outputData.GetInt32("amount"),
                    Annotation = outputData.GetString("annotation"),
                    Image = outputData.GetString("image")
                });
            }

            return products;
        }
    }
}