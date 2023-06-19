using NewSupportWS.DBMan;
using NewSupportWS.Services.Damg.Model.PerNameID;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserManager" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserManager.svc or UserManager.svc.cs at the Solution Explorer and start debugging.
    public class UserManager : IUserManager
    {
        SupportContext db = new SupportContext();
        public LoginResponse login(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            ResponseHeader responseHeader = new ResponseHeader();
            User user = new User();
            user = db.Database.SqlQuery<User>("SELECT * FROM [Support].[dbo].[User] where UserName='"+request.UserName +"' and Password = '"+ request.Password +"'").FirstOrDefault();
            if(user!= null)
            {
                response.User = user;

                responseHeader.ResponseCode = 200;
                responseHeader.ResponseMSG = "Sucess";

            }
            else
            {
                responseHeader.ResponseCode = 500;
                responseHeader.ResponseMSG = "User name Or Password is invaled";
            }
           

            response.responseHeader = responseHeader;

            return response;
        }
        public PrivilegeResponse Privilege(PrivilegeRequest request )
        {
            PrivilegeResponse response = new PrivilegeResponse();
            ResponseHeader header = new ResponseHeader();
            if (request.requestHeader.WSUN == "Administrator" && request.requestHeader.WSPWD == "P@ssw0rd")
            {  
                header.ResponseCode = 200;
                header.ResponseMSG = "Success";
                //string str = "select count(*) from privileges where ControlerName='"+request.ControlerName+"' and Action = '"+request.Action+"' and UserID = "+request.UserID+"";
                string str = "SELECT [dbo].[ISVLD]('" + request.ControlerName+"','"+request.Action+"',"+request.UserID+")";
                response.HasPrivilege=db.Database.SqlQuery<int>(str).FirstOrDefault();
            }
            else
            {
                header.ResponseCode = 201;
                header.ResponseMSG = "UserName Or Password is invaled";
            }
            response.Header = header;
            return response;
        }

        public List<string> GetUserRoles(int UserID)
        {
           return db.Database.SqlQuery<string>("SELECT Roles.RoleName FROM UserRoleMapping INNER JOIN Roles ON UserRoleMapping.RoleId = Roles.Id WHERE (UserRoleMapping.UserId = "+UserID+")").ToList();

        }
       
    }
}
