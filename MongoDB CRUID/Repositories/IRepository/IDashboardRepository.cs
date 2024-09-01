using MongoDB_CRUID.Models.Entites.RequestEntites;
using MongoDB_CRUID.Models;

namespace MongoDB_CRUID.Repositories.IRepository
{
    public interface IDashboardRepository
    {
        Task<List<LineChartData>> GetLineChartData();
        Task<List<PieChartData>> GetPieChartData(PieChartRequestEntities request);
        Task<List<StockChartData>> GetStockChartData();
        Task<List<AreaChartData>> GetAreaChartData(int billAmountPerHit);
        Task<List<StatusPieChartData>> GetStatusPieChartData();
        Task<List<ApiHitCount>> GetApiHitCounts();
    }
}
