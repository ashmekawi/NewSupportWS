using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSupportWS.Services.WhatsApp.Model
{
    public class Response
    {
        public int ID { get; set; }
        public int StepNum { get; set; }
        public int ResponseNum { get; set; }
        public string ResponseDesc { get; set; }
        public int NextStep { get; set; }

    }
}