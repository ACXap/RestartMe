using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using RestartMe.Data;
using RestartMe.Test.ImpInterface;

namespace RestartMe.Test
{
    [TestFixture]
    public class RestartActionTest
    {
        private RestartAction _resetActionGoodLan;
        private RestartAction _resetActionBadLan;

        private string _fileLogTest = @"c:\Temp\logRestartTest.txt";

        [SetUp]
        public void Init()
        {
            DelLogFile();

            _resetActionGoodLan = new RestartAction(new SettingsRestartAction()
            {
                Check = new CheckLan(),
                Log = new LogFileTest(),
                Restart = new RestartCompTest(),
                Period = 1
            });

            _resetActionBadLan = new RestartAction(new SettingsRestartAction()
            {
                Check = new CheckLanBad(),
                Log = new LogFileTest(),
                Restart = new RestartCompTest(),
                Period = 1
            });
        }

        [Test]
        public void RestartAction_GoodLan()
        {
            _resetActionGoodLan.Start();

            Thread.Sleep(1000 * 2 * 60);

            var count = GetCountLines();

            Assert.IsTrue(count== 3);
        }

        [Test]
        public void RestartAction_BadLan()
        {
            _resetActionBadLan.Start();

            Thread.Sleep(1000 * 2 * 60);

            var count = GetCountLines();

            Assert.AreEqual(count, 7);
        }

        private int GetCountLines()
        {
            return File.ReadAllLines(_fileLogTest).Count();
        }

        private void DelLogFile()
        {
            if (File.Exists(_fileLogTest))
            {
                File.Delete(_fileLogTest);
            }
        }
    }
}