using Microsoft.AspNetCore.Mvc;
using MongoDB_CRUID.Managers.IManager;
using MongoDB_CRUID.Models;

namespace MongoDB_CRUID.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsManager _reportsManager;

        public ReportsController(IReportsManager reportsManager)
        {
            _reportsManager = reportsManager;
        }

        [HttpGet]
[Route("")]
public async Task<ActionResult<IEnumerable<eclogs>>> GetAllEclogs(
    [FromQuery] string? requestFor = null,
    [FromQuery] DateTime? start = null,
    [FromQuery] DateTime? end = null)
{
    var eclogs = await _reportsManager.GetAllEclogs(requestFor, start, end);
    return Ok(eclogs);
}


        [HttpGet]
        [Route("report-summary")]
        public async Task<ActionResult<ReportSummary>> GetReportSummary(
            [FromQuery] string? requestFor = null)
        {
            var reportSummary = await _reportsManager.GetReportSummary(requestFor);
            return Ok(reportSummary);
        }

        [HttpGet]
        [Route("unique-requestfor")]
        public async Task<ActionResult<IEnumerable<string>>> GetUniqueRequestForValues()
        {
            var uniqueRequestForValues = await _reportsManager.GetUniqueRequestForValues();
            return Ok(uniqueRequestForValues);
        }
    }
}
