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
    public partial class BondClockIn : ServiceBase
    {

        int SessionCheckTime = Convert.ToInt32(50);

        public BondClockIn()
        {
            InitializeComponent();
            this.CanHandleSessionChangeEvent = true;
        }

        protected override void OnStart(string[] args)
        {
            Slackwrapper slackwrapper = new Slackwrapper();
            slackwrapper.sendslack("Session Start " + DateTime.Now);
        }

        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {

            Slackwrapper slackwrapper = new Slackwrapper();

            switch (changeDescription.Reason)
            {
                case SessionChangeReason.SessionLogon:
                    slackwrapper.sendslack("Session Logon " + DateTime.Now + " for user " + Environment.UserName);
                    break;
                case SessionChangeReason.SessionLogoff:
                    slackwrapper.sendslack("Session Logoff " + DateTime.Now + " for user " + Environment.UserName);
                    break;
                case SessionChangeReason.SessionLock:
                    slackwrapper.sendslack("Session Locked " + DateTime.Now + " for user " + Environment.UserName);
                    break;
                case SessionChangeReason.SessionUnlock:
                    slackwrapper.sendslack("Session Unlocked " + DateTime.Now + " for user " + Environment.UserName);
                    break;
            }

            base.OnSessionChange(changeDescription);
        }


        protected override void OnStop()
        {
            Slackwrapper slackwrapper = new Slackwrapper();
            slackwrapper.sendslack("Service Stop " + DateTime.Now);
        }
    }
}
