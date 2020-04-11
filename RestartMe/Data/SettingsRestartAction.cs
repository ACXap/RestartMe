using RestartMe.Interface;

namespace RestartMe.Data
{
    public class SettingsRestartAction
    {
        public ILog Log { get; set; }
        public IRestart Restart { get; set; }
        public ICheckStatus Check { get; set; }
        public int Period { get; set; }

    }
}