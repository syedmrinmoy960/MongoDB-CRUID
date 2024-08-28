using MongoDB_CRUID.Models;

namespace MongoDB_CRUID.Repositories.IRepository
{
    public interface IReportRepository
    {
        /* Task<List<eclogs>> GetAllAlleclogs (string? requestFor = null);*/
        Task<List<eclogs>> GetAll(string? requestFor = null, DateTime? start = null, DateTime? end = null);
        Task<ReportSummary> GetReportSummary(string? requestFor = null);
        Task<List<string>> GetUniqueRequestForValues();
        


    }
}
