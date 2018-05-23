using Microsoft.Win32;
using Slack.Webhooks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BondClockin
{
    public partial class Service1 : ServiceBase
    {

        int SessionCheckTime = Convert.ToInt32(50);

        public Service1()
        {
            InitializeComponent();
            this.CanHandleSessionChangeEvent = true;
        }

        protected override void OnStart(string[] args)
        {
            var slackClient = new SlackClient("https://hooks.slack.com/services/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");
            var slackMessage = new SlackMessage
            {
                Text = "Service Started"
            };
            slackClient.Post(slackMessage);
        }

        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            switch (changeDescription.Reason)
            {
                case SessionChangeReason.SessionLogon:
                    Debug.WriteLine(changeDescription.SessionId + " logon");
                    break;
                case SessionChangeReason.SessionLogoff:
                    Debug.WriteLine(changeDescription.SessionId + " logoff");
                    break;
                case SessionChangeReason.SessionLock:
                    var slackClient = new SlackClient("https://hooks.slack.com/services/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");
                    var slackMessage = new SlackMessage
                    {
                        Text = "Session Locked"
                    };
                    slackClient.Post(slackMessage);
                    //Debug.WriteLine(changeDescription.SessionId + " lock");
                    break;
                case SessionChangeReason.SessionUnlock:
                    var slackClient1 = new SlackClient("https://hooks.slack.com/services/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");
                    var slackMessage1 = new SlackMessage
                    {
                        Text = "Session unlocked"
                    };
                    //Debug.WriteLine(changeDescription.SessionId + " unlock");
                    break;
            }

            base.OnSessionChange(changeDescription);
        }


        protected override void OnStop()
        {
            var slackClient = new SlackClient("https://hooks.slack.com/services/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");
            var slackMessage = new SlackMessage
            {
                Text = "Service Stopped"
            };
            slackClient.Post(slackMessage);
        }
    }
}
