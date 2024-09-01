namespace MongoDB_CRUID.Models.Entites.RequestEntites
{
    public class LineChartRequestEntities
    {
        public string Requester { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class LineChartData
    {
        public string Date { get; set; }



        //public string RequestFor { get; set; }
        public int Count { get; set; }
    }

}
