using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewSupportWS.Services.Monitor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServerMonitor_80" in both code and config file together.
    [ServiceContract]
    public interface IServerMonitor_80
    {
        [OperationContract]
        CRA00ServerMonitor.MachineInfo ServerInfo();
    }
}
