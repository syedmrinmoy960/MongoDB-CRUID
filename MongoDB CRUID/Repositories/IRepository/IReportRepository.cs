using MongoDB_CRUID.Models;

namespace MongoDB_CRUID.Repositories.IRepository
{
    public interface IReportRepository
    {
        Task<List<eclogs>> GetAllAlleclogs ();
        Task<ReportSummary> GetReportSummary();


    }
}
