using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<IEnumerable<eclogs>>> GetAllEclogs()
        {
            var eclogs = await _reportsManager.GetAllEclogs();
            return Ok(eclogs);
        }

        [HttpGet]
        [Route("report-summary")]
        public async Task<ActionResult<ReportSummary>> GetReportSummary()
        {
            var reportSummary = await _reportsManager.GetReportSummary();
            return Ok(reportSummary);
        }


    }
}
