using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSupportWS.Services.COC.Model
{
    public class RequestRejectRequest
    {
        public RequestHeader header { get; set; }
        public int RequestID { get; set; }
        public string RejectReason { get; set; }

    }
}