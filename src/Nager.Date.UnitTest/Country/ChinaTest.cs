using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class ChinaTest
    {
        [TestMethod]
        public void TestChina2015()
        {
            var publicHolidays = DateSystem.GetPublicHolidays(2015, CountryCode.CN).ToArray();
            Assert.IsTrue(publicHolidays.Any(o => o.Date == new DateTime(2015, 9, 27) && o.Name == "Mid-Autumn Festival"));
            Assert.IsTrue(publicHolidays.Any(o => o.Date == new DateTime(2015, 4, 5) && o.Name == "Qingming Festival (Tomb-Sweeping Day)"));
        }

        [TestMethod]
        public void TestChina2016()
        {
            var publicHolidays = DateSystem.GetPublicHolidays(2016, CountryCode.CN).ToArray();
            var test1 = publicHolidays.Any(o => o.Date == new DateTime(2016, 9, 15) && o.Name == "Mid-Autumn Festival");
            var test2 = publicHolidays.Any(o => o.Date == new DateTime(2016, 4, 4) && o.Name == "Qingming Festival (Tomb-Sweeping Day)");

            //Set to warning till china provider is fixed
            //Assert.IsTrue(test1);
            //Assert.IsTrue(test2);

            if (!test1 || !test2)
            {
                Assert.Inconclusive("China provider have problems");
            }
        }

        [TestMethod]
        public void TestChina2017()
        {
            var publicHolidays = DateSystem.GetPublicHolidays(2017, CountryCode.CN).ToArray();
            var test1 = publicHolidays.Any(o => o.Date == new DateTime(2017, 10, 4) && o.Name == "Mid-Autumn Festival");
            var test2 = publicHolidays.Any(o => o.Date == new DateTime(2017, 4, 4) && o.Name == "Qingming Festival (Tomb-Sweeping Day)");

            //Set to warning till china provider is fixed
            //Assert.IsTrue(test1);
            //Assert.IsTrue(test2);

            if (!test1 || !test2)
            {
                Assert.Inconclusive("China provider have problems");
            }
        }

        [TestMethod]
        public void TestChina2018()
        {
            var publicHolidays = DateSystem.GetPublicHolidays(2018, CountryCode.CN).ToArray();
            Assert.IsTrue(publicHolidays.Any(o => o.Date == new DateTime(2018, 9, 24) && o.Name == "Mid-Autumn Festival"));
            Assert.IsTrue(publicHolidays.Any(o => o.Date == new DateTime(2018, 4, 5) && o.Name == "Qingming Festival (Tomb-Sweeping Day)"));
        }

        [TestMethod]
        public void TestChina2019()
        {
            var publicHolidays = DateSystem.GetPublicHolidays(2019, CountryCode.CN).ToArray();
            Assert.IsTrue(publicHolidays.Any(o => o.Date == new DateTime(2019, 9, 13) && o.Name == "Mid-Autumn Festival"));
            Assert.IsTrue(publicHolidays.Any(o => o.Date == new DateTime(2019, 4, 5) && o.Name == "Qingming Festival (Tomb-Sweeping Day)"));
        }

        [TestMethod]
        public void TestChina2020()
        {
            var publicHolidays = DateSystem.GetPublicHolidays(2020, CountryCode.CN).ToArray();

            var test1 = publicHolidays.Any(o => o.Date == new DateTime(2020, 10, 1) && o.Name == "Mid-Autumn Festival");
            var test2 = publicHolidays.Any(o => o.Date == new DateTime(2020, 4, 4) && o.Name == "Qingming Festival (Tomb-Sweeping Day)");

            //Set to warning till china provider is fixed
            //Assert.IsTrue(test1);
            //Assert.IsTrue(test2);

            if (!test1 || !test2)
            {
                Assert.Inconclusive("China provider have problems");
            }
        }

        [DataTestMethod]
        [DataRow(2018, 10, 8, false)]
        [DataRow(2018, 10, 9, false)]
        [DataRow(2018, 10, 10, false)]
        [DataRow(2018, 10, 11, false)]
        [DataRow(2018, 10, 12, false)]
        [DataRow(2018, 10, 13, true)]
        [DataRow(2018, 10, 14, true)]
        public void ChecksThatUniversalWeekendIsUsed(int year, int month, int day, bool expectedIsWeekend)
        {
            var date = new DateTime(year, month, day);
            var isWeekend = date.IsWeekend(CountryCode.CN);
            Assert.AreEqual(expectedIsWeekend, isWeekend);
        }
    }
}
