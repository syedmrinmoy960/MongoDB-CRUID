using MongoDB_CRUID.Managers.IManager;
using MongoDB_CRUID.Models;
using MongoDB_CRUID.Repositories.IRepository;
using MongoDB_CRUID.Repositories.Repository;

namespace MongoDB_CRUID.Managers.Manager
{
    public class ReportManager : IReportsManager
    {
        private readonly IReportRepository _reportRepository;

        public ReportManager(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public async Task<List<eclogs>> GetAllEclogs()
        {
            return (List<eclogs>)await _reportRepository.GetAllAlleclogs();
        }

        public async Task<ReportSummary> GetReportSummary()
        {
            return await _reportRepository.GetReportSummary();
        }


    }   
}
