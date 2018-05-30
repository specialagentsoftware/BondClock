using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BondClockin
{
    public class NancyMod : NancyModule

    {
        public NancyMod()
        {
            Get["/"] = _ =>
            {
                string ip = Request.UserHostAddress;
                RequestHeaders headerinfo = Request.Headers;
                return "HI, WebServer hosted by windows service here." + Environment.NewLine + "You can call me Rodarigo." + Environment.NewLine + "I see you are making the request from :: " + ip + Environment.NewLine + " :: Header as follows :: " + headerinfo.UserAgent;
                
            };
        }
    }
}
