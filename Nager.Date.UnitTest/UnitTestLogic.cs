using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Enum;
using Nager.Date.Utils;

namespace Nager.Date.UnitTest
{
    [TestClass]
    public class UnitTestLogic
    {
        [TestMethod]
        public void CheckEasterSunday()
        {
            var easterSunday = DateSystem.EasterSunday(1900);
            Assert.AreEqual(new DateTime(1900, 4, 15), easterSunday);

            easterSunday = DateSystem.EasterSunday(2014);
            Assert.AreEqual(new DateTime(2014, 4, 20), easterSunday);

            easterSunday = DateSystem.EasterSunday(2015);
            Assert.AreEqual(new DateTime(2015, 4, 5), easterSunday);

            easterSunday = DateSystem.EasterSunday(2016);
            Assert.AreEqual(new DateTime(2016, 3, 27), easterSunday);

            easterSunday = DateSystem.EasterSunday(2017);
            Assert.AreEqual(new DateTime(2017, 4, 16), easterSunday);

            easterSunday = DateSystem.EasterSunday(2018);
            Assert.AreEqual(new DateTime(2018, 4, 1), easterSunday);

            easterSunday = DateSystem.EasterSunday(2019);
            Assert.AreEqual(new DateTime(2019, 4, 21), easterSunday);

            easterSunday = DateSystem.EasterSunday(2020);
            Assert.AreEqual(new DateTime(2020, 4, 12), easterSunday);

            easterSunday = DateSystem.EasterSunday(2200);
            Assert.AreEqual(new DateTime(2200, 4, 6), easterSunday);
        }

        [TestMethod]
        public void CheckIsPublicHoliday()
        {
            var isPublicHoliday = DateSystem.IsPublicHoliday(new DateTime(2016, 5, 1), "AT");
            Assert.AreEqual(true, isPublicHoliday);

            isPublicHoliday = DateSystem.IsPublicHoliday(new DateTime(2016, 1, 6), "AT");
            Assert.AreEqual(true, isPublicHoliday);
        }

        #region County CH-NE

        [TestMethod]
        public void CheckIsOfficialPublicHolidayByCounty_01032016_ReturnsTrueForNE()
        {
            var isPublicHoliday = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2016, 3, 1), "CH", EChCounty.NE.GetDescription());
            Assert.AreEqual(true, isPublicHoliday);
        }

        [TestMethod]
        public void CheckIsOfficialPublicHolidayByCounty_02032016_ReturnsFalseForNE()
        {
            var isPublicHoliday = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2016, 3, 2), "CH", EChCounty.NE.GetDescription());
            Assert.AreEqual(false, isPublicHoliday);
        }

        [TestMethod]
        public void CheckIsOfficialPublicHolidayByCounty_26122016_ReturnsTrueForNEOfficialHoliday()
        {
            var isPublicHoliday = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2016, 12, 26), "CH", EChCounty.NE.GetDescription());
            Assert.AreEqual(true, isPublicHoliday);
        }

        [TestMethod]
        public void CheckIsOfficialPublicHolidayByCounty_26122017_ReturnsFalseForNEOfficialHoliday()
        {
            var isPublicHoliday = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2017, 12, 26), "CH", EChCounty.NE.GetDescription());
            Assert.AreEqual(false, isPublicHoliday);
        }

        [TestMethod]
        public void CheckIsOfficialPublicHolidayByCounty_02012016_ReturnsTrueForNEOfficialHoliday()
        {
            var isPublicHoliday = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2016, 01, 02), "CH", EChCounty.NE.GetDescription());
            Assert.AreEqual(true, isPublicHoliday);
        }

        [TestMethod]
        public void CheckIsOfficialPublicHolidayByCounty_02012017_ReturnsFalseForNEOfficialHoliday()
        {
            var isPublicHoliday = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2017, 01, 02), "CH", EChCounty.NE.GetDescription());
            Assert.AreEqual(false, isPublicHoliday);
        }

        [TestMethod]
        public void CheckIsAdministrationPublicHolidayByCounty_24122016_ReturnsTrueForNEOfficialHoliday()
        {
            var isPublicHoliday = DateSystem.IsAdministrationPublicHolidayByCounty(new DateTime(2016, 12, 24), "CH", EChCounty.NE.GetDescription());
            Assert.AreEqual(true, isPublicHoliday);
        }

        [TestMethod]
        public void CheckIsAdministrationPublicHolidayByCounty_23122016_ReturnsFalseForNEOfficialHoliday()
        {
            var isPublicHoliday = DateSystem.IsAdministrationPublicHolidayByCounty(new DateTime(2016, 12, 23), "CH", EChCounty.NE.GetDescription());
            Assert.AreEqual(false, isPublicHoliday);
        }

        #endregion
    }
}