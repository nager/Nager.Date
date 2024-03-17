using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Helpers;
using System;

namespace Nager.Date.UnitTest.Common
{
    [TestClass]
    public class DateHelperTest
    {
        [TestMethod]
        public void CheckFindDay()
        {
            var result = DateHelper.FindDay(2017, 1, 1, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 6), result);

            result = DateHelper.FindDay(2017, 1, 2, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 6), result);

            result = DateHelper.FindDay(2017, 1, 3, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 6), result);

            result = DateHelper.FindDay(2017, 1, 4, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 6), result);

            result = DateHelper.FindDay(2017, 1, 5, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 6), result);

            result = DateHelper.FindDay(2017, 1, 6, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 6), result);

            result = DateHelper.FindDay(2017, 1, 7, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateHelper.FindDay(2017, 1, 8, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateHelper.FindDay(2017, 1, 9, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateHelper.FindDay(2017, 1, 10, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateHelper.FindDay(2017, 1, 11, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateHelper.FindDay(2017, 1, 12, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateHelper.FindDay(2017, 1, 13, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateHelper.FindDay(2017, 1, 14, DayOfWeek.Wednesday);
            Assert.AreEqual(new DateTime(2017, 1, 18), result);

            result = DateHelper.FindDay(2022, 1, 1, DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2022, 1, 3), result);

            result = DateHelper.FindDay(2022, 1, 1, DayOfWeek.Tuesday);
            Assert.AreEqual(new DateTime(2022, 1, 4), result);
        }

        [TestMethod]
        public void CheckFindDayBefore()
        {
            var result = DateHelper.FindDayBefore(2018, 5, 25, DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2018, 5, 21), result);

            result = DateHelper.FindDayBefore(2018, 1, 9, DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2018, 1, 8), result);

            result = DateHelper.FindDayBefore(2018, 1, 8, DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2018, 1, 1), result);

            result = DateHelper.FindDayBefore(2018, 1, 12, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2018, 1, 5), result);
        }

        [TestMethod]
        public void CheckFindDayBetween1()
        {
            var result = DateHelper.FindDayBetween(2019, 7, 1, 2019, 7, 7, DayOfWeek.Tuesday);
            Assert.IsNotNull(result);
            Assert.AreEqual(new DateTime(2019, 7, 2), result.Value);
        }

        [TestMethod]
        public void CheckFindDayBetween2()
        {
            var result = DateHelper.FindDayBetween(2019, 7, 1, 2019, 7, 7, DayOfWeek.Wednesday);
            Assert.IsNotNull(result);
            Assert.AreEqual(new DateTime(2019, 7, 3), result.Value);
        }

        [TestMethod]
        public void CheckFindDayBetween3()
        {
            var result = DateHelper.FindDayBetween(2019, 7, 1, 2019, 7, 7, DayOfWeek.Friday);
            Assert.IsNotNull(result);
            Assert.AreEqual(new DateTime(2019, 7, 5), result.Value);
        }

        [TestMethod]
        public void CheckFindDayBetween4()
        {
            var result = DateHelper.FindDayBetween(2019, 7, 1, 2019, 7, 7, DayOfWeek.Saturday);
            Assert.IsNotNull(result);
            Assert.AreEqual(new DateTime(2019, 7, 6), result.Value);
        }

        [TestMethod]
        public void CheckFindDayBetween5()
        {
            var result = DateHelper.FindDayBetween(2022, 08, 25, 2022, 08, 28, DayOfWeek.Tuesday);
            Assert.IsNull(result);
        }
    }
}
