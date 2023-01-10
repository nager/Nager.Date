using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Contract;
using Nager.Date.Model;
using Nager.Date.PublicHolidays;
using System;
using System.Diagnostics;
using System.Linq;

namespace Nager.Date.UnitTest.Common
{
    [TestClass]
    public class LogicTest
    {
        [TestMethod]

        public void CheckPublicHolidayProviders()
        {
            var startYear = DateTime.Today.Year - 100;
            var endYear = DateTime.Today.Year + 100;

            foreach (CountryCode countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                var publicHolidayProvider = DateSystem.GetPublicHolidayProvider(countryCode);
                if (publicHolidayProvider is NoHolidaysProvider)
                {
                    continue;
                }

                for (var calculationYear = startYear; calculationYear < endYear; calculationYear++)
                {
                    try
                    {
                        var items = publicHolidayProvider.GetHolidays(calculationYear);
                        Assert.IsTrue(items.Any());
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine($"{countryCode} {exception}");
                    }
                }
            }
        }

        [TestMethod]
        [Ignore]
        public void Check_NoPublicHolidays_MoveInAnOtherYear()
        {
            var startYear = DateTime.Today.Year - 100;
            var endYear = DateTime.Today.Year + 100;

            foreach (CountryCode countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                var corruptPublicHolidaysFound = false;

                for (var calculationYear = startYear; calculationYear < endYear; calculationYear++)
                {
                    try
                    {
                        var items = DateSystem.GetPublicHolidays(calculationYear, countryCode);
                        if (items.Any(o => !o.Date.Year.Equals(calculationYear)))
                        {
                            corruptPublicHolidaysFound = true;
                            break;
                        }
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine($"{countryCode} {exception}");
                    }
                }

                Debug.WriteLineIf(corruptPublicHolidaysFound, $"Check country {countryCode}");
            }
        }

        [DataTestMethod]
        [DataRow(1900, 4, 15)]
        [DataRow(2014, 4, 20)]
        [DataRow(2015, 4, 5)]
        [DataRow(2016, 3, 27)]
        [DataRow(2017, 4, 16)]
        [DataRow(2018, 4, 1)]
        [DataRow(2019, 4, 21)]
        [DataRow(2020, 4, 12)]
        [DataRow(2200, 4, 6)]
        public void CheckEasterSunday(int year, int month, int day)
        {
            var catholicProvider = new MockPublicHolidayProvider(new CatholicProvider());

            var easterSunday = catholicProvider.EasterSunday(year);
            Assert.AreEqual(new DateTime(year, month, day), easterSunday);
        }

        [TestMethod]
        public void CheckIsPublicHoliday()
        {
            var isPublicHoliday = DateSystem.IsPublicHoliday(new DateTime(2016, 5, 1), CountryCode.AT);
            Assert.AreEqual(true, isPublicHoliday);

            isPublicHoliday = DateSystem.IsPublicHoliday(new DateTime(2016, 1, 6), CountryCode.AT);
            Assert.AreEqual(true, isPublicHoliday);

            isPublicHoliday = DateSystem.IsPublicHoliday(new DateTime(2016, 1, 6), "AT");
            Assert.AreEqual(true, isPublicHoliday);

            isPublicHoliday = DateSystem.IsPublicHoliday(new DateTime(2016, 1, 6), "AT");
            Assert.AreEqual(true, isPublicHoliday);
        }

        [TestMethod]
        public void CheckIsWeekend()
        {
            var isPublicHoliday = DateSystem.IsWeekend(new DateTime(2021, 10, 20), CountryCode.AT);
            Assert.IsFalse(isPublicHoliday);

            isPublicHoliday = DateSystem.IsWeekend(new DateTime(2021, 10, 20), "AT");
            Assert.IsFalse(isPublicHoliday);

            isPublicHoliday = DateSystem.IsWeekend(new DateTime(2021, 10, 24), CountryCode.AT);
            Assert.IsTrue(isPublicHoliday);

            isPublicHoliday = DateSystem.IsWeekend(new DateTime(2021, 10, 24), "AT");
            Assert.IsTrue(isPublicHoliday);
        }

        [TestMethod]
        public void CheckFindDay()
        {
            var result = DateSystem.FindDay(2017, 1, 1, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 6), result);

            result = DateSystem.FindDay(2017, 1, 2, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 6), result);

            result = DateSystem.FindDay(2017, 1, 3, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 6), result);

            result = DateSystem.FindDay(2017, 1, 4, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 6), result);

            result = DateSystem.FindDay(2017, 1, 5, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 6), result);

            result = DateSystem.FindDay(2017, 1, 6, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 6), result);

            result = DateSystem.FindDay(2017, 1, 7, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateSystem.FindDay(2017, 1, 8, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateSystem.FindDay(2017, 1, 9, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateSystem.FindDay(2017, 1, 10, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateSystem.FindDay(2017, 1, 11, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateSystem.FindDay(2017, 1, 12, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateSystem.FindDay(2017, 1, 13, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateSystem.FindDay(2017, 1, 14, DayOfWeek.Wednesday);
            Assert.AreEqual(new DateTime(2017, 1, 18), result);

            result = DateSystem.FindDay(2022, 1, 1, DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2022, 1, 3), result);

            result = DateSystem.FindDay(2022, 1, 1, DayOfWeek.Tuesday);
            Assert.AreEqual(new DateTime(2022, 1, 4), result);
        }

        [TestMethod]
        public void CheckFindDayBefore()
        {
            var result = DateSystem.FindDayBefore(2018, 5, 25, DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2018, 5, 21), result);

            result = DateSystem.FindDayBefore(2018, 1, 9, DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2018, 1, 8), result);

            result = DateSystem.FindDayBefore(2018, 1, 8, DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2018, 1, 1), result);

            result = DateSystem.FindDayBefore(2018, 1, 12, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2018, 1, 5), result);
        }

        [TestMethod]
        public void CheckFindDayBetween1()
        {
            var result = DateSystem.FindDayBetween(2019, 7, 1, 2019, 7, 7, DayOfWeek.Tuesday);
            Assert.IsNotNull(result);
            Assert.AreEqual(new DateTime(2019, 7, 2), result.Value);
        }


        [TestMethod]
        public void CheckFindDayBetween2()
        {
            var result = DateSystem.FindDayBetween(2019, 7, 1, 2019, 7, 7, DayOfWeek.Wednesday);
            Assert.IsNotNull(result);
            Assert.AreEqual(new DateTime(2019, 7, 3), result.Value);
        }


        [TestMethod]
        public void CheckFindDayBetween3()
        {
            var result = DateSystem.FindDayBetween(2019, 7, 1, 2019, 7, 7, DayOfWeek.Friday);
            Assert.IsNotNull(result);
            Assert.AreEqual(new DateTime(2019, 7, 5), result.Value);
        }

        [TestMethod]
        public void CheckFindDayBetween4()
        {
            var result = DateSystem.FindDayBetween(2019, 7, 1, 2019, 7, 7, DayOfWeek.Saturday);
            Assert.IsNotNull(result);
            Assert.AreEqual(new DateTime(2019, 7, 6), result.Value);
        }

        [TestMethod]
        public void CheckFindDayBetween5()
        {
            var result = DateSystem.FindDayBetween(2022, 08, 25, 2022, 08, 28, DayOfWeek.Tuesday);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void CheckPublicHolidayWithDateFilter1()
        {
            this.CheckPublicHolidayWithDateFilter1(new DateTime(2016, 5, 1), new DateTime(2018, 5, 31));
            this.CheckPublicHolidayWithDateFilter1(new DateTime(2016, 5, 1, 0, 0, 1), new DateTime(2018, 5, 31, 23, 59, 59));
            this.CheckPublicHolidayWithDateFilter1(new DateTime(2016, 5, 1, 12, 30, 0), new DateTime(2018, 5, 31, 0, 0, 0));
            this.CheckPublicHolidayWithDateFilter1(new DateTime(2016, 5, 1, 23, 59, 59), new DateTime(2018, 5, 31, 23, 59, 59));
        }

        private void CheckPublicHolidayWithDateFilter1(DateTime startDate, DateTime endDate)
        {
            var items = DateSystem.GetPublicHolidays(startDate, endDate, CountryCode.DE);

            Assert.AreEqual(43, items.Count());
            Assert.IsTrue(items.First().Date > new DateTime(2016, 4, 28));
            Assert.IsTrue(items.Last().Date < new DateTime(2018, 6, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "endDate is before startDate")]
        public void CheckPublicHolidayWithDateFilter2()
        {
            DateSystem.GetPublicHolidays(new DateTime(2016, 1, 2), new DateTime(2016, 1, 1), CountryCode.DE).First();
        }

        [TestMethod]
        public void CheckIsOfficialPublicHolidayByCounty1()
        {
            var isPublicHoliday = DateSystem.IsPublicHoliday(new DateTime(2019, 8, 5), CountryCode.AU);
            Assert.IsFalse(isPublicHoliday);
            isPublicHoliday = DateSystem.IsPublicHoliday(new DateTime(2019, 8, 5), CountryCode.AU, "AU-NT");
            Assert.IsTrue(isPublicHoliday);
            isPublicHoliday = DateSystem.IsPublicHoliday(new DateTime(2019, 8, 5), CountryCode.AU, "AU-WA");
            Assert.IsFalse(isPublicHoliday);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid countyCode AUS-NT")]
        public void CheckIsOfficialPublicHolidayByCounty2()
        {
            var isPublicHoliday = DateSystem.IsPublicHoliday(new DateTime(2019, 8, 5), CountryCode.AU, "AUS-NT");
            Assert.IsTrue(isPublicHoliday);
        }


        [TestMethod]
        public void CheckGlobalSwtichWork()
        {
            var publicHoliday = new PublicHoliday(2020, 01, 30, "Test", "Test", CountryCode.AT, null, null, PublicHolidayType.Public);

            Assert.IsTrue(publicHoliday.Global);

            publicHoliday = new PublicHoliday(2020, 01, 30, "Test", "Test", CountryCode.AT, null, new[] { "AT-1" }, PublicHolidayType.Public);

            Assert.IsFalse(publicHoliday.Global);
        }
    }
}
