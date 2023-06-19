using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSupportWS.DBMan
{
    public class FUN
    {
        public DQContext db = new DQContext();
        public static int LoopData(string FullName, string FamilyName, string InsuranceNumber, string NationalId, string MotherName, string Governorate, string Zone
            , string Sector, string Gender, string haveData)
        {
            string str;
            if (FullName == "") { FullName = "لايوجد"; };
            str = "UPDATE [dbo].[InsuranceData] SET " +
          "  [FullName] = '" + FullName + "'" +
          " ,[FamilyName] = '" + FamilyName + "'" +
          " ,[InsuranceNumber] = '" + InsuranceNumber + "'" +
          " ,[NationalId] = '" + NationalId + "'" +
          " ,[MotherName] = '" + MotherName + "'" +
          " ,[Governorate] = '" + Governorate + "'" +
          " ,[Zone] = '" + Zone + "'" +
          " ,[Sector] = '" + Sector + "'" +
          " ,[Gender] = '" + Gender + "'" +
          " ,[HaveData] = '" + haveData + "'" +
          "   WHERE ID_NUMBER = '" + NationalId + "'";
            FUN x = new FUN();
            return x.db.Database.ExecuteSqlCommand(str);
        }
    }
}