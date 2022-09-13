using MetricsAgent.Models;
using System.Data.SQLite;

namespace MetricsAgent.Services.Impl
{
    public class ErrorMetricsRepository : IErrorMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";


        public void Create(ErrorMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            // Создаём команду
            using var cmd = new SQLiteCommand(connection);
            // Прописываем в команду SQL-запрос на вставку данных
            cmd.CommandText = "INSERT INTO errormetrics(count, time) VALUES(@count, @time)";
            // Добавляем параметры в запрос из нашего объекта
            cmd.Parameters.AddWithValue("@count", item.Count);
            // В таблице будем хранить время в секундах
            cmd.Parameters.AddWithValue("@time", item.Time);
            // подготовка команды к выполнению
            cmd.Prepare();
            // Выполнение команды
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);
            // Прописываем в команду SQL-запрос на удаление данных
            cmd.CommandText = "DELETE FROM errormetrics WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public IList<ErrorMetric> GetAll()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);
            // Прописываем в команду SQL-запрос на получение всех данных из таблицы
            cmd.CommandText = "SELECT * FROM errormetrics";
            var returnList = new List<ErrorMetric>();
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                // Пока есть что читать — читаем
                while (reader.Read())
                {
                    // Добавляем объект в список возврата
                    returnList.Add(new ErrorMetric
                    {
                        Id = reader.GetInt32(0),
                        Count = reader.GetInt32(1),
                        Time = reader.GetInt32(2)
                    });
                }
            }
            return returnList;
        }

        public ErrorMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "SELECT * FROM errormetrics WHERE id=@id";
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                // Если удалось что-то прочитать
                if (reader.Read())
                {
                    // возвращаем прочитанное
                    return new ErrorMetric
                    {
                        Id = reader.GetInt32(0),
                        Count = reader.GetInt32(1),
                        Time = reader.GetInt32(2)
                    };
                }
                else
                {
                    // Не нашлась запись по идентификатору, не делаем ничего
                    return null;
                }
            }
        }

        /// <summary>
        /// Получение данных по нагрузке на ЦП за период
        /// </summary>
        /// <param name="timeFrom">Время начала периода</param>
        /// <param name="timeTo">Время окончания периода</param>
        /// <returns></returns>
        public IList<ErrorMetric> GetByTimePeriod(DateTimeOffset timeFrom, DateTimeOffset timeTo)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);
            // Прописываем в команду SQL-запрос на получение всех данных за период из таблицы
            cmd.CommandText = "SELECT * FROM errormetrics where time >= @timeFrom and time <= @timeTo";
            cmd.Parameters.AddWithValue("@timeFrom", timeFrom);
            cmd.Parameters.AddWithValue("@timeTo", timeTo);
            var returnList = new List<ErrorMetric>();
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                // Пока есть что читать — читаем
                while (reader.Read())
                {
                    // Добавляем объект в список возврата
                    returnList.Add(new ErrorMetric
                    {
                        Id = reader.GetInt32(0),
                        Count = reader.GetInt32(1),
                        Time = reader.GetInt32(2)
                    });
                }
            }
            return returnList;
        }

        public void Update(ErrorMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            using var cmd = new SQLiteCommand(connection);
            // Прописываем в команду SQL-запрос на обновление данных
            cmd.CommandText = "UPDATE errormetrics SET count = @count, time = @time WHERE id = @id; ";
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@count", item.Count);
            cmd.Parameters.AddWithValue("@time", item.Time);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}