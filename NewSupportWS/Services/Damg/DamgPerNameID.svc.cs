using NewSupportWS.DBMan;
using NewSupportWS.Services.Damg.Model;
using NewSupportWS.Services.Damg.Model.PerNameID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewSupportWS.Services.Damg
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DamgPerNameID" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DamgPerNameID.svc or DamgPerNameID.svc.cs at the Solution Explorer and start debugging.
    public class DamgPerNameID : IDamgPerNameID
    {
        DQContext db = new DQContext();
        CRA00Context Cra00 = new CRA00Context();
        public DamgPerNameIDResponse Response(string UserID)
        {
            DamgPerNameIDResponse response = new DamgPerNameIDResponse();
            string str = "SELECT TOP 1 [pernameid],[birth_date] FROM [DQ].[dbo].[DuplicatePerNameID] where" +
                "(userid is null or userid='" + UserID + "') and done<>cnt or done>cnt";

            response = db.Database.SqlQuery<DamgPerNameIDResponse>(str).FirstOrDefault();
            string str1 = "update DuplicatePerNameID set userid" +
                "= '" + UserID + "' where [pernameid] = '" + response.pernameid + "' and [birth_date] = '" + response.birth_date + "'";
            db.Database.ExecuteSqlCommand(str1);
            string cntstr = "select cnt from DuplicatePerNameID where [pernameid]='" + response.pernameid + "' and BIRTH_DATE='" + response.birth_date + "'";
            response.cnt = db.Database.SqlQuery<int>(cntstr).FirstOrDefault().ToString();
            string DamgDonestr = "select done from DuplicatePerNameID where [pernameid]='" + response.pernameid + "' and BIRTH_DATE='" + response.birth_date + "'";
            response.Done = db.Database.SqlQuery<int>(DamgDonestr).FirstOrDefault().ToString();
            DamgDonestr = "select count(*) from DuplicatePerNameID where cnt<>done";
            response.DamgCount = db.Database.SqlQuery<int>(DamgDonestr).FirstOrDefault();
            DamgDonestr = "select count(*) from DuplicatePerNameID where cnt=done and UserID='" + UserID + "' and [DamgDone] > 0";
            response.DamgCountUserID = db.Database.SqlQuery<int>(DamgDonestr).FirstOrDefault();
            string DamgDatastr = "SELECT distinct cast(person.CSO as nvarchar) as cso , person.name0 ,person.ID_NUMBER,cast(person.sex as int ) as sex,cast(person.FK_POLICE_STATIFK as int ) as FK_POLICE_STATIFK,person.BIRTH_DATE,person.OLD_BIRTH_DATE,person.OLD_ID_NUMBER,person.Zname  FROM [DQ].[dbo].[DuplicateZname]" +
            " inner join cra00.dbo.PERSON on[DuplicateZname].cso = PERSON.cso" +
            " where[DuplicateZname].r = " + response.pernameid + " order by person.Zname,person.BIRTH_DATE--and[DuplicateZname].bith10 = " + response.birth_date + "";
            response.DamgData = db.Database.SqlQuery<DamgData>(DamgDatastr).ToList();



            return response;
        }

        public List<Company> GetCompany(string CSO)
        {
            List<Company> company = new List<Company>();
            string str = "SELECT COMPANY.OfficeCode as Office, COMPANY.REGISTRATION_NO as Reg, COMPANY_PERSON.DATE0, COMPANY_NAME.name0," +
                " ACTIVITY_TEXT.ADESC, COMPANY_PERSON.FK_PERSONCSO FROM COMPANY_PERSON" +
                " INNER JOIN COMPANY ON COMPANY_PERSON.FK_COMPANYCRA_NUM = COMPANY.CRA_NUM" +
                " LEFT OUTER JOIN COMPANY_NAME ON COMPANY.CRA_NUM = COMPANY_NAME.FK_COMPANYCRA_NUM" +
                " LEFT OUTER JOIN ACTIVITY_TEXT ON COMPANY.CRA_NUM = ACTIVITY_TEXT.FK_COMPANYCRA_NUM" +
                " WHERE(COMPANY_PERSON.FK_PERSONCSO = " + CSO + ")";
            company = Cra00.Database.SqlQuery<Company>(str).ToList();

            return company;
        }

        public int DamgUpdateDone(string Done, int PerNameID, int Birth_Date)
        {
            string str = "  update [DuplicatePerNameID] set" +
                " Done = '" + Done + "', nodamg=1," +
                "[TimeStamp]=getdate() " +
                "where [pernameid]='" + PerNameID + "' and BIRTH_DATE='" + Birth_Date + "'";
            return db.Database.ExecuteSqlCommand(str);

        }

        public List<MergedPerson> MergedPeople(string CSO)
        {
            List<MergedPerson> mergedPeople = new List<MergedPerson>();
            string str = "SELECT distinct  lg.CSO, lg.NAME0,lg.id_number   , lg.BIRTH_DATE, lg.FK_POLICE_STATIFK, lg.OLD_BIRTH_DATE, lg.OLD_BIRTH_DATE   " +
                " FROM PERSON_Marged pm inner join[CRA00LOG].dbo.[PERSONLog]  lg on" +
                " lg.CSO = pm.FromFK_PERSONCSO" +
                " where pm.ToFK_PERSONCSO ="+CSO;
            mergedPeople = Cra00.Database.SqlQuery<MergedPerson>(str).ToList();
            return mergedPeople;
        }


        public int DamgDone(string From, string TO, int UserID,string pernameid,string FromPage)
        {
            string str = "EXECUTE  [dbo].[SP_MargePerson_Batch]  " + From + " ," + TO + ",'" + UserID + "','"+FromPage+"'";
            Cra00.Database.ExecuteSqlCommand(str);
            string str1 = "  update [DuplicatePerNameID] set Done = done+1 ,[TimeStamp]=getdate(),[DamgDone]=1 where pernameid='" + pernameid + "'";
            db.Database.ExecuteSqlCommand(str1);
            return 1;
        }
    }
}
