using System;
using Topshelf;

namespace RestartMe
{
    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>
            {
                var restart = new RestartAction(new Data.SettingsRestartAction()
                {
                    Check = new CheckLan(),
                    Log = new LogFile(),
                    Restart = new RestartCompCmd(),
                    Period = 10
                });

                x.Service<RestartAction>(s =>
                {
                    s.ConstructUsing(name => restart);
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());

                });

                x.RunAsLocalSystem();
                x.StartAutomatically();

                x.SetDescription("Restart your computer when there is no network");
                x.SetDisplayName("RestartMe");
                x.SetServiceName("RestartMe");

            });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }
    }
}