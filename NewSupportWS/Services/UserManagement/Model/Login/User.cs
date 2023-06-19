using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace NewSupportWS.Services.UserManagement.Model.Login
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int Support { get; set; }
        public Boolean Admin { get; set; }
        [DataMember]
        public int Gov { get; set; }
    }
}