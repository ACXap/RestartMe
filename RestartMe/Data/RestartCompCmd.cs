using RestartMe.Interface;
using System.Diagnostics;

namespace RestartMe
{
    public class RestartCompCmd : IRestart
    {
        public void Restart()
        {
            Process.Start("shutdown", "/r /t 0 /f");
        }
    }
}