using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSupportWS.Services.UserManagement.Model.Privilege
{
    public class PrivilegeRequest
    {
        public RequestHeader requestHeader { get; set; }
        public string ControlerName { get; set; }
        public string Action { get; set; }
        public int UserID { get; set; }
    }
}