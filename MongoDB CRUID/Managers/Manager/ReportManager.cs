using MongoDB_CRUID.Managers.IManager;
using MongoDB_CRUID.Models;
using MongoDB_CRUID.Models.Entites.RequestEntites;
using MongoDB_CRUID.Models.Entites.ResponseEntities;
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


        /* public async Task<CommonResponse> GetAllECLogs(GetAllECLogsRequestEntity getAllECLogsRequestEntity)
         {
             var commonResponse = new CommonResponse();
             try
             {
                 var eclogs = await _reportRepository.GetAllECLogs(getAllECLogsRequestEntity);
                 // view model
                 // commonResponse.data = viewmodel response
             }
             catch (Exception ex)
             {
                 throw ex;
             }
             return commonResponse;
         }*/

        public async Task<CommonResponse> GetAllECLogs(GetAllECLogsRequestEntity getAllECLogsRequestEntity)
        {
            var commonResponse = new CommonResponse();
            try
            {
                var eclogs = await _reportRepository.GetAllECLogs(getAllECLogsRequestEntity);

                if (eclogs != null && eclogs.Any())
                {
                    commonResponse.Data = new { Logs = eclogs };
                    commonResponse.IsSuccess = true;
                    commonResponse.StatusCode = "200";
                    commonResponse.Message = "Logs retrieved successfully.";
                }
                else
                {
                    commonResponse.IsSuccess = false;
                    commonResponse.StatusCode = "404";
                    commonResponse.Message = "No logs found.";
                }
            }
            catch (Exception ex)
            {
                commonResponse.IsSuccess = false;
                commonResponse.StatusCode = "500";
                commonResponse.Message = $"An error occurred: {ex.Message}";
            }
            return commonResponse;
        }


        //public Task<CommonResponse> GetECLogs(GetAllECLogsRequestEntity getAllECLogsRequestEntity)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<CommonResponse> GetReportSummary(GetRepostSummaryRequestEntities getRepostSummaryRequestEntities)
        {
            var commonResponse = new CommonResponse();

            try
            {
                var report = await _reportRepository.GetReportSummary(getRepostSummaryRequestEntities);
                if (report != null && report.Details != null && report.Details.Any())
                {
                    commonResponse.Data = new { Logs = report };
                    commonResponse.IsSuccess = true;
                    commonResponse.StatusCode = "200";
                    commonResponse.Message = "Logs retrieved successfully.";
                }

                else
                {
                    commonResponse.IsSuccess = false;
                    commonResponse.StatusCode = "404";
                    commonResponse.Message = "No logs found.";
                }

            }

            catch (Exception ex) {

                commonResponse.IsSuccess = false;
                commonResponse.StatusCode = "500";
                commonResponse.Message = $"An error occurred: {ex.Message}";


            }
            return commonResponse;
           
        }
        /*public async Task<List<string>> GetUniqueRequestForValues()
        {
            return await _reportRepository.GetUniqueRequestForValues();
        }*/
    }
}
