using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Contract;
using Nager.Date.Models;
using Nager.Date.Weekends;
using System.Linq;

namespace Nager.Date.UnitTest.Common
{
    [TestClass]
    public class LongWeekendTest
    {
        [TestMethod]
        public void GetLongWeekend_Austria2017_Succcessful()
        {
            var longWeekendCountAustria = 10;

            var longWeekends = DateSystem.GetLongWeekend(2017, CountryCode.AT).ToArray();

            Assert.AreEqual(longWeekendCountAustria, longWeekends.Length);
        }

        [TestMethod]
        public void Calculate_FromFridayToMonday_Successful()
        {
            // PH = PublicHoliday, WE = Weekend, BD = BridgeDay
            // ┌────┬────┬────┬────┬────┬────┬────┐
            // │ TH │ FR │ SA │ SU │ MO │ TU │ WE │
            // │ 09 │ 10 │ 11 │ 12 │ 13 │ 14 │ 15 │
            // ├────┼────┼────┼────┼────┼────┼────┤
            // │    │ PH │ WE │ WE │ PH │    │    │
            // └────┴────┴────┴────┴────┴────┴────┘
            //        └──────────────┘
            //             4 days

            var publicHolidays = new PublicHoliday[]
            {
                new PublicHoliday(2020, 01, 10, "Holiday Friday", "Holiday Friday", CountryCode.AT),
                new PublicHoliday(2020, 01, 13, "Holiday Monday", "Holiday Monday", CountryCode.AT),
            };

            ILongWeekendCalculator longWeekendCalculator = new LongWeekendCalculator(WeekendProvider.Universal);
            var longWeekends = longWeekendCalculator.Calculate(publicHolidays, availableBridgeDays: 1);

            Assert.AreEqual(1, longWeekends.Count());

            var firstLongWeekend = longWeekends.First();
            Assert.AreEqual(4, firstLongWeekend.DayCount);
            Assert.IsFalse(firstLongWeekend.Bridge);
        }

        [TestMethod]
        public void Calculate_VeryLongWeekendWithoutBridgeDay_Successful()
        {
            // PH = PublicHoliday, WE = Weekend, BD = BridgeDay
            // ┌────┬────┬────┬────┬────┬────┬────┐
            // │ TH │ FR │ SA │ SU │ MO │ TU │ WE │
            // │ 09 │ 10 │ 11 │ 12 │ 13 │ 14 │ 15 │
            // ├────┼────┼────┼────┼────┼────┼────┤
            // │    │ PH │ WE │ WE │ PH │ PH │    │
            // └────┴────┴────┴────┴────┴────┴────┘
            //        └────────────────────┘
            //                5 days

            var publicHolidays = new PublicHoliday[]
            {
                new PublicHoliday(2020, 01, 10, "Holiday Friday", "Holiday Friday", CountryCode.AT),
                new PublicHoliday(2020, 01, 13, "Holiday Monday", "Holiday Monday", CountryCode.AT),
                new PublicHoliday(2020, 01, 14, "Holiday Tuesday", "Holiday Tuesday", CountryCode.AT),
            };

            ILongWeekendCalculator longWeekendCalculator = new LongWeekendCalculator(WeekendProvider.Universal);
            var longWeekends = longWeekendCalculator.Calculate(publicHolidays, availableBridgeDays: 1);

            Assert.AreEqual(1, longWeekends.Count());

            var firstLongWeekend = longWeekends.First();
            Assert.AreEqual(5, firstLongWeekend.DayCount);
            Assert.IsFalse(firstLongWeekend.Bridge);
        }

        [TestMethod]
        public void Calculate_VeryLongWeekendWithBridgeDay_Successful()
        {
            // PH = PublicHoliday, WE = Weekend, BD = BridgeDay
            // ┌────┬────┬────┬────┬────┬────┐
            // │ TH │ FR │ SA │ SU │ MO │ TU │
            // │ 09 │ 10 │ 11 │ 12 │ 13 │ 14 │
            // ├────┼────┼────┼────┼────┼────┤
            // │    │ PH │ WE │ WE │ BD │ PH │
            // └────┴────┴────┴────┴────┴────┘
            //        └────────────────────┘
            //                 5 days

            var publicHolidays = new PublicHoliday[]
            {
                new PublicHoliday(2020, 01, 10, "Holiday Friday", "Holiday Friday", CountryCode.AT),
                new PublicHoliday(2020, 01, 14, "Holiday Tuesday", "Holiday Tuesday", CountryCode.AT),
            };

            ILongWeekendCalculator longWeekendCalculator = new LongWeekendCalculator(WeekendProvider.Universal);
            var longWeekends = longWeekendCalculator.Calculate(publicHolidays, availableBridgeDays: 1);

            Assert.AreEqual(1, longWeekends.Count());

            var firstLongWeekend = longWeekends.First();
            Assert.AreEqual(5, firstLongWeekend.DayCount);
            Assert.IsTrue(firstLongWeekend.Bridge);
        }

        [TestMethod]
        public void Calculate_LongWeekendWithTwoBridgeDay_Successful()
        {
            // PH = PublicHoliday, WE = Weekend, BD = BridgeDay
            // ┌────┬────┬────┬────┬────┬────┐
            // │ TH │ FR │ SA │ SU │ MO │ TU │
            // │ 09 │ 10 │ 11 │ 12 │ 13 │ 14 │
            // ├────┼────┼────┼────┼────┼────┤
            // │ PH │ BD │ WE │ WE │ BD │ PH │
            // └────┴────┴────┴────┴────┴────┘
            //   └─────────────────────────┘
            //     6 days (2 bridge days)

            var publicHolidays = new PublicHoliday[]
            {
                new PublicHoliday(2020, 01, 9, "Holiday Thursday", "Holiday Thursday", CountryCode.AT),
                new PublicHoliday(2020, 01, 14, "Holiday Tuesday", "Holiday Tuesday", CountryCode.AT),
            };

            ILongWeekendCalculator longWeekendCalculator = new LongWeekendCalculator(WeekendProvider.Universal);
            var longWeekends = longWeekendCalculator.Calculate(publicHolidays, availableBridgeDays: 2);

            Assert.AreEqual(1, longWeekends.Count());

            var longWeekend = longWeekends.First();
            Assert.AreEqual(6, longWeekend.DayCount);
            Assert.IsTrue(longWeekend.Bridge);
        }

        [TestMethod]
        public void Calculate_TwoLongWeekendsWithBridgeDay_Successful()
        {
            // PH = PublicHoliday, WE = Weekend, BD = BridgeDay
            // ┌────┬────┬────┬────┬────┬────┐
            // │ TH │ FR │ SA │ SU │ MO │ TU │
            // │ 09 │ 10 │ 11 │ 12 │ 13 │ 14 │
            // ├────┼────┼────┼────┼────┼────┤
            // │ PH │ BD │ WE │ WE │ BD │ PH │
            // └────┴────┴────┴────┴────┴────┘
            //   └───────────────┘
            //   4 days (1 bridge days)
            //              └───────────────┘
            //               4 days (1 bridge days)

            var publicHolidays = new PublicHoliday[]
            {
                new PublicHoliday(2020, 01, 9, "Holiday Thursday", "Holiday Thursday", CountryCode.AT),
                new PublicHoliday(2020, 01, 14, "Holiday Tuesday", "Holiday Tuesday", CountryCode.AT),
            };

            ILongWeekendCalculator longWeekendCalculator = new LongWeekendCalculator(WeekendProvider.Universal);
            var longWeekends = longWeekendCalculator.Calculate(publicHolidays, availableBridgeDays: 1);

            Assert.AreEqual(2, longWeekends.Count());

            var firstLongWeekend = longWeekends.First();
            Assert.AreEqual(4, firstLongWeekend.DayCount);
            Assert.IsTrue(firstLongWeekend.Bridge);

            var secondLongWeekend = longWeekends.Last();
            Assert.AreEqual(4, secondLongWeekend.DayCount);
            Assert.IsTrue(secondLongWeekend.Bridge);
        }

