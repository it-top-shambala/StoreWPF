using System;
using System.Collections.Generic;
using DataBaseLib.Exceptions;
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
            const string table_name = "view_products";
            var sql = $"SELECT * FROM {table_name}";
            var res = _db.ExecuteSelect(in sql, out var outputData);

            if (!res) throw new EmptyTableException("Ответ из базы данных не был получен.", TypeException.NotAnswer, table_name); //DONE Продумать свой тип исключения

            if (!outputData.HasRows) throw new NotAnswerException("Результат запроса вернул пустую таблицу.", TypeException.EmptyTable, table_name); //DONE Продумать свой тип исключения

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