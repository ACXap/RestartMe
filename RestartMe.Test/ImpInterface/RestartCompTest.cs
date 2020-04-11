using RestartMe.Interface;
using System.Diagnostics;

namespace RestartMe.Test.ImpInterface
{
    class RestartCompTest : IRestart
    {
        public void Restart()
        {
            Debug.WriteLine("Restart Now");
        }
    }
}