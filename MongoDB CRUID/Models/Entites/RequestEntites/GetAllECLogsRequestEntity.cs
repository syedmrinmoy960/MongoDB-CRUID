namespace MongoDB_CRUID.Models.Entites.RequestEntites
{
    public class GetAllECLogsRequestEntity
    {
        public DateTime? StartDate {  get; set; }
        public DateTime? EndDate { get; set; }
        public string? Requester { get; set; }
    }
}
