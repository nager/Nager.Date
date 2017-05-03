using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.PublicHolidays;

namespace Nager.Date.UnitTest
{
    [TestClass]
    public class UnitTestCanada
    {
        [TestMethod]
        public void TestCanada()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.CA, 2017);

            var canadaProvider = new CanadaProvider();
            var counties = canadaProvider.GetCounties();

            foreach (var publicHoliday in publicHolidays)
            {
                if (publicHoliday.Counties == null)
                {
                    continue;
                }

                if (publicHoliday.Counties.Where(o => counties.Keys.Contains(o)).Count() != publicHoliday.Counties.Count())
                {
                    Assert.Fail("Unknown countie");
                }
            }
        }
    }
}
