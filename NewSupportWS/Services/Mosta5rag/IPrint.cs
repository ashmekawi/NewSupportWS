using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewSupportWS.Services.Mosta5rag
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPrint" in both code and config file together.
    [ServiceContract]
    public interface IPrint
    {
        [OperationContract]
         void PrintDOC();
    }
}
