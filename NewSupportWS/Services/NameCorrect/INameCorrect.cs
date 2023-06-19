using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewSupportWS.Services.NameCorrect
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INameCorrect" in both code and config file together.
    [ServiceContract]
    public interface INameCorrect
    {
        [OperationContract]
        string GetName(int UserID);
        [OperationContract]
        string Correct(string Name1, string Name2, int UserID);
        [OperationContract]
        string Done(string Name1, string Name2, int UserID);
    }
}
