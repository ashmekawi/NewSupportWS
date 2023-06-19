using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSupportWS.Services.COC.Model
{
    public class AproveRequestRequest
    {
		public RequestHeader header { get; set; }
		public string RequestID { get; set; }
		public string PersonID { get; set; }
		public string RequestType { get; set; }
		public string Type  {get; set;}
		public string CommercialName  {get; set;}
		public string CommercialNID  {get; set;}
		public string CompanyName  {get; set;}
		public string RegNum  {get; set;}
		public string Gov  {get; set;}
		public string Office  {get; set;}
		public string RegDate  {get; set;}
		public string LastRen  {get; set;}
		public string Address  {get; set;}
		public string City  {get; set;}
		public string Activity  {get; set;}
		public string COCDate  {get; set;}
		public string COCNum  {get; set;}
		public string CocNum0  {get; set;}
		public string Genreg_ID { get; set; }

	}
}