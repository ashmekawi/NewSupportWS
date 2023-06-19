using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSupportWS.Services.COC.Model
{
    public class GetRequestResponse
    {
        public ResponseHeader Header { get; set; }
        public Request request { get; set; }
    }
}