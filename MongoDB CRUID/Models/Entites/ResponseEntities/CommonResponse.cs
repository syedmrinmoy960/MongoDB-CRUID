namespace MongoDB_CRUID.Models.Entites.ResponseEntities
{
    public class CommonResponse
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
       // public List<eclogs> Data { get; set; } = new List<eclogs>();
       public Object Data { get; set; }=new object();
        public bool IsSuccess { get; set; }



    }
}
