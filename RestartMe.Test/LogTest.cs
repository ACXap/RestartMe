using NUnit.Framework;
using RestartMe.Interface;
using System;
using System.IO;
using System.Linq;

namespace RestartMe.Test
{
    [TestFixture]
    public class LogTest
    {
        private ILog _log = new LogFile();
        private string _fileLog = @"c:\temp\logrestart.txt";

        [Test]
        public void AddLog_Good()
        {
            var guid = Guid.NewGuid();
            var date = DateTime.Now;
            var message = $"{date};{guid}";

            _log.AddLog(message);

            var file = File.Exists(_fileLog);
            var lines = File.ReadAllLines(_fileLog);
            var countGuid = lines.Count(x => x == message);

            Assert.IsTrue(file);
            Assert.AreEqual(countGuid, 1);
        }
    }
}