using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSupportWS.Services.Damg.Model
{
    public class DamgByNIDResponse
    {
        public string NID { get; set; }
        public NIDInquireService.NIDInquireResult InsuranceData { get; set; }
    }
}