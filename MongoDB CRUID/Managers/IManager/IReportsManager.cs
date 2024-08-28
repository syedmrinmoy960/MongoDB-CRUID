using MongoDB_CRUID.Models;

namespace MongoDB_CRUID.Managers.IManager
{
    public interface IReportsManager
    {
        //Task<List<eclogs>> GetAllEclogs(string? requestFor = null);
        Task<List<eclogs>> GetAll(string? requestFor = null, DateTime? start = null, DateTime? end = null);
        Task<ReportSummary> GetReportSummary(string? requestFor = null);
        Task<List<string>> GetUniqueRequestForValues();

    }
}
