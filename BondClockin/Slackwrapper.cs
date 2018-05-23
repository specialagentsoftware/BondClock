using Slack.Webhooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BondClockin
{
    public class Slackwrapper
    {
        public bool sendslack (string message) {
            try
            {
                var slackClient = new SlackClient("https://hooks.slack.com/services/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");
                var slackMessage = new SlackMessage
                {
                    Text = message
                };
                slackClient.Post(slackMessage);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        
    }
}
