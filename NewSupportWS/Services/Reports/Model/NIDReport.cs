using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSupportWS.Services.Reports.Model
{
    public class NIDReport
    {
        public int OfficeCode { get; set; }
        public string OfficeName { get; set; }
        public int cntall { get; set; }
        public int cnt { get; set; }
        public decimal p { get; set; }
        public string timestamp { get; set; }
        public int CountNull { get; set; }
        public int CountAll { get; set; }
    }
}