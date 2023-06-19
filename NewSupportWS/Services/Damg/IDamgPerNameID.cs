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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDamgPerNameID" in both code and config file together.
    [ServiceContract]
    public interface IDamgPerNameID
    {
        [OperationContract]
        DamgPerNameIDResponse Response(string UserID);
        [OperationContract]
        List<Company> GetCompany(string CSO);
        [OperationContract]
        int DamgUpdateDone(string Done, int PerNameID, int Birth_Date);
        [OperationContract]
        List<MergedPerson> MergedPeople(string CSO);
        [OperationContract]

        int DamgDone(string From, string TO, int UserID, string pernameid, string FromPage);
    }
}
