using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BondClockin
{
    class WebCheck
    {
        public bool makeCheck(string address)
        {
            //BondClockDataSetTableAdapters.WebStatusTableAdapter tableadapter = new BondClockDataSetTableAdapters.WebStatusTableAdapter();
            Slackwrapper slackwrapper = new Slackwrapper();
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                client.BaseAddress = new Uri(address);
                HttpResponseMessage response = client.GetAsync("").Result;
                response.EnsureSuccessStatusCode();
                string statuscode = response.StatusCode.ToString();
                string result = response.Content.ReadAsStringAsync().Result;

                if (statuscode == "OK")
                {
                    //tableadapter.Insert(address,DateTime.Now,"OK");

                    if (result.Contains("Maintenance"))
                    {
                        slackwrapper.sendslack(address + " is in Maintenance Mode " + Environment.NewLine);
                        //tableadapter.Insert(address, DateTime.Now, "Maintenance Mode");
                    }
                }
                else
                {
                    //tableadapter.Insert(address, DateTime.Now, "Not returning ok. Not in Maintenance");
                    slackwrapper.sendslack(address + " is not returning a 200 ok. " + Environment.NewLine);
                }
            }
            return true;
        }
    }
}
