using MongoDB_CRUID.Managers.IManager;
using MongoDB_CRUID.Models;
using MongoDB_CRUID.Repositories.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB_CRUID.Managers.Manager
{
    public class ReportManager : IReportsManager
    {
        private readonly IReportRepository _reportRepository;

        public ReportManager(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        /*public async Task<List<eclogs>> GetAllEclogs(string? requestFor = null)
        {
            return await _reportRepository.GetAllAlleclogs(requestFor);
        }*/

        public async Task<List<eclogs>> GetAll(string? requestFor = null, DateTime? start = null, DateTime? end = null)
        {
            return await _reportRepository.GetAll(requestFor, start, end);
        }



        public async Task<ReportSummary> GetReportSummary(string? requestFor = null)
        {
            return await _reportRepository.GetReportSummary(requestFor);
        }
        public async Task<List<string>> GetUniqueRequestForValues()
        {
            return await _reportRepository.GetUniqueRequestForValues();
        }
    }
}
