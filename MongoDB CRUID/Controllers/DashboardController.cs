using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB_CRUID.Managers.IManager;
using MongoDB_CRUID.Managers.Manager;
using MongoDB_CRUID.Models.Entites.RequestEntites;

namespace MongoDB_CRUID.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardManager _dashboardManager;

        public DashboardController(IDashboardManager dashboardManager)
        {
           _dashboardManager = dashboardManager;
        }

        [HttpPost]
        [Route("linechart")]
        public async Task<IActionResult> LineChart()
        {
            var commonResponse = await _dashboardManager.GetLineChartData();
            return Ok(commonResponse);
        }

        [HttpPost]
        [Route("piechart")]
        public async Task<IActionResult> PieChart(PieChartRequestEntities pieChartRequestEntities)
        {
            var commonResponse = await _dashboardManager.GetPieChartData(pieChartRequestEntities);
            return Ok(commonResponse);
        }


        [HttpPost]
        [Route("stockchart")]
        public async Task<IActionResult> StockChart()
        {
            var commonResponse = await _dashboardManager.GetStockChartData();
            return Ok(commonResponse);
        }

        [HttpPost]
        [Route("areachart")]
        public async Task<IActionResult> AreaChart(AreaChartRequestEntities areaChartRequestEntities)
        {
            var commonResponse = await _dashboardManager.GetAreaChartData(areaChartRequestEntities);
            return Ok(commonResponse);
        }

        [HttpPost]
        [Route("status-piechart")]
        public async Task<IActionResult> StatusPieChart()
        {
            var commonResponse = await _dashboardManager.GetStatusPieChartData();
            return Ok(commonResponse);
        }

        [HttpPost]
        [Route("bar-chart")]
        public async Task<IActionResult> GetApiHitBarChart()
        {
            var commonResponse = await _dashboardManager.GetApiHitCountsForBarChart();
            return Ok(commonResponse);
        }


    }
}
