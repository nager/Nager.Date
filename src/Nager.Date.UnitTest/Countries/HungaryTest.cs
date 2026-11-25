using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class HungaryTest() : BaseTest(CountryCode.HU)
    {
        [TestMethod]
        public void TestHungaryHoliday2018()
        {
            var year = 2018;

            this.AssertObservedDate(year, "NEWYEARSDAY-01", year, 1, 1);
            this.AssertObservedDate(year, "1848REVOLUTIONMEMORIALDAY-01", year, 3, 15);
            this.AssertObservedDate(year, "CGOODFRIDAY-01", year, 3, 30);
            this.AssertObservedDate(year, "CEASTERSUNDAY-01", year, 4, 1);
            this.AssertObservedDate(year, "CEASTERMONDAY-01", year, 4, 2);
            this.AssertObservedDate(year, "LABOURDAY-01", year, 5, 1);
            this.AssertObservedDate(year, "CPENTECOST-01", year, 5, 20);
            this.AssertObservedDate(year, "CWHITMONDAY-01", year, 5, 21);
            this.AssertObservedDate(year, "STATEFOUNDATIONDAY-01", year, 8, 20);
            this.AssertObservedDate(year, "HU-REVOLUTIONMEMORIALDAY-01", year, 10, 23);
            this.AssertObservedDate(year, "ALLSAINTSDAY-01", year, 11, 1);
            this.AssertObservedDate(year, "CHRISTMASDAY-01", year, 12, 25);
            this.AssertObservedDate(year, "STSTEPHENSDAY-01", year, 12, 26);
        }

        [TestMethod]
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
            var isWeekend = date.IsWeekend(CountryCode.HU);
            Assert.AreEqual(expectedIsWeekend, isWeekend);
        }

        [TestMethod]
        public void TestChristmasEve()
        {
            this.AssertNoHoliday(2025, "CHRISTMASEVE-01");
            this.AssertObservedDate(2026, "CHRISTMASEVE-01", 2026, 12, 24);
        }
    }
}
