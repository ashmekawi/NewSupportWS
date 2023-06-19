using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSupportWS.Services.UserManagement.Model.Login
{
    public class LoginRequest
    {
        public RequestHeader requestHeader { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}