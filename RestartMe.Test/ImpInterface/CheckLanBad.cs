using RestartMe.Interface;

namespace RestartMe.Test
{
    public class CheckLanBad: ICheckStatus
    {
        public bool Check()
        {       
            return false;
        }
    }
}