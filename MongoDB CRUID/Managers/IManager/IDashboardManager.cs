using MongoDB_CRUID.Models.Entites.RequestEntites;
using MongoDB_CRUID.Models;
using MongoDB_CRUID.Models.Entites.ResponseEntities;

namespace MongoDB_CRUID.Managers.IManager
{
    public interface IDashboardManager
    {
        Task<CommonResponse> GetLineChartData();
        Task<CommonResponse> GetPieChartData(PieChartRequestEntities request);
        Task<CommonResponse> GetStockChartData();
        Task<CommonResponse> GetAreaChartData(AreaChartRequestEntities areaChartRequestEntities);
        Task<CommonResponse> GetStatusPieChartData();

        Task<CommonResponse> GetApiHitCountsForBarChart();
    }
}
