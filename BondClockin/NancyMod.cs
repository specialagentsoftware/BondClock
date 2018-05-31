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
            Get["/dump"] = _ =>
            {
                string ip = Request.UserHostAddress;
                RequestHeaders headerinfo = Request.Headers;
                return "HI, WebServer hosted by windows service here. <br> You can call me Rodarigo. <br> I see you are making the request from :: " + ip + "<br>" +
                "<ul>" +
                "<li>Accept- " + headerinfo.Accept + "</li>" +
                "<li>Accept Charset - " + headerinfo.AcceptCharset + "</li>" +
                "<li>Accept Encoding - " + headerinfo.AcceptEncoding + "</li>" +
                "<li>Accept Language - " + headerinfo.AcceptLanguage + "</li>" +
                "<li>Authorization - " + headerinfo.Authorization + "</li>" +
                "<li>Cache Control - " + headerinfo.CacheControl + "</li>" +
                "<li>Connection - " + headerinfo.Connection + "</li>" +
                "<li>Content Length - " + headerinfo.ContentLength + "</li>" +
                "<li>Content type - " + headerinfo.ContentType + "</li>" +
                "<li>Cookie - " + headerinfo.Cookie + "</li>" +
                "<li>Date - " + headerinfo.Date + "</li>" +
                "<li>Host - " + headerinfo.Host + "</li>" +
                "<li>If Match - " + headerinfo.IfMatch + "</li>" +
                "<li>If modified since - " + headerinfo.IfModifiedSince + "</li>" +
                "<li>If none match - " + headerinfo.IfNoneMatch + "</li>" +
                "<li>If range - " + headerinfo.IfRange + "</li>" +
                "<li>If unmodified since - " + headerinfo.IfUnmodifiedSince + "</li>" +
                "<li>Keys - " + headerinfo.Keys + "</li>" +
                "<li>Max forwards - " + headerinfo.MaxForwards + "</li>" +
                "<li>Referrer - " + headerinfo.Referrer + "</li>" +
                "<li>User Agent - " + headerinfo.UserAgent + "</li>" +
                "<li>Values- " + headerinfo.Values + "</li>" +
                "</ul>";
            };

            Get["/"] = _ =>
            {
                return View["game.sshtml"];
            };
        }
    }
}
