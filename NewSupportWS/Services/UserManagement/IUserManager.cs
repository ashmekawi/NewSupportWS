using NewSupportWS.Services.UserManagement.Model.Login;
using NewSupportWS.Services.UserManagement.Model.Privilege;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewSupportWS.Services.UserManagement
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserManager" in both code and config file together.
    [ServiceContract]
    public interface IUserManager
    {
        [OperationContract]
        LoginResponse login(LoginRequest request);
        [OperationContract]
        PrivilegeResponse Privilege(PrivilegeRequest request);
        [OperationContract]
        List<string> GetUserRoles(int UserID);
    }
}
