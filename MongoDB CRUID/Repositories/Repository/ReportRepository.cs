using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_CRUID.Models;
using MongoDB_CRUID.Models.Entites.RequestEntites;
using MongoDB_CRUID.Models.Entites.ResponseEntities;
using MongoDB_CRUID.Repositories.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB_CRUID.Repositories.Repository
{
    public class ReportRepository : IReportRepository
    {

        private readonly IMongoDatabase _database;
        private readonly MongoDBSettings _mongoSettings;

        public ReportRepository(IMongoDatabase database, IOptions<MongoDBSettings> mongoSettings)
        {
            _database = database;
            _mongoSettings = mongoSettings.Value;
        }

        /* public async Task<List<eclogs>> GetAllECLogs(GetAllECLogsRequestEntity getAllECLogsRequestEntity)
         {
             try
             {
                 var logsCollection = _database.GetCollection<eclogs>(_mongoSettings.LogsCollectionName);
                 var filterBuilder = Builders<eclogs>.Filter;
                 var filters = new List<FilterDefinition<eclogs>>();

                 if (string.IsNullOrEmpty(getAllECLogsRequestEntity.Requester))
                 {
                     filters.Add(filterBuilder.Eq(e => e.RequestFor, getAllECLogsRequestEntity.Requester));
                 }


                 if (getAllECLogsRequestEntity.StartDate.HasValue)
                 {
                     filters.Add(filterBuilder.Gte(e => e.Time, getAllECLogsRequestEntity.StartDate.Value));
                 }

                 if (getAllECLogsRequestEntity.EndDate.HasValue)
                 {
                     var adjustedEnd = getAllECLogsRequestEntity.EndDate.Value.AddHours(23).AddMinutes(59).AddSeconds(59);
                     filters.Add(filterBuilder.Lte(e => e.Time, adjustedEnd));
                 }

                 var combinedFilter = filters.Count > 0 ? filterBuilder.And(filters) : filterBuilder.Empty;

                 var logs = await logsCollection.Find(combinedFilter).ToListAsync();

                 return logs;
             }
             catch (Exception ex)
             {
                 return null;
             }
         }*/

        public async Task<List<eclogs>> GetAllECLogs(GetAllECLogsRequestEntity getAllECLogsRequestEntity)
        {
            try
            {
                var logsCollection = _database.GetCollection<eclogs>(_mongoSettings.LogsCollectionName);
                var filterBuilder = Builders<eclogs>.Filter;
                var filters = new List<FilterDefinition<eclogs>>();

                if (!string.IsNullOrEmpty(getAllECLogsRequestEntity.Requester))
                {
                    filters.Add(filterBuilder.Eq(e => e.RequestFor, getAllECLogsRequestEntity.Requester));
                }

                if (getAllECLogsRequestEntity.StartDate.HasValue)
                {
                    filters.Add(filterBuilder.Gte(e => e.Time, getAllECLogsRequestEntity.StartDate));
                }

                // EndDate filtering
                if (getAllECLogsRequestEntity.EndDate.HasValue)
                {
                  
                    var endDate = getAllECLogsRequestEntity.EndDate.Value.AddDays(1).AddTicks(-1);
                    filters.Add(filterBuilder.Lte(e => e.Time, endDate));
                }

                // Combine filters
                var combinedFilter = filters.Count > 0 ? filterBuilder.And(filters) : filterBuilder.Empty;

                // Query the collection
                var logs = await logsCollection.Find(combinedFilter).ToListAsync();

                return logs;
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                return new List<eclogs>(); // or log the exception
            }
        }




        /*   public async Task<CommonResponse> GetAllECLogs(GetAllECLogsRequestEntity getAllECLogsRequestEntity)
           {
               var response = new CommonResponse();
               try
               {
                   var logsCollection = _database.GetCollection<eclogs>(_mongoSettings.LogsCollectionName);
                   var filterBuilder = Builders<eclogs>.Filter;
                   var filters = filterBuilder.Empty;

                   // Add individual filters
                   if (!string.IsNullOrEmpty(getAllECLogsRequestEntity.Requester))
                   {
                       var requesterFilter = filterBuilder.Eq(e => e.RequestFor, getAllECLogsRequestEntity.Requester);
                       filters &= requesterFilter;
                   }

                   if (getAllECLogsRequestEntity.StartDate.HasValue)
                   {
                       var startDateFilter = filterBuilder.Gte(e => e.Time, getAllECLogsRequestEntity.StartDate.Value);
                       filters &= startDateFilter;
                   }

                   if (getAllECLogsRequestEntity.EndDate.HasValue)
                   {
                       var adjustedEnd = getAllECLogsRequestEntity.EndDate.Value.AddHours(23).AddMinutes(59).AddSeconds(59);
                       var endDateFilter = filterBuilder.Lte(e => e.Time, adjustedEnd);
                       filters &= endDateFilter;
                   }

                   // Execute the query with the combined filter
                   var logs = await logsCollection.Find(filters).ToListAsync();

                   if (logs != null && logs.Any())
                   {
                       var dataObject = new
                       {
                           Logs = logs,
                       };

                       response.Data = dataObject;
                       response.IsSuccess = true;
                       response.StatusCode = "200";
                       response.Message = "Logs retrieved successfully.";
                   }
                   else
                   {
                       response.IsSuccess = false;
                       response.StatusCode = "404";
                       response.Message = "No logs found.";
                   }
               }
               catch (Exception ex)
               {
                   response.IsSuccess = false;
                   response.StatusCode = "500";
                   response.Message = $"An error occurred: {ex.Message}";
               }

               return response;
           }
   */



        //private readonly IMongoCollection<eclogs> _LogsCollectionName;

        //public ReportRepository(IOptions<MongoDBSettings> mongoDBSettings)
        //{
        //    var mongoClient = new MongoClient(mongoDBSettings.Value.ConnectionString);
        //    var mongoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
        //    _LogsCollectionName = mongoDatabase.GetCollection<eclogs>(mongoDBSettings.Value.LogsCollectionName);
        //}

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

        /* public async Task<List<eclogs>> GetAll(string? requestFor = null, DateTime? start = null, DateTime? end = null)
         {
             var filterBuilder = Builders<eclogs>.Filter;
             var filters = new List<FilterDefinition<eclogs>>();

             if (!string.IsNullOrEmpty(requestFor))
             {
                 filters.Add(filterBuilder.Eq(e => e.RequestFor, requestFor));
             }
             if (start.HasValue)
             {
                 filters.Add(filterBuilder.Gte(e => e.Time, start.Value));
             }
             if (end.HasValue)
             { 
                 var adjustedEnd = end.Value.AddHours(23).AddMinutes(59).AddSeconds(59);
                 filters.Add(filterBuilder.Lte(e => e.Time, adjustedEnd));
             }
             var combinedFilter = filters.Count > 0 ? filterBuilder.And(filters) : filterBuilder.Empty;

             return await _LogsCollectionName.Find(combinedFilter).ToListAsync();
         }*/

        //public async Task<CommonResponse> GetAllECLogs(GetAllECLogsRequestEntity getAllECLogsRequestEntity)
        //{
        //    var commonResponse = new CommonResponse();
        //    try
        //    {
        //        // Adjusted to match the property names in GetAllECLogsRequestEntity
        //        var ecLogs = _LogsCollectionName.
        //            getAllECLogsRequestEntity.Requester,  // Assuming 'requester' corresponds to 'RequestFor'
        //            getAllECLogsRequestEntity.StartDate,
        //            getAllECLogsRequestEntity.EndDate
        //        );

        //        if (ecLogs != null && ecLogs.Any())
        //        {
        //            // Assuming you have a method to convert ecLogs to a view model response
        //            commonResponse.data = ConvertToViewModel(ecLogs); // Replace with your actual conversion method
        //            commonResponse.IsSuccess = true;
        //        }
        //        else
        //        {
        //            commonResponse.IsSuccess = false;
        //            commonResponse.Message = "No logs found.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        commonResponse.IsSuccess = false;
        //        commonResponse.Message = "An error occurred while retrieving logs.";
        //        commonResponse.ErrorCode = "ERR_GET_LOGS"; // Replace with actual error code
        //                                                   // Optionally log the exception here
        //    }

        //    return commonResponse;
        //}


        //private List<EclogsViewModel> ConvertToViewModel(List<eclogs> ecLogs)
        //{
        //    // Conversion logic from ecLogs to your view model
        //    return ecLogs.Select(log => new YourViewModel
        //    {
        //        // Mapping properties
        //    }).ToList();
        //}





        /*     public async Task<ReportSummary> GetReportSummary(string? requestFor = null)
             {
                 var filterBuilder = Builders<eclogs>.Filter;
                 var filter = filterBuilder.Empty;

                 if (!string.IsNullOrEmpty(requestFor))
                 {
                     filter &= filterBuilder.Eq(e => e.RequestFor, requestFor);
                }

                    var aggregateResult = await _LogsCollectionName.Aggregate()
                     .Match(filter)
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
             }*/

        public async Task<ReportSummary> GetReportSummary(GetRepostSummaryRequestEntities getRepostSummaryRequestEntities)
        {
            try
            {
                var logsCollection = _database.GetCollection<eclogs>(_mongoSettings.LogsCollectionName);
                var filterBuilder = Builders<eclogs>.Filter;
                var filters = new List<FilterDefinition<eclogs>>();

               
                if (!string.IsNullOrEmpty(getRepostSummaryRequestEntities.Requester))
                {
                    filters.Add(filterBuilder.Eq(e => e.RequestFor, getRepostSummaryRequestEntities.Requester));
                }

             
                var combinedFilter = filters.Count > 0 ? filterBuilder.And(filters) : filterBuilder.Empty;

              
                var aggregateResult = await logsCollection.Aggregate()
                    .Match(combinedFilter)
                    .Group(e => e.RequestFor, g => new ReportDetail
                    {
                        RequestFor = g.Key,
                        Count = g.Count(),
                        Amount = g.Count() * 5, 
                        SuccessCount = g.Count(e => e.StatusCode == 200),
                        FailCount = g.Count(e => e.StatusCode != 200)
                    })
                    .ToListAsync();

                // Create the report summary
                return new ReportSummary
                {
                    Details = aggregateResult
                };
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                return new ReportSummary
                {
                    Details = new List<ReportDetail>() 
                };
            }
        }


        //public async Task<List<string>> GetUniqueRequestForValues()
        //{

        //    var uniqueRequestForValues = await _LogsCollectionName
        //        .Distinct<string>("RequestFor", Builders<eclogs>.Filter.Empty)
        //        .ToListAsync();

        //    return uniqueRequestForValues;
        //}



    }
}
