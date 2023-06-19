using NewSupportWS.Services.COC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewSupportWS.Services.COC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICOC" in both code and config file together.
    [ServiceContract]
    public interface ICOC
    {
        [OperationContract]
        GetRequestResponse GetRequest(GetRequestRequest request);
        [OperationContract]
        int RejectRequest(RequestRejectRequest request);
        [OperationContract]
        int AproveRequest(AproveRequestRequest request);
        [OperationContract]
        List<LookUp> GetLookup(string TBLName);
    }
}
