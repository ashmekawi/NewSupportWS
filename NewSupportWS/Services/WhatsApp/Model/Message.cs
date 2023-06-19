using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSupportWS.Services.WhatsApp.Model
{
    public class Message
    {
        public DateTime ResponseTime { get; set; }
        public string MsgBody { get; set; }
        public int SenderType { get; set; }
    }
}