using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSupportWS.Services.UserManagement.Model.Privilege
{
    public class PrivilegeResponse
    {
        public ResponseHeader Header { get; set; }

        public int HasPrivilege { get; set; }
    }
}