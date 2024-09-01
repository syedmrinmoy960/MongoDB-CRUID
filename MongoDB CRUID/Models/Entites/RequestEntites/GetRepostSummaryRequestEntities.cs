namespace MongoDB_CRUID.Models.Entites.RequestEntites
{
    public class GetRepostSummaryRequestEntities
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Requester { get; set; }
    }
}
