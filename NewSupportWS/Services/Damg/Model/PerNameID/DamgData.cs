using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSupportWS.Services.Damg.Model.PerNameID
{
    public class DamgData
    {
        public string CSO { get; set; }
        public string Name0 { get; set; }
        public string ID_Number { get; set; }
        public int? Sex { get; set; }
        public int? FK_POLICE_STATIFK { get; set; }
        public int? BIRTH_DATE { get; set; }
        public int? OLD_BIRTH_DATE { get; set; }
        public string OLD_ID_NUMBER { get; set; }
        public string ZName { get; set; }
    }
}