using RestartMe.Data;
using RestartMe.Interface;
using System;
using System.Threading;
using System.Timers;

namespace RestartMe
{
    public class RestartAction
    {
        private readonly ILog _log;
        private readonly IRestart _restart;
        private readonly ICheckStatus _check;

        private readonly System.Timers.Timer _timer;
        private readonly int _periodCheck;
        private readonly int _countAttempts = 5;

        private readonly string _startTest = "Начало проверки";
        private readonly string _attempt = "Попытка номер:";
        private readonly string _restartComp = "Будет произведена перезагрузка";
        private readonly string _goodCheck = "Проверка успешна";

        public RestartAction(SettingsRestartAction settings)
        {
            _periodCheck = settings.Period;
            _log = settings.Log;
            _restart = settings.Restart;
            _check = settings.Check;

            _timer = new System.Timers.Timer() { AutoReset = true, Interval = _periodCheck * 1000 * 60 };
            _timer.Elapsed += TimerElapsed;
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            _log.AddLog(GetMessageLog(_startTest));

            var count = _countAttempts;

            while(count-- > 0)
            {
                _log.AddLog(GetMessageLog($"{_attempt} {_countAttempts - count} "));
                var check = _check.Check();

                if (check)
                {
                    _log.AddLog(GetMessageLog(_goodCheck));
                    return;
                }

                Thread.Sleep(5000);
            }

            if(count <= 0)
            {
                _log.AddLog(GetMessageLog(_restartComp));
                Stop();
                _restart.Restart();
            }
        }

        private string GetMessageLog(string message)
        {
            return $"{DateTime.Now};{message}";
        }
    }
}