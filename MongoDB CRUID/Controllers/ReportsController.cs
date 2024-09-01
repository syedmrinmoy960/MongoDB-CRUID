using Microsoft.AspNetCore.Mvc;
using MongoDB_CRUID.Managers.IManager;
using MongoDB_CRUID.Models;
using MongoDB_CRUID.Models.Entites.RequestEntites;

namespace MongoDB_CRUID.Controllers
{
    [Route("api")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsManager _reportsManager;

        public ReportsController(IReportsManager reportsManager)
        {
            _reportsManager = reportsManager;
        }


        [HttpPost]
        [Route("reports")]
        public async Task<IActionResult> GetAllEclogs(GetAllECLogsRequestEntity getAllECLogsRequestEntity)

        {

            var commonReponse = await _reportsManager.GetAllECLogs(getAllECLogsRequestEntity);
            return Ok(commonReponse);
        }


        [HttpPost]
        [Route("report-summary")]
        public async Task<IActionResult> GetReportSummary(GetRepostSummaryRequestEntities getRepostSummaryRequestEntities)
        {
            var commonResponse = await _reportsManager.GetReportSummary(getRepostSummaryRequestEntities);
            return Ok(commonResponse);
        }

        //[HttpGet]
        //[Route("unique-requestfor")]
        //public async Task<ActionResult<IEnumerable<string>>> GetUniqueRequestForValues()
        //{
        //    var uniqueRequestForValues = await _reportsManager.GetUniqueRequestForValues();
        //    return Ok(uniqueRequestForValues);
        //}
    }
}
