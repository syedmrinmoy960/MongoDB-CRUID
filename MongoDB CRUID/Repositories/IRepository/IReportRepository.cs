using MongoDB_CRUID.Models;
using MongoDB_CRUID.Models.Entites.RequestEntites;
using MongoDB_CRUID.Models.Entites.ResponseEntities;

namespace MongoDB_CRUID.Repositories.IRepository
{
    public interface IReportRepository
    {
        /* Task<List<eclogs>> GetAllAlleclogs (string? requestFor = null);*/
        //Task<ReportSummary> GetReportSummary(string? requestFor = null);
        //Task<List<string>> GetUniqueRequestForValues();
        Task<List<eclogs>> GetAllECLogs(GetAllECLogsRequestEntity getAllECLogsRequestEntity);
        Task<ReportSummary> GetReportSummary(GetRepostSummaryRequestEntities getRepostSummaryRequestEntities);





    }
}
