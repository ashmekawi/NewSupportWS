using NewSupportWS.DBMan;
using NewSupportWS.Services.Damg.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewSupportWS.Services.Damg
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DamgByNID" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DamgByNID.svc or DamgByNID.svc.cs at the Solution Explorer and start debugging.
    public class DamgByNID : IDamgByNID
    {
        DQContext db = new DQContext();
        CRA00Context Cra00 = new CRA00Context();
        public DamgByNIDResponse DamgNID(int UserID)
        {
            DamgByNIDResponse response = new DamgByNIDResponse();
            response.InsuranceData = new NIDInquireService.NIDInquireResult();
            string NID = db.Database.SqlQuery<string>("SELECT TOP 1 [id_number] FROM [DQ].[dbo].[PersonDuplicateIDNum] where (userid is null or userid='" + UserID + "') and done<>cnt or done>cnt").FirstOrDefault();
            db.Database.ExecuteSqlCommand("update PersonDuplicateIDNum set userid = '" + UserID + "' where id_number = '" + NID + "'  ");
            NIDInquireService.NIDInquireServiceClient nid = new NIDInquireService.NIDInquireServiceClient();
            NIDInquireService.NIDInquireRequest request = new NIDInquireService.NIDInquireRequest();
            request.NationalId = NID;
            response.NID = NID;
            response.InsuranceData = Cra00.Database.SqlQuery<NIDInquireService.NIDInquireResult>("select * from [InsuranceData] where [ID_NUMBER] = '" + NID + "'").FirstOrDefault();
            if (string.IsNullOrWhiteSpace(response.InsuranceData.FullName))
            {
                var xx = nid.NIDInquire(request);
                response.InsuranceData = xx.Result;
                if (xx.ResponseCode == 200)
                {
                    int s = FUN.LoopData(xx.Result.FullName, xx.Result.FamilyName, xx.Result.InsuranceNumber, xx.Result.NationalId, xx.Result.MotherName, xx.Result.Governorate,
                         xx.Result.Zone, xx.Result.Sector, xx.Result.Gender, "1");
                }
                else
                {
                    int s = FUN.LoopData("", "", "", NID, "", "",
                         "", "", "", "0");
                }
                return response;
            }
            return response;
        }
    }
}
