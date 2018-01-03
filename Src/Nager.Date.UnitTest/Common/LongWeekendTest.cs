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
            var longWeekends = DateSystem.GetLongWeekend(CountryCode.AT, 2017).ToArray();

            Assert.AreEqual(10, longWeekends.Length);
        }
    }
}
