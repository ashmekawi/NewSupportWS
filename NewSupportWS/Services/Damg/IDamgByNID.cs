using NewSupportWS.Services.Damg.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewSupportWS.Services.Damg
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDamgByNID" in both code and config file together.
    [ServiceContract]
    public interface IDamgByNID
    {
        [OperationContract]
       
        
        DamgByNIDResponse DamgNID(int UserID);
    }
}
