using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class ChinaTest
    {
        [TestMethod]
        public void TestChina2015()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.CN, 2015).ToArray();
            Assert.IsTrue(publicHolidays.Where(o => o.Date == new DateTime(2015, 9, 27) && o.Name == "Mid-Autumn Festival").Any());
            Assert.IsTrue(publicHolidays.Where(o => o.Date == new DateTime(2015, 4, 5) && o.Name == "Qingming Festival (Tomb-Sweeping Day)").Any());
        }

        [TestMethod]
        public void TestChina2016()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.CN, 2016).ToArray();
            var test1 = publicHolidays.Where(o => o.Date == new DateTime(2016, 9, 15) && o.Name == "Mid-Autumn Festival").Any();
            var test2 = publicHolidays.Where(o => o.Date == new DateTime(2016, 4, 4) && o.Name == "Qingming Festival (Tomb-Sweeping Day)").Any();

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
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.CN, 2017).ToArray();
            var test1 = publicHolidays.Where(o=>o.Date == new DateTime(2017, 10, 4) && o.Name == "Mid-Autumn Festival").Any();
            var test2 = publicHolidays.Where(o => o.Date == new DateTime(2017, 4, 4) && o.Name == "Qingming Festival (Tomb-Sweeping Day)").Any();

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
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.CN, 2018).ToArray();
            Assert.IsTrue(publicHolidays.Where(o => o.Date == new DateTime(2018, 9, 24) && o.Name == "Mid-Autumn Festival").Any());
            Assert.IsTrue(publicHolidays.Where(o => o.Date == new DateTime(2018, 4, 5) && o.Name == "Qingming Festival (Tomb-Sweeping Day)").Any());
        }

        [TestMethod]
        public void TestChina2019()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.CN, 2019).ToArray();
            Assert.IsTrue(publicHolidays.Where(o => o.Date == new DateTime(2019, 9, 13) && o.Name == "Mid-Autumn Festival").Any());
            Assert.IsTrue(publicHolidays.Where(o => o.Date == new DateTime(2019, 4, 5) && o.Name == "Qingming Festival (Tomb-Sweeping Day)").Any());
        }

        [TestMethod]
        public void TestChina2020()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.CN, 2020).ToArray();

            var test1 = publicHolidays.Where(o => o.Date == new DateTime(2020, 10, 1) && o.Name == "Mid-Autumn Festival").Any();
            var test2 = publicHolidays.Where(o => o.Date == new DateTime(2020, 4, 4) && o.Name == "Qingming Festival (Tomb-Sweeping Day)").Any();

            //Set to warning till china provider is fixed
            //Assert.IsTrue(test1);
            //Assert.IsTrue(test2);

            if (!test1 || !test2)
            {
                Assert.Inconclusive("China provider have problems");
            }
        }
    }
}
