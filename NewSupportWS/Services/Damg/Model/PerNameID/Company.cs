using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSupportWS.Services.Damg.Model.PerNameID
{
    public class Company
    {
        public int Office { get; set; }
        public int Reg          {get;set;}
        public int Date0        {get;set;}
        public string Name0        {get;set;}
        public string ADESC        {get;set;}
        public int FK_PERSONCSO {get;set;}
    }
}