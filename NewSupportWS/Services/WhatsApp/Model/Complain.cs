using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSupportWS.Services.WhatsApp.Model
{
    public class Complain
    {
        public int ID { get; set; }
        public string Mob { get; set; }
        public string MSG { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}