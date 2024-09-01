using MongoDB_CRUID.Managers.IManager;
using MongoDB_CRUID.Models.Entites.RequestEntites;
using MongoDB_CRUID.Models;
using MongoDB_CRUID.Repositories.IRepository;
using MongoDB_CRUID.Models.Entites.ResponseEntities;
using MongoDB_CRUID.Repositories.Repository;

namespace MongoDB_CRUID.Managers.Manager
{
    public class DashboardManager:IDashboardManager
    {

        private readonly IDashboardRepository _dashboardRepository;

        public DashboardManager(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<CommonResponse> GetLineChartData()
        {
            var commonResponse = new CommonResponse();
            try
            {
                var lineChartData = await _dashboardRepository.GetLineChartData();

                if (lineChartData != null && lineChartData.Any())
                {
                    commonResponse.Data = new { LineChart = lineChartData };
                    commonResponse.IsSuccess = true;
                    commonResponse.StatusCode = "200";
                    commonResponse.Message = "Line chart data retrieved successfully.";
                }
                else
                {
                    commonResponse.IsSuccess = false;
                    commonResponse.StatusCode = "404";
                    commonResponse.Message = "No data found for the line chart.";
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

        public async Task<CommonResponse> GetPieChartData(PieChartRequestEntities pieChartRequestEntities)
        {
            var commonResponse = new CommonResponse();
            var pieChartData = await _dashboardRepository.GetPieChartData(pieChartRequestEntities);

            if (pieChartData != null && pieChartData.Any())
            {
                commonResponse.Data = new { PieChart = pieChartData };
                commonResponse.IsSuccess = true;
                commonResponse.StatusCode = "200";
                commonResponse.Message = "Pie chart data retrieved successfully.";
            }
            else
            {
                commonResponse.IsSuccess = false;
                commonResponse.StatusCode = "404";
                commonResponse.Message = "No data found for the pie chart.";
            }

            return commonResponse;
        }


        public async Task<CommonResponse> GetStockChartData()
        {
            var commonResponse = new CommonResponse();
            var stockChartData = await _dashboardRepository.GetStockChartData();

            if (stockChartData != null && stockChartData.Any())
            {
                commonResponse.Data = new { StockChart = stockChartData };
                commonResponse.IsSuccess = true;
                commonResponse.StatusCode = "200";
                commonResponse.Message = "Stock chart data retrieved successfully.";
            }
            else
            {
                commonResponse.IsSuccess = false;
                commonResponse.StatusCode = "404";
                commonResponse.Message = "No data found for the stock chart.";
            }

            return commonResponse;
        }


        public async Task<CommonResponse> GetAreaChartData(AreaChartRequestEntities areaChartRequestEntities)
        {
            var commonResponse = new CommonResponse();
            var areaChartData = await _dashboardRepository.GetAreaChartData(areaChartRequestEntities.BillAmountPerHit);

            if (areaChartData != null && areaChartData.Any())
            {
                commonResponse.Data = new { AreaChart = areaChartData };
                commonResponse.IsSuccess = true;
                commonResponse.StatusCode = "200";
                commonResponse.Message = "Area chart data retrieved successfully.";
            }
            else
            {
                commonResponse.IsSuccess = false;
                commonResponse.StatusCode = "404";
                commonResponse.Message = "No data found for the area chart.";
            }

            return commonResponse;
        }

        public async Task<CommonResponse> GetStatusPieChartData()
        {
            var commonResponse = new CommonResponse();
            var pieChartData = await _dashboardRepository.GetStatusPieChartData();

            if (pieChartData != null)
            {
                commonResponse.Data = new { PieChart = pieChartData };
                commonResponse.IsSuccess = true;
                commonResponse.StatusCode = "200";
                commonResponse.Message = "Status pie chart data retrieved successfully.";
            }
            else
            {
                commonResponse.IsSuccess = false;
                commonResponse.StatusCode = "404";
                commonResponse.Message = "No data found for the status pie chart.";
            }

            return commonResponse;
        }



        public async Task<CommonResponse> GetApiHitCountsForBarChart()
        {
            var commonResponse = new CommonResponse();
            var apiHitCounts = await _dashboardRepository.GetApiHitCounts();

            if (apiHitCounts != null && apiHitCounts.Any())
            {
                commonResponse.Data = new { BarChart = apiHitCounts };
                commonResponse.IsSuccess = true;
                commonResponse.StatusCode = "200";
                commonResponse.Message = "API hit counts retrieved successfully for bar chart.";
            }
            else
            {
                commonResponse.IsSuccess = false;
                commonResponse.StatusCode = "404";
                commonResponse.Message = "No data found for the bar chart.";
            }

            return commonResponse;
        }




    }
}
