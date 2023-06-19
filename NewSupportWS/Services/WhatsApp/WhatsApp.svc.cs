using Microsoft.AspNet.SignalR.Client;
using NewSupportWS.DBMan;
using NewSupportWS.Services.WhatsApp.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewSupportWS.Services.WhatsApp
{

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WhatsApp" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WhatsApp.svc or WhatsApp.svc.cs at the Solution Explorer and start debugging.
    public class WhatsApp : IWhatsApp
    {
        DQContext db = new DQContext();
        ChatBot chatBot = new ChatBot();
        CRA00Context CRA = new CRA00Context();
        HubConnection _connection = new HubConnection("http://10.9.1.200/");
       
        public List<Complain> GetComplains()
        {
            List<Complain> complains = new List<Complain>();
            complains = db.Database.SqlQuery<Complain>("select * from Complain").ToList();
            return complains;
        }
        public string sendWhatsApp(string Mob, string Message)
        {
            var url = "https://api.ultramsg.com/instance49552/messages/chat";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("token", "xzy2rhkhx1gywtzd");
            request.AddParameter("to", Mob);
            request.AddParameter("body", Message);
            RestResponse response = client.Execute(request);
            var output = response.Content;
            return output;

        }
        public string SendWhatsAppImage(WhatsAppImage image)
        {
            try
            {
                var url = "https://api.ultramsg.com/instance49552/messages/image";
                var client = new RestClient(url);
                var request = new RestRequest(url, Method.Post);
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter("token", "xzy2rhkhx1gywtzd");
                request.AddParameter("to", "2" + image.Phone);
                request.AddParameter("image", image.Image);
                request.AddParameter("caption", image.Caption);
                RestResponse response = client.Execute(request);
                var output = response.Content;
                return output;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public string SendWhatsAppImageReport(WhatsAppImage image)
        {
            try
            {
                var url = "https://api.ultramsg.com/instance49552/messages/image";
                var client = new RestClient(url);
                var request = new RestRequest(url, Method.Post);
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter("token", "xzy2rhkhx1gywtzd");
                request.AddParameter("to", "120363135371500121@g.us");
                request.AddParameter("image", image.Image);
                request.AddParameter("caption", image.Caption);
                RestResponse response = client.Execute(request);
                var output = response.Content;
                return output;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public int IsUserExsit(string Mob)
        {
            int UserID = chatBot.Database.SqlQuery<int>("select isnull(id,0) from [Customers] where CustMob= '" + Mob + "' ").FirstOrDefault();
            if (UserID > 0)
            {
                return UserID;
            };
            return 0;
        }
        public int AddUser(string CustName, string CustNID, string CustMob)
        {
            return chatBot.Database.SqlQuery<int>("EXEC[dbo].[AddUser] @CustName = N'" + CustName + "',@CustNID = N'" + CustNID + "',@CustMob = N'" + CustMob + "'").FirstOrDefault();
        }
        public string sendWhatsAppMessage(string Mob, string Message)
        {
            var url = "https://api.ultramsg.com/instance49552/messages/chat";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("token", "xzy2rhkhx1gywtzd");
            request.AddParameter("to", Mob);
            request.AddParameter("body", Message);
            RestResponse response = client.Execute(request);
            var output = response.Content;
            return output;

        }
        public string Response(int UserID, string response, int LastStep)
        {
            IHubProxy _chatHub = _connection.CreateHubProxy("chat");
            //_chatHub.On("receiveMessage", msg => OnReceive("ghffgh"));
            _connection.Start().Wait();
            int sessionID = chatBot.Database.SqlQuery<int>(" exec [dbo].[VLDSession]@CusID = " + UserID).FirstOrDefault();
            chatBot.Database.ExecuteSqlCommand("EXECUTE  [dbo].[AddSessionDetails] " + sessionID + "," + LastStep + ",N'" + response + "'," + UserID + ",1");
            _chatHub.Invoke("sendMessage", sessionID);
            var output = "";
            if (response == "0")
            {
                chatBot.Database.ExecuteSqlCommand("  update [Conversations] set LastStepNum = 0 , LastMsgTime = getdate() where CustID = " + UserID + "");
                LastStep = 0;

            }
            if (LastStep == 0)
            {
                output = "ادخل رقم الخدم \n";
                List<Response> Responses = chatBot.Database.SqlQuery<Response>("SELECT * FROM [dbo].[GetStepResponse] (" + 1 + ")").ToList();
                foreach (var item in Responses)
                {
                    output = output + item.ResponseDesc + "\n";
                }
                chatBot.Database.ExecuteSqlCommand("  update [Conversations] set LastStepNum = 1 , LastMsgTime = getdate() where CustID = " + UserID + "");
                chatBot.Database.ExecuteSqlCommand("EXECUTE  [dbo].[AddSessionDetails] " + sessionID + "," + LastStep + ",N'" + output + "'," + UserID + ",0");
                _chatHub.Invoke("sendMessage", sessionID);
                
                return output;
            }
            if (LastStep == 1)
            {
                List<Response> LastStepResponses = chatBot.Database.SqlQuery<Response>("SELECT * FROM [dbo].[GetStepResponse] (" + LastStep + ")").ToList();
                Response IsVLD;
                try
                {
                    IsVLD = LastStepResponses.Find(a => a.ResponseNum == int.Parse(response));
                }
                catch (Exception)
                {

                    IsVLD = null;
                }
                if (IsVLD != null)
                {
                    int NextStep = chatBot.Database.SqlQuery<int>("SELECT[dbo].[GetNextStep](" + LastStep + ", " + int.Parse(response) + ")").FirstOrDefault();

                    List<Response> Responses = chatBot.Database.SqlQuery<Response>("SELECT * FROM [dbo].[GetStepResponse] (" + NextStep + ")").ToList();
                    foreach (var item in Responses)
                    {
                        output = output + item.ResponseDesc + "\n";
                        output = output + "0-للعودة للقائمة الرئيسية";
                    }
                    chatBot.Database.ExecuteSqlCommand("  update [Conversations] set LastStepNum = " + NextStep + " , LastMsgTime = getdate() where CustID = " + UserID + "");
                }
                else
                {
                    output = "اختيار خطأ \n";
                    List<Response> Responses = chatBot.Database.SqlQuery<Response>("SELECT * FROM [dbo].[GetStepResponse] (" + 1 + ")").ToList();
                    foreach (var item in Responses)
                    {
                        output = output + item.ResponseDesc + "\n";
                    }
                    //output = output + "0-للعودة للقائمة الرئيسية";
                    chatBot.Database.ExecuteSqlCommand("EXECUTE  [dbo].[AddSessionDetails] " + sessionID + "," + LastStep + ",'" + output + "'," + UserID + ",0");
                    _chatHub.Invoke("sendMessage", sessionID);
                    return output;
                }






            }
            if (LastStep == 2)
            {
                if(response.Length == 15)
                {
                    int VLDUCR = CRA.Database.SqlQuery<int>("select count (*) from Company where UCR = '"+ response +"'").FirstOrDefault();
                    if (VLDUCR == 0)
                    {
                        output = chatBot.Database.SqlQuery<string>("SELECT [OutPut]  FROM [WhatsApp].[dbo].[OutPut] where ID = 201").FirstOrDefault()+System.Environment.NewLine;
                        List<Response> Responses = chatBot.Database.SqlQuery<Response>("SELECT * FROM [dbo].[GetStepResponse] (" + 2 + ")").ToList();
                        foreach (var item in Responses)
                        {
                            output = output + item.ResponseDesc + "\n";
                        }
                        chatBot.Database.ExecuteSqlCommand("EXECUTE  [dbo].[AddSessionDetails] " + sessionID + "," + LastStep + ",'" + output + "'," + UserID + ",0");
                        _chatHub.Invoke("sendMessage", sessionID);
                        return output;
                    }
                    int NextStep = chatBot.Database.SqlQuery<int>("SELECT[dbo].[GetNextStep](" + LastStep + ", " + 0 + ")").FirstOrDefault();
                    chatBot.Database.ExecuteSqlCommand("INSERT INTO [dbo].[SessionUCR]([SessionID],[UCR])"+
                        "VALUES ("+sessionID+" ,"+ response + ")");
                    output = GetStep2Response(response);
                    if (output == "")
                    {
                        output = chatBot.Database.SqlQuery<string>("SELECT [OutPut]  FROM [WhatsApp].[dbo].[OutPut] where ID = 202").FirstOrDefault() + System.Environment.NewLine;
                        List<Response> Responses = chatBot.Database.SqlQuery<Response>("SELECT * FROM [dbo].[GetStepResponse] (" + 2 + ")").ToList();
                        foreach (var item in Responses)
                        {
                            output = output + item.ResponseDesc + "\n";
                        }
                        chatBot.Database.ExecuteSqlCommand("EXECUTE  [dbo].[AddSessionDetails] " + sessionID + "," + LastStep + ",'" + output + "'," + UserID + ",0");
                        _chatHub.Invoke("sendMessage", sessionID);
                        chatBot.Database.ExecuteSqlCommand("  update [Conversations] set LastStepNum = " + 2 + " , LastMsgTime = getdate() where CustID = " + UserID + "");
                        return output;
                    }
                    chatBot.Database.ExecuteSqlCommand("EXECUTE  [dbo].[AddSessionDetails] " + sessionID + "," + LastStep + ",'" + output + "'," + UserID + ",0");
                    _chatHub.Invoke("sendMessage", sessionID);
                    chatBot.Database.ExecuteSqlCommand("  update [Conversations] set LastStepNum = " + NextStep + " , LastMsgTime = getdate() where CustID = " + UserID + "");
                    return output;
                }
                if (response.Length != 15)
                {
                    output = "الرقم الموحد خطأ" + "\n";
                    List<Response> Responses = chatBot.Database.SqlQuery<Response>("SELECT * FROM [dbo].[GetStepResponse] (" + 1 + ")").ToList();
                    foreach (var item in Responses)
                    {
                        output = output + item.ResponseDesc + "\n";
                    }
                    chatBot.Database.ExecuteSqlCommand("EXECUTE  [dbo].[AddSessionDetails] " + sessionID + "," + LastStep + ",'" + output + "'," + UserID + ",0");
                    _chatHub.Invoke("sendMessage", sessionID);
                    return output;
                }
            }
            if(LastStep == 6)
            {
                output= GetStep6Response(UserID, response, LastStep);
                chatBot.Database.ExecuteSqlCommand("EXECUTE  [dbo].[AddSessionDetails] " + sessionID + "," + LastStep + ",'" + output + "'," + UserID + ",0");
                _chatHub.Invoke("sendMessage", sessionID);
                return output;
            }

            chatBot.Database.ExecuteSqlCommand("EXECUTE  [dbo].[AddSessionDetails] " + sessionID + "," + LastStep + ",'" + output + "'," + UserID + ",0");
            _chatHub.Invoke("sendMessage", sessionID);
            return output;

        }
        public int GetStep(int UserID)
        {
            chatBot.Database.ExecuteSqlCommand(" exec [dbo].[VLDSession]@CusID = " + UserID);
            int LastStep = chatBot.Database.SqlQuery<int>("SELECT [dbo].[GetLastStep] ('" + UserID + "')").FirstOrDefault();
            return LastStep;
        }
        public List<Discussion> Getdiscussion(string Mob)
        {
            int UserID = chatBot.Database.SqlQuery<int>("SELECT  [ID]  FROM [WhatsApp].[dbo].[Customers]  where CustMob=" + Mob).FirstOrDefault();
            string xx = "SELECT  Sessions.ID, Sessions.CustID, Sessions.SessionStatus, Customers.CustName FROM Sessions INNER JOIN Customers ON Sessions.CustID = Customers.ID WHERE (Sessions.CustID = '" + UserID + "') order by Sessions.ID desc ";
            List<Discussion> discussions = chatBot.Database.SqlQuery<Discussion>(xx).ToList();
            List<Discussion> discussions1 = new List<Discussion>();
            foreach (var item in discussions)
            {
                Discussion discussion = new Discussion();
                discussion.CustName = item.CustName;
                discussion.ID = item.ID;
                discussion.SessionStatus = item.SessionStatus;
                discussion.LastMSG = chatBot.Database.SqlQuery<string>("SELECT [MsgBody] FROM [WhatsApp].[dbo].[SessionDetails] where SessionID = " + item.ID + "  order by id desc").FirstOrDefault();
                discussions1.Add(discussion);
            }
            return discussions1;
        }
        public List<Message> GetMessagesBySession(int SessionID)
        {
            List<Message> messages = chatBot.Database.SqlQuery<Message>("SELECT [ResponseTime],[MsgBody],[SenderType] FROM [WhatsApp].[dbo].[SessionDetails] where SessionID =" + SessionID + "  order by id").ToList();

            return messages;
        }
        public string GetStep2Response(string UCR)
        {
            List<Person> people = new List<Person>();
            string xx = "";
            people = db.Database.SqlQuery<Person>("[dbo].[SP_UpdateService] " + UCR + "").ToList();
            //people = db.Database.SqlQuery<Person111>("[dbo].[SP_UpdateService] 100100000094463").ToList();
            foreach (var Person in people)
            {
                xx = xx + Person.RowNum.ToString() + "--" + Person.Name0 + System.Environment.NewLine;
            }
           return xx;
        }


        public string GetStep6Response(int UserID, string response, int LastStep)
        {

           
            int sessionID = chatBot.Database.SqlQuery<int>(" exec [dbo].[VLDSession]@CusID = " + UserID).FirstOrDefault();
            string output = "تحت الانشاء";
          
            return output;
        }



    }
}
