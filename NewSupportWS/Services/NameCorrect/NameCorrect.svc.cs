using NewSupportWS.DBMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewSupportWS.Services.NameCorrect
{
    public class NameCorrect : INameCorrect
    {
        DQContext dq = new DQContext();
        CRA00Context cra00 = new CRA00Context();

        public string GetName(int UserID)
        {

            int id = dq.Database.SqlQuery<int>("SELECT TOP (1) [ID] FROM [DQ].[dbo].[NameCorrect]where Done = 0 and UserID = "+UserID+" or UserID is null").FirstOrDefault();
            dq.Database.ExecuteSqlCommand("update NameCorrect set UserID = "+UserID +" where ID = "+id+" ");
            return dq.Database.SqlQuery<string>("select Name from NameCorrect where id = "+id+" ").FirstOrDefault();
           
        }
        public string Correct(string Name1, string Name2, int UserID)
        {
            int id = dq.Database.SqlQuery<int>("SELECT TOP (1) [ID] FROM [DQ].[dbo].[NameCorrect]where Done = 0 and UserID = " + UserID + " and Name = '"+Name1+"'").FirstOrDefault();
            dq.Database.ExecuteSqlCommand("update NameCorrect set Done = 1 , Name2 = '"+Name2+ "' , CraTimeStamp = getdate() where id = "+id+"");
            string xx = "EXEC [dbo].[Aya_updateperson]@wrongName = '" + Name1 + "',@correctName = '" + Name2 + "',@userID = " + UserID + "";
            var x=  cra00.Database.ExecuteSqlCommand(xx);
            return "";
        }
        public string Done(string Name1, string Name2, int UserID)
        {
            int id = dq.Database.SqlQuery<int>("SELECT TOP (1) [ID] FROM [DQ].[dbo].[NameCorrect]where Done = 0 and UserID = " + UserID + " and Name = '" + Name1 + "'").FirstOrDefault();
            var x = dq.Database.ExecuteSqlCommand("update NameCorrect set Done = 1 , Name2 = '" + Name2 + "' , CraTimeStamp = getdate() where id = "+id+"");
            return x.ToString();
        }
    }
}