        [TestMethod]
        public void Calculate_FourLongWeekendsWithBridgeDay_Successful1()
        {
            // PH = PublicHoliday, WE = Weekend, BD = BridgeDay
            // ┌────┬────┬────┬────┬────┬────┬────┬────┬────┬────┬────┬────┬────┬────┬────┬────┐
            // │ SA │ SU │ MO │ TU │ WE │ TH │ FR │ SA │ SU │ MO │ TU │ WE │ TH │ FR │ SA │ SU │
            // │ 04 │ 05 │ 06 │ 07 │ 08 │ 09 │ 10 │ 11 │ 12 │ 13 │ 14 │ 15 │ 16 │ 17 │ 18 │ 19 │
            // ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤
            // │ WE │ WE │ BD │ BD │ PH │ BD │ BD │ WE │ WE │ BD │ BD │ PH │ BD │ BD │ WE │ WE │
            // └────┴────┴────┴────┴────┴────┴────┴────┴────┴────┴────┴────┴────┴────┴────┴────┘
            //   └────────────────────┘
            //   5 days (2 bridge days)
            //                       └────────────────────┘
            //                       5 days (2 bridge days)
            //                                      └────────────────────┘
            //                                      5 days (2 bridge days)
            //                                                          └────────────────────┘
            //                                                          5 days (2 bridge days)

            var publicHolidays = new PublicHoliday[]
            {
                new PublicHoliday(2020, 01, 8, "Holiday Wednesday", "Holiday Wednesday", CountryCode.AT),
                new PublicHoliday(2020, 01, 15, "Holiday Wednesday", "Holiday Wednesday", CountryCode.AT),
            };

            ILongWeekendCalculator longWeekendCalculator = new LongWeekendCalculator(WeekendProvider.Universal);
            var longWeekends = longWeekendCalculator.Calculate(publicHolidays, availableBridgeDays: 2).ToArray();

            Assert.AreEqual(4, longWeekends.Length);

            Assert.AreEqual(5, longWeekends[0].DayCount);
            Assert.IsTrue(longWeekends[0].Bridge);

            Assert.AreEqual(5, longWeekends[1].DayCount);
            Assert.IsTrue(longWeekends[1].Bridge);

            Assert.AreEqual(5, longWeekends[2].DayCount);
            Assert.IsTrue(longWeekends[2].Bridge);

            Assert.AreEqual(5, longWeekends[3].DayCount);
            Assert.IsTrue(longWeekends[3].Bridge);
        }

        [TestMethod]
        public void Calculate_NoLongWeekend_Successful()
        {
            // PH = PublicHoliday, WE = Weekend, BD = BridgeDay
            // ┌────┬────┬────┬────┬────┬────┐
            // │ TH │ FR │ SA │ SU │ MO │ TU │
            // │ 09 │ 10 │ 11 │ 12 │ 13 │ 14 │
            // ├────┼────┼────┼────┼────┼────┤
            // │    │    │ WE │ WE │    │    │
            // └────┴────┴────┴────┴────┴────┘
            //             └────┘
            // Public Holiday falls on a weekend

            var publicHolidays = new PublicHoliday[]
            {
                new PublicHoliday(2020, 01, 11, "Holiday Saturday", "Holiday Saturday", CountryCode.AT),
            };

            ILongWeekendCalculator longWeekendCalculator = new LongWeekendCalculator(WeekendProvider.Universal);
            var longWeekends = longWeekendCalculator.Calculate(publicHolidays, availableBridgeDays: 1);

            Assert.AreEqual(0, longWeekends.Count());
        }

        [TestMethod]
        public void Calculate_OneHolidayIsNotPublic_Successful()
        {
            // PH = PublicHoliday, WE = Weekend, BD = BridgeDay, H1 = Holiday but not public
            // ┌────┬────┬────┬────┬────┬────┐
            // │ TH │ FR │ SA │ SU │ MO │ TU │
            // │ 13 │ 14 │ 15 │ 16 │ 17 │ 18 │
            // ├────┼────┼────┼────┼────┼────┤
            // │ PH │ H1 │ WE │ WE │    │    │
            // └────┴────┴────┴────┴────┴────┘
            //    └─────────────┘
            // 4 days (require 1 bridge day the friday holiday is not public)

            var publicHolidays = new PublicHoliday[]
            {
                // Thursday
                new PublicHoliday(2021, 05, 13, "Day1", "Day1", CountryCode.AT),
                // Friday (ignore is not a public holiday)
                new PublicHoliday(2021, 05, 14, "Day2", "Day2", CountryCode.AT, null, null, PublicHolidayType.Bank | PublicHolidayType.School | PublicHolidayType.Optional),
            };

            ILongWeekendCalculator longWeekendCalculator = new LongWeekendCalculator(WeekendProvider.Universal);
            var longWeekends = longWeekendCalculator.Calculate(publicHolidays, availableBridgeDays: 1);

            Assert.IsTrue(longWeekends.Count() > 0, "No LongWeekend available");

            var firstLongWeekend = longWeekends.First();
            Assert.AreEqual(4, firstLongWeekend.DayCount);
            Assert.IsTrue(firstLongWeekend.Bridge);
        }
    }
}
