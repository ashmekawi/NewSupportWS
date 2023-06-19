using NewSupportWS.DBMan;
using NewSupportWS.Services.COC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewSupportWS.Services.COC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "COC" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select COC.svc or COC.svc.cs at the Solution Explorer and start debugging.
    public class COC : ICOC
    {
        TradeChamber_ElectionContext db = new TradeChamber_ElectionContext();
        public GetRequestResponse GetRequest(GetRequestRequest request)
        {
            GetRequestResponse response = new GetRequestResponse();
            response.Header = new ResponseHeader();
            if (request.header.WSUN == "Administrator" && request.header.WSPWD == "P@ssw0rd")
            {
                string str = "SELECT top(1) *, convert(varchar,convert(date,[RegDate]),111) as regdate1  FROM [TradeChamber_Election].[dbo].[Request]  where gov = '" + request.Gov + "' and Confirmed = 0  and ID not in (select RequestID from ConfirmedRequest) order by ID";
                response.request = db.Database.SqlQuery<Request>(str).FirstOrDefault();
                if(response.request != null)
                {
                    response.Header.ResponseCode = 200;
                    response.Header.ResponseMSG = "Success";
                    return response;
                }
                else
                {
                    response.Header.ResponseCode = 201;
                    response.Header.ResponseMSG = "لايوجد طلبات للمراجعة";
                    return response;
                }
            }
            else
            {
                response.Header.ResponseCode = 400;
                response.Header.ResponseMSG = "User Is Invaled";
                return response;
            }
           
        }
        public int RejectRequest(RequestRejectRequest request)
        {
            if (request.header.WSUN == "Administrator" && request.header.WSPWD == "P@ssw0rd")
            {
                string str = "DECLARE	@return_value int EXEC	@return_value = [dbo].[UpdateRequest] @ID = "+request.RequestID+",@Reason = N'"+request.RejectReason+"' SELECT	'Return Value' = @return_value";
                int x = db.Database.SqlQuery<int>(str).FirstOrDefault();
                if (x == 1) 
                { 
                return 1;
                }
            }
            return 0;
        }



        public int AproveRequest(AproveRequestRequest request)
        {
            if (request.header.WSUN == "Administrator" && request.header.WSPWD == "P@ssw0rd")
            {
                string str = "EXEC	@return_value = [dbo].[AproveRequest]"+

       "@RequestID = "+request.RequestID+",                    "+
		"@PersonID = '"+request.PersonID + "',                 "+
		"@RequestType = '"+request.RequestType + "',              "+
		"@Type = '"+request.RequestID+"',                     "+
		"@CommercialName = '"+request.CommercialName + "',           "+
		"@CommercialNID = '"+request.CommercialNID + "',            "+
		"@CompanyName = '"+request.CompanyName + "',              "+
		"@RegNum = '"+request.RegNum + "',                   "+
		"@Gov = '"+request.Gov + "',                      "+
		"@Office = '"+request.Office + "',                   "+
		"@RegDate = '"+request.RegDate + "',                  "+
		"@LastRen = '"+request.LastRen + "',                  "+
		"@Address = '"+request.Address + "',                  "+
		"@City = '"+request.City + "',                     "+
		"@Activity = '"+request.Activity + "',                 "+
		"@COCDate = '"+request.COCDate + "',                  "+
		"@COCNum = '"+request.COCNum + "',                   "+
		
		"@CocNum0 = '"+request.CocNum0 + "',                  "+
		"@Genreg_ID = '"+request.Genreg_ID + "' ";
                
                
                
                
                
                int x = db.Database.SqlQuery<int>(str).FirstOrDefault();
                if (x == 1)
                {
                    return 1;
                }
            }
            return 0;
        }





        public List<LookUp> GetLookup(string TBLName)
        {
            List<LookUp> response = new List<LookUp>();
            string str = "";
            try
            {
                switch (TBLName)
                {
                    case "Gov":
                        str = "SELECT [ID] ,[Name] as Adesc  FROM [TradeChamber_Election].[dbo].[Gov]";
                        break;
                    case "Office":
                        str = "SELECT cast(Code as int) as [ID] ,[Name] as Adesc  FROM [TradeChamber_Election].[dbo].[Office]";
                        break;
                    default:
                        break;
                }
                response = db.Database.SqlQuery<LookUp>(str).ToList();
               
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
