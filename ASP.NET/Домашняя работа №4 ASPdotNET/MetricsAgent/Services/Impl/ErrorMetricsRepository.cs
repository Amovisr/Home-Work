using Dapper;
using MetricsAgent.Models;
using Microsoft.Extensions.Options;
using System.Data.SQLite;

namespace MetricsAgent.Services.Impl
{
    public class ErrorMetricsRepository : IErrorMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";


        #region Services

        private readonly IOptions<DatabaseOptions> _databaseOptions;

        #endregion

        public ErrorMetricsRepository(IOptions<DatabaseOptions> databaseOptions)
        {
            _databaseOptions = databaseOptions;
        }


        public void Create(ErrorMetric item)
        {

            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);
            connection.Open();
            connection.Execute("INSERT INTO errormetrics(value, time) VALUES(@value, @time)", new
            {
                value = item.Value,
                time = item.Time
            });

        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);
            connection.Open();
            connection.Execute("DELETE FROM errormetrics WHERE id=@id",
            new
            {
                id = id
            });

        }

        public void Update(ErrorMetric item)
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);
            connection.Execute("UPDATE errormetrics SET value = @value, time = @time WHERE id = @id",
            new
            {
                value = item.Value,
                time = item.Time,
                id = item.Id
            });
        }


        public IList<ErrorMetric> GetAll()
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);
            return connection.Query<ErrorMetric>("SELECT Id, Time, Value FROM errormetrics").ToList();
        }

        public ErrorMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);
            ErrorMetric metric = connection.QuerySingle<ErrorMetric>("SELECT Id, Time, Value FROM errormetrics WHERE id = @id",
            new { id = id });
            return metric;

        }

        /// <summary>
        /// Получение данных по нагрузке на ЦП за период
        /// </summary>

        public IList<ErrorMetric> GetByTimePeriod(TimeSpan timeFrom, TimeSpan timeTo)
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);
            List<ErrorMetric> metrics = connection.Query<ErrorMetric>("SELECT * FROM errormetrics where time >= @timeFrom and time <= @timeTo",
               new { timeFrom = timeFrom.TotalSeconds, timeTo = timeTo.TotalSeconds }).ToList();
            return metrics;
        }
    }
}
