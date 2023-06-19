using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSupportWS.Services.WhatsApp.Model
{
    public class Discussion
    {
        public int ID { get; set; }
        public int SessionStatus { get; set; }
        public string CustName { get; set; }
        public string LastMSG { get; set; }
    }
}