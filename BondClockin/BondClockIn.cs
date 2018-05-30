using Nancy.Hosting.Self;
using System;
using System.ServiceProcess;

namespace BondClockin
{
    public partial class BondClockIn : ServiceBase
    {
        NancyHost host = new NancyHost(new Uri("http://localhost:8888"));
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

            host.Start();

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 500;//180000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            WebCheck check = new WebCheck();
            try
            {
                check.makeCheck("https://www.trollandtoad.com");
            }
            catch(Exception ex)
            {
                throw ex;
            }

            if (Environment.MachineName.Contains("trollandtoad.local"))
            {
                try
                {
                    check.makeCheck("https://service.trollandtoad.com");
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
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
            host.Stop();
        }
    }
}
