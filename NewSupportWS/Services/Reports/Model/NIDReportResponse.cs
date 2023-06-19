using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSupportWS.Services.Reports.Model
{
    public class NIDReportResponse
    {
        public ResponseHeader Header { get; set; }
        public List<NIDReport> Report { get; set; }
    }
}