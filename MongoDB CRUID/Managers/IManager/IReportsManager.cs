using MongoDB_CRUID.Models;
using MongoDB_CRUID.Models.Entites.RequestEntites;
using MongoDB_CRUID.Models.Entites.ResponseEntities;

namespace MongoDB_CRUID.Managers.IManager
{
    public interface IReportsManager
    {
        //Task<List<eclogs>> GetAllEclogs(string? requestFor = null);
        Task<CommonResponse> GetAllECLogs(GetAllECLogsRequestEntity getAllECLogsRequestEntity);
        Task<CommonResponse> GetReportSummary(GetRepostSummaryRequestEntities getRepostSummaryRequestEntities);
        //Task<ReportSummary> GetReportSummary(string? requestFor = null);
        //Task<List<string>> GetUniqueRequestForValues();

    }
}
