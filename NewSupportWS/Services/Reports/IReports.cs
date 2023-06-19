using NewSupportWS.Services.Reports.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewSupportWS.Services.Reports
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReports" in both code and config file together.
    [ServiceContract]
    public interface IReports
    {
        [OperationContract]
        NIDReportResponse NIDReport(RequestHeader requestHeader);
        [OperationContract]
        string NIDReportPDF(RequestHeader requestHeader);
        [OperationContract]
        List<NIDReportByOffice> NIDReportByOffice(RequestHeader requestHeader, int OfficeCode);
        [OperationContract]
        int RefrishNID(RequestHeader requestHeader);
    }
}
