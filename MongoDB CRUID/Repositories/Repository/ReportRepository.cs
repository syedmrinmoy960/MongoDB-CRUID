using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_CRUID.Models;
using MongoDB_CRUID.Repositories.IRepository;

namespace MongoDB_CRUID.Repositories.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly IMongoCollection<eclogs> _LogsCollectionName;

        public ReportRepository(IOptions<MongoDBSettings> mongoDBSettings)
        {

            var mongoClient = new MongoClient(mongoDBSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
            //_usersCollection = mongoDatabase.GetCollection<Users>(mongoDBSettings.Value.CollectionName);
            _LogsCollectionName = mongoDatabase.GetCollection<eclogs>(mongoDBSettings.Value.LogsCollectionName);
        }

        public async Task<List<eclogs>> GetAllAlleclogs()
        {
            return await _LogsCollectionName.Find(_ => true).ToListAsync();
        }

        public async Task<ReportSummary> GetReportSummary()
        {
            var aggregateResult = await _LogsCollectionName.Aggregate()
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

       
      


    }
}
