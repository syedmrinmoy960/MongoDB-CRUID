using MongoDB_CRUID.Models;

namespace MongoDB_CRUID.Managers.IManager
{
    public interface IReportsManager
    {
        Task<List<eclogs>> GetAllEclogs();
        Task<ReportSummary> GetReportSummary();

    }
}
