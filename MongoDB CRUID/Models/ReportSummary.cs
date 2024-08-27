
using System.Collections.Generic;

namespace MongoDB_CRUID.Models
{
    public class ReportSummary
    {
        public List<ReportDetail> Details { get; set; } = new List<ReportDetail>();
    }

    public class ReportDetail
    {
        public string RequestFor { get; set; }
        public int Count { get; set; }
        public int Amount { get; set; }
        public int SuccessCount { get; set; }
        public int FailCount { get; set; }
    }
}
