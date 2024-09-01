namespace MongoDB_CRUID.Models.Entites.RequestEntites
{
    public class PieChartRequestEntities
    {
        public string? RequestFor { get; set; }
    }

    public class PieChartData
    {
        public string RequestFor { get; set; }
        public int Count { get; set; }
    }

}
