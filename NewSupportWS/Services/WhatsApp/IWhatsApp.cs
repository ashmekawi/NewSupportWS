using NewSupportWS.Services.WhatsApp.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewSupportWS.Services.WhatsApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWhatsApp" in both code and config file together.
    [ServiceContract]
    public interface IWhatsApp
    {
        [OperationContract]
        List<Complain> GetComplains();

        [OperationContract]
        string sendWhatsApp(string Mob, string Message);
        [OperationContract]
        string SendWhatsAppImage(WhatsAppImage image);
        [OperationContract]
        string SendWhatsAppImageReport(WhatsAppImage image);
        [OperationContract]
        int IsUserExsit(string Mob);
        [OperationContract]
        int AddUser(string CustName, string CustNID, string CustMob);
        [OperationContract]
        string sendWhatsAppMessage(string Mob, string Message);
        [OperationContract]
        string Response(int UserID, string response, int LastStep);
        [OperationContract]
        int GetStep(int UserID);

        [OperationContract]
        List<Discussion> Getdiscussion(string Mob);
        [OperationContract]
        List<Message> GetMessagesBySession(int SessionID);
    }
}
