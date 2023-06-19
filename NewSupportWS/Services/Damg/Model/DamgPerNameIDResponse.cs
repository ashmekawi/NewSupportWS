using NewSupportWS.Services.Damg.Model.PerNameID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSupportWS.Services.Damg.Model
{
    public class DamgPerNameIDResponse
    {
        public string cnt { get; set; }
        public string Done { get; set; }
        public int pernameid { get; set; }
        public int birth_date { get; set; }
        public int DamgCount { get; set; }
        public int DamgCountUserID { get; set; }
        public List<DamgData> DamgData { get; set; }
    }
}