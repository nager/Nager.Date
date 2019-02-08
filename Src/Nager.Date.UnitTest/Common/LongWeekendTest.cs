using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Nager.Date.UnitTest.Common
{
    [TestClass]
    public class LongWeekendTest
    {
        [TestMethod]
        public void LongWeekend()
        {
            var longWeekends = DateSystem.GetLongWeekend(2017, CountryCode.AT).ToArray();

            Assert.AreEqual(10, longWeekends.Length);
        }
    }
}
