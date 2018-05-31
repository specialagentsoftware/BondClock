using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BondClockin
{
    public class NancyMod : NancyModule

    {
        public Dictionary<String, String> ModelArray = new Dictionary<string, string>();

        public NancyMod()
        {
            Get["/dump"] = _ =>
            {
                string ip = Request.UserHostAddress;
                RequestHeaders headerinfo = Request.Headers;
                return "HI, WebServer hosted by windows service here. <br> You can call me Rodarigo. <br> I see you are making the request from :: " + ip + "<br> :: User Agent ::<br> " + headerinfo.UserAgent;
                
            };

            Get["/"] = _ =>
            {
                BondClockDataSetTableAdapters.WebStatusTableAdapter tableadapter = new BondClockDataSetTableAdapters.WebStatusTableAdapter();
                var WebStatus = tableadapter.GetData();
                
                foreach (DataRow row in WebStatus)
                {
                    ModelArray.Add("id",row["id"].ToString());
                    ModelArray.Add("ServerChecked",row["ServerChecked"].ToString());
                    ModelArray.Add("TimeChecked",row["TimeChecked"].ToString());
                    ModelArray.Add("Status",row["Status"].ToString());
                }
                return View["game.cshtml", ModelArray];
            };
        }
    }
}
