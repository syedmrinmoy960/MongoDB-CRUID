using MongoDB.Driver;
using MongoDB_CRUID.Models.Entites.RequestEntites;
using MongoDB_CRUID.Models;
using MongoDB_CRUID.Repositories.IRepository;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using Microsoft.AspNetCore.Http;

namespace MongoDB_CRUID.Repositories.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly IMongoDatabase _database;
        private readonly MongoDBSettings _mongoSettings;
        public DashboardRepository(IMongoDatabase database, IOptions<MongoDBSettings> mongoSettings)
        {
            _database = database;
            _mongoSettings = mongoSettings.Value;
        }


        public async Task<List<LineChartData>> GetLineChartData()
        {
            var logsCollection = _database.GetCollection<eclogs>(_mongoSettings.LogsCollectionName);

          
            var aggregation = await logsCollection.Aggregate().ToListAsync();

           
            var startDate = DateTime.UtcNow.Date.AddDays(-29);
            var endDate = DateTime.UtcNow.Date; 
            var dateRange = Enumerable.Range(0, 30)
                .Select(i => startDate.AddDays(i))
                .ToList();

            var newdata = dateRange
                .GroupJoin(
                    aggregation,
                    date => date,
                    entry => entry.Time.Date,
                    (date, entries) => new LineChartData
                    {
                        Date = date.ToString("yyyy-MM-dd"),
                        

                        Count = entries.Count()
                    }
                )
                .OrderBy(l => l.Date)
                .ToList();

            return newdata;
        }


        public async Task<List<PieChartData>> GetPieChartData(PieChartRequestEntities pieChartRequestEntities)
        {
            var logsCollection = _database.GetCollection<eclogs>(_mongoSettings.LogsCollectionName);


            var aggregation = await logsCollection.Aggregate().ToListAsync();

            var startDate = DateTime.UtcNow.Date.AddDays(-29);
            var endDate = DateTime.UtcNow.Date;
            var dateRange = Enumerable.Range(0, 30)
                .Select(i => startDate.AddDays(i))
                .ToList();

            var newdata = aggregation
                .GroupBy(entry => entry.RequestFor)
                .Select(g => new PieChartData
                {
                    RequestFor = g.Key,
                    Count = g.Count()
                })
                .OrderBy(l => l.RequestFor) 
                .ToList();

            return newdata;
        }

        public async Task<List<StockChartData>> GetStockChartData()
        {
            var logsCollection = _database.GetCollection<eclogs>(_mongoSettings.LogsCollectionName);

            var aggregation = await logsCollection.Aggregate().ToListAsync();

            var startDate = DateTime.UtcNow.Date.AddDays(-29);
            var endDate = DateTime.UtcNow.Date;
            var dateRange = Enumerable.Range(0, 30)
                .Select(i => startDate.AddDays(i))
                .ToList();

            var newdata = aggregation
                .GroupBy(entry => new { entry.Time.Date, entry.RequestFor })
                .Select(g => new StockChartData
                {
                    Date = g.Key.Date,
                    RequestFor = g.Key.RequestFor,
                    Count = g.Count()
                })
                .OrderBy(l => l.Date)
                .ThenBy(l => l.RequestFor)
                .ToList();

            return newdata;
        }


        public async Task<List<AreaChartData>> GetAreaChartData(int billAmountPerHit)
        {
            var logsCollection = _database.GetCollection<eclogs>(_mongoSettings.LogsCollectionName);

            var aggregation = await logsCollection.Aggregate().ToListAsync();

            var newdata = aggregation
                .GroupBy(e => new { Year = e.Time.Year, Month = e.Time.Month })
                .Select(g => new
                {
                    YearMonth = new DateTime(g.Key.Year, g.Key.Month, 1),
                    TotalHits = g.Count(),
                    SuccessfulHits = g.Count(e => e.StatusCode == 200)
                })
                .Select(a => new AreaChartData
                {
                    Month = a.YearMonth.ToString("yyyy-MM"),
                    TotalHits = a.TotalHits,
                    TotalBill = a.SuccessfulHits * billAmountPerHit
                })
                .OrderBy(a => a.Month) 
                .ToList();

            return newdata;
        }


        public async Task<List<StatusPieChartData>> GetStatusPieChartData()
        {
            var logsCollection = _database.GetCollection<eclogs>(_mongoSettings.LogsCollectionName);

            var aggregation = await logsCollection.Aggregate().ToListAsync();

            var now = DateTime.UtcNow.Date;
            var firstDayOfCurrentMonth = new DateTime(now.Year, now.Month, 1);
            var lastDayOfPreviousMonth = firstDayOfCurrentMonth.AddDays(-1);
            var firstDayOfPreviousMonth = new DateTime(lastDayOfPreviousMonth.Year, lastDayOfPreviousMonth.Month, 1);

            var filter = Builders<eclogs>.Filter.Gte(log => log.Time, firstDayOfPreviousMonth) &
                         Builders<eclogs>.Filter.Lte(log => log.Time, lastDayOfPreviousMonth);

            //var aggregation = await logsCollection.Find(filter).ToListAsync();

            var newdata = aggregation
                .GroupBy(e => new { Year = e.Time.Year, Month = e.Time.Month })
                .Select(g => new
                {
                    YearMonth = new DateTime(g.Key.Year, g.Key.Month, 1),
                    FailedHits = g.Count(e => e.StatusCode != 200),
                    SuccessfulHits = g.Count(e => e.StatusCode == 200)
                })
                .Select(a => new StatusPieChartData
                {
                    Month = a.YearMonth.ToString("yyyy-MM"),
                    SuccessCount = a.SuccessfulHits,
                    FailedCount = a.FailedHits
                })
                .OrderBy(a => a.Month)
                .ToList();

            return newdata;
        }

         public async Task<List<ApiHitCount>> GetApiHitCounts()
         {
             var logsCollection = _database.GetCollection<eclogs>(_mongoSettings.LogsCollectionName);

             var aggregation = await logsCollection.Aggregate()
                 .Group(e => e.ApiName, g => new ApiHitCount
                 {
                     ApiName = g.Key,
                     HitCount = g.Count()
                 })
                 .ToListAsync();

             return aggregation;
         }

      








    }
}
