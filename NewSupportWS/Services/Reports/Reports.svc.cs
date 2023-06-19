using CrystalDecisions.CrystalReports.Engine;
using NewSupportWS.DBMan;
using NewSupportWS.Services.Reports.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewSupportWS.Services.Reports
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Reports" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Reports.svc or Reports.svc.cs at the Solution Explorer and start debugging.
    public class Reports : IReports
    {
        DQContext db = new DQContext();
        CRA00Context CRA00DB = new CRA00Context();
        public NIDReportResponse NIDReport(RequestHeader requestHeader)
        {
            ResponseHeader responseHeader = new ResponseHeader();
            NIDReportResponse response = new NIDReportResponse();
            List<Model.NIDReport> report = new List<Model.NIDReport>();
           if (requestHeader.WSUN == "Admin" && requestHeader.WSPWD == "P@ssw0rd")
            {
                report = db.Database.SqlQuery<Model.NIDReport>("SELECT TOP 1000 [CODE] as OfficeCode,[n] as OfficeName,[cntall],[cnt],[p],cast(timestamp as nvarchar(17)) timestamp " +
                    ",(SELECT count(*) FROM [CRA00].[dbo].[PERSON] where  id_type not in (5,6) and ((NATIONALITY_TYPE<>2 and SUBSTRING(flag,5,1)<>'1' ) or (NATIONALITY_TYPE=2 and ID_NUMBER is null ))) as CountNull" +
                    ",(select count(*) from cra00.dbo.PERSON p where p.ID_TYPE not in (5, 6) and isnull(SilentPartner,0)= 0) as CountAll" +
                    " FROM[DQ].[dbo].[NIDReport] order by 1").ToList();
               // report = CRA00DB.Database.SqlQuery<Model.NIDReport>("select * from  Id_NumForAll order by 1").ToList();
                responseHeader.ResponseCode = 200;
                responseHeader.ResponseMSG = "Sucsess";
                response.Header = responseHeader;
                response.Report = report;
                return response;

            }

            responseHeader.ResponseCode = 500;
            responseHeader.ResponseMSG = "Header Is Invaled";
            response.Header = responseHeader;
            return response;
        }
        public string NIDReportPDF(RequestHeader requestHeader)
        {
            ResponseHeader responseHeader = new ResponseHeader();
            NIDReportResponse response = new NIDReportResponse();
            List<Model.NIDReport> report = new List<Model.NIDReport>();
            if (requestHeader.WSUN == "Admin" && requestHeader.WSPWD == "P@ssw0rd")
            {
                DataTable dt = new DataTable();
                report = db.Database.SqlQuery<Model.NIDReport>("SELECT TOP 1000 [CODE] as OfficeCode,[n] as OfficeName,[cntall],[cnt],[p],timestamp FROM [DQ].[dbo].[NIDReport] order by 1").ToList();
                dt = ToDataTable(report);
                ReportDocument rd = new ReportDocument();
                rd.Load("d:\\SupportReports\\NIDReport.rpt");
                rd.SetDataSource(dt);
                DateTime date = Convert.ToDateTime(dt.Rows[0]["timestamp"]);
                string filename = string.Format("{0:yyyy-MM-dd}", date);
                rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "d:\\SupportReports\\Reports\\" + filename+ ".pdf");

                byte[] filearr = File.ReadAllBytes(@"d:\SupportReports\Reports\" + filename + ".pdf");
                string RequestPDF = Convert.ToBase64String(filearr);
                rd.Dispose();
                return RequestPDF;

            }

            responseHeader.ResponseCode = 500;
            responseHeader.ResponseMSG = "Header Is Invaled";
            response.Header = responseHeader;
            return "";
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        public List<NIDReportByOffice> NIDReportByOffice(RequestHeader requestHeader,int OfficeCode)
        {
            List<NIDReportByOffice> report = new List<NIDReportByOffice>();
          
            if (requestHeader.WSUN == "Admin" && requestHeader.WSPWD == "P@ssw0rd")
            {
              
//                report = CRA00DB.Database.SqlQuery<NIDReportByOffice>("select  distinct top(1000) c.REGISTRATION_NO,c.DATE0,c.NUMBER0,P.CSO,p.NAME0,p.BIRTH_DATE,case g.CODE when 0 then 'غير معلوم' else g.ADESC end BirthGov " +
//                " from COMPANY c inner "+
//"join COMPANY_PERSON cp on c.CRA_NUM = cp.FK_COMPANYCRA_NUM "+


//"inner "+
//"join person p on p.cso = cp.FK_PERSONCSO "+
//"inner "+
//"join OFFICE o on o.CODE = c.OfficeCode "+
//"inner "+
//"join GOVERNORATE g on g.CODE = p.FK_POLICE_STATIFK "+


//"where p.ID_NUMBER is null and p.ID_TYPE not in (5, 6) and c.OfficeCode = "+OfficeCode+ " order by c.DATE0 desc").ToList();
            
                report = CRA00DB.Database.SqlQuery<NIDReportByOffice>("select * from Id_NumForOffice(" + OfficeCode+ ") order by DATE0 desc").ToList();
              
                return report;

            }

         
            return report;
        }

        public int RefrishNID(RequestHeader requestHeader)
        {
            if (requestHeader.WSUN == "Admin" && requestHeader.WSPWD == "P@ssw0rd")
            {
                db.Database.ExecuteSqlCommand("[dbo].[SP_NIDReport]");
            }
                return 1;
        }


    }
}
