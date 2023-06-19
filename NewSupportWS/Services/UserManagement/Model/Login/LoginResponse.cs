using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSupportWS.Services.UserManagement.Model.Login
{
    public class LoginResponse
    {
        public ResponseHeader responseHeader     { get; set; }
        public User User  { get; set; }
    }
}