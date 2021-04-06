using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class TurkeyTest
    {
        [TestMethod]
        public void TestTurkey()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(2017, CountryCode.TR).ToArray();

            //New Year's Day
            var newYearDay = new DateTime(2017, 1, 1);
            Assert.AreEqual(newYearDay, publicHolidays.Where(op => op.Date == newYearDay).FirstOrDefault().Date);

            //National Independence & Children's Day
            var childrenDay = new DateTime(2017, 4, 23);
            Assert.AreEqual(childrenDay, publicHolidays.Where(op => op.Date == childrenDay).FirstOrDefault().Date);

            //Labour Day
            var labourDay = new DateTime(2017, 5, 1);
            Assert.AreEqual(labourDay, publicHolidays.Where(op => op.Date == labourDay).FirstOrDefault().Date);

            //Atatürk Commemoration & Youth Day
            var AtaturkDay = new DateTime(2017, 5, 19);
            Assert.AreEqual(AtaturkDay, publicHolidays.Where(op => op.Date == AtaturkDay).FirstOrDefault().Date);

            //Democracy Day
            var democracyDay = new DateTime(2017, 7, 15);
            Assert.AreEqual(democracyDay, publicHolidays.Where(op => op.Date == democracyDay).FirstOrDefault().Date);

            //Victory Day
            var victoryDay = new DateTime(2017, 8, 30);
            Assert.AreEqual(victoryDay, publicHolidays.Where(op => op.Date == victoryDay).FirstOrDefault().Date);

            //Republic Day
            var republicDay = new DateTime(2017, 10, 29);
            Assert.AreEqual(republicDay, publicHolidays.Where(op => op.Date == republicDay).FirstOrDefault().Date);

        }

        [TestMethod]
        [DataRow(2018, 10, 8, false)]
        [DataRow(2018, 10, 9, false)]
        [DataRow(2018, 10, 10, false)]
        [DataRow(2018, 10, 11, false)]
        [DataRow(2018, 10, 12, false)]
        [DataRow(2018, 10, 13, true)]
        [DataRow(2018, 10, 14, true)]
        public void ChecksThatUniversalWeekendIsUsed(int year, int month, int day, bool expected)
        {
            // Arrange
            var date = new DateTime(year, month, day);

            // Act
            var result = date.IsWeekend(CountryCode.TR);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
