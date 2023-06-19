using NewSupportWS.CRA00ServerMonitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewSupportWS.Services.Monitor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServerMonitor_80" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServerMonitor_80.svc or ServerMonitor_80.svc.cs at the Solution Explorer and start debugging.
    public class ServerMonitor_80 : IServerMonitor_80
    {
        public MachineInfo ServerInfo()
        {
            CRA00ServerMonitor.MachineInfoClient client = new MachineInfoClient();
            return client.GetMachineInfo();

        }
    }
}
