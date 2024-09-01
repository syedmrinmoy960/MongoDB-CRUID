namespace MongoDB_CRUID.Models.Entites.RequestEntites
{
    public class AreaChartRequestEntities
    {
        public int BillAmountPerHit { get; set; }
    }

    public class AreaChartData
    {
        public string Month { get; set; }
        public int TotalHits { get; set; }
        public int TotalBill { get; set; }
    }
}
