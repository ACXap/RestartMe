using NUnit.Framework;
using RestartMe.Interface;

namespace RestartMe.Test
{
    [TestFixture]
    public class CheckLanTest
    {
        private ICheckStatus _check = new CheckLan();
        private ICheckStatus _checkBadLan = new CheckLanBad();

        [Test]
        public void CheckLan_Good()
        {
            var check = _check.Check();

            Assert.IsTrue(check);
        }

        [Test]
        public void CheckLan_Bad()
        {
            var check = _checkBadLan.Check();

            Assert.IsFalse(check);
        }

    }
}