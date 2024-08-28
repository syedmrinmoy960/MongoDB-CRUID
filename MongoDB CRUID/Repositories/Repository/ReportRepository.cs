using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_CRUID.Models;
using MongoDB_CRUID.Repositories.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB_CRUID.Repositories.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly IMongoCollection<eclogs> _LogsCollectionName;

        public ReportRepository(IOptions<MongoDBSettings> mongoDBSettings)
        {
            var mongoClient = new MongoClient(mongoDBSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _LogsCollectionName = mongoDatabase.GetCollection<eclogs>(mongoDBSettings.Value.LogsCollectionName);
        }

        /* public async Task<List<eclogs>> GetAllAlleclogs(string? requestFor = null)
         {
             var filterBuilder = Builders<eclogs>.Filter;
             var filter = filterBuilder.Empty;

             if (!string.IsNullOrEmpty(requestFor))
             {
                 filter &= filterBuilder.Eq(e => e.RequestFor, requestFor);
             }

             return await _LogsCollectionName.Find(filter).ToListAsync();
         }*/

        public async Task<List<eclogs>> GetAll(string? requestFor = null, DateTime? start = null, DateTime? end = null)
        {
            var filterBuilder = Builders<eclogs>.Filter;
            var filters = new List<FilterDefinition<eclogs>>();

            // Add RequestFor filter if provided
            if (!string.IsNullOrEmpty(requestFor))
            {
                filters.Add(filterBuilder.Eq(e => e.RequestFor, requestFor));
            }

            // Add start date filter if provided
            if (start.HasValue)
            {
                filters.Add(filterBuilder.Gte(e => e.Time, start.Value));
            }

            // Add end date filter if provided
            if (end.HasValue)
            {
                // Adjust end date to include the entire day (optional)
                var adjustedEnd = end.Value.AddHours(23).AddMinutes(59).AddSeconds(59);
                filters.Add(filterBuilder.Lte(e => e.Time, adjustedEnd));
            }

            // Combine filters if any are added, otherwise use an empty filter
            var combinedFilter = filters.Count > 0 ? filterBuilder.And(filters) : filterBuilder.Empty;

            return await _LogsCollectionName.Find(combinedFilter).ToListAsync();
        }




        public async Task<ReportSummary> GetReportSummary(string? requestFor = null)
        {
            var filterBuilder = Builders<eclogs>.Filter;
            var filter = filterBuilder.Empty;

            if (!string.IsNullOrEmpty(requestFor))
            {
                filter &= filterBuilder.Eq(e => e.RequestFor, requestFor);
            }

            var aggregateResult = await _LogsCollectionName.Aggregate()
                .Match(filter)  // Apply the filter in the aggregation pipeline
                .Group(e => e.RequestFor, g => new ReportDetail
                {
                    RequestFor = g.Key,
                    Count = g.Count(),
                    Amount = g.Count() * 5,
                    SuccessCount = g.Count(e => e.StatusCode == 200),
                    FailCount = g.Count(e => e.StatusCode != 200)
                })
                .ToListAsync();

            return new ReportSummary
            {
                Details = aggregateResult
            };
        }

        public async Task<List<string>> GetUniqueRequestForValues()
        {
            
            var uniqueRequestForValues = await _LogsCollectionName
                .Distinct<string>("RequestFor", Builders<eclogs>.Filter.Empty)
                .ToListAsync();

            return uniqueRequestForValues;
        }



    }
}
