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
                return "HI, WebServer hosted by windows service here. <br> You can call me Rodarigo. <br> I see you are making the request from :: " + ip + "<br> :: User Agent ::<br> " + headerinfo.UserAgent;
                
            };
        }
    }
}
