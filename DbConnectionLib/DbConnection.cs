using System;
using System.IO;

using static System.Text.Json.JsonSerializer;

namespace DbConnectionLib
{
    public record DbConnection
    {
        public string Server { get; init; }
        public string Database { get; init; }
        public string Uid { get; init; }
        public string Pwd { get; init; }
        
        public static event Action<string> Info;
        public static event Action<string> Error;
        public static event Action<string> Success;

        public override string ToString()
        {
            //Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;
            return $"Server={Server};Database={Database};Uid={Uid};Pwd={Pwd};";
        }
        
        public bool SerializeJson(string path)
        {
            Info?.Invoke("Создание шаблона JSON для подключения к БД");

            using (var file = new FileStream(path, FileMode.OpenOrCreate))
            {
                SerializeAsync(file, this);
            }

            Info?.Invoke($"Успешное создание шаблонного файла JSON для подключения к БД");
            Info?.Invoke($"Шаблонный файл: {path}");
            return true;
        }
        
        public static DbConnection DeserializeJson(string path)
        {
            Info?.Invoke("Получение данных из JSON для подключения к БД");

            DbConnection temp;
            
            try
            {
                using var file = new FileStream(path, FileMode.Open);
                temp = DeserializeAsync<DbConnection>(file).Result;
            }
            catch (Exception)
            {
                Error?.Invoke("Ошибка получения данных из JSON для подключения к БД");
                return null;
            }

            Success?.Invoke("Успешное получение данных из JSON для подключения к БД");
            return temp;
        }
    }
}