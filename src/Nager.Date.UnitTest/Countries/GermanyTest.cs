using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class GermanyTest() : BaseTest(CountryCode.DE)
    {
        [TestMethod]
        [DataRow(2021, 2021, 1, 1)]
        [DataRow(2022, 2022, 1, 1)]
        [DataRow(2023, 2023, 1, 1)]
        [DataRow(2024, 2024, 1, 1)]
        [DataRow(2025, 2025, 1, 1)]
        [DataRow(2026, 2026, 1, 1)]
        [DataRow(2027, 2027, 1, 1)]
        public void TestNewYearsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NEWYEARSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2017, 2017, 1, 6)]
        [DataRow(2021, 2021, 1, 6)]
        [DataRow(2022, 2022, 1, 6)]
        [DataRow(2023, 2023, 1, 6)]
        [DataRow(2024, 2024, 1, 6)]
        [DataRow(2025, 2025, 1, 6)]
        [DataRow(2026, 2026, 1, 6)]
        [DataRow(2027, 2027, 1, 6)]
        public void TestEpiphany(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "EPIPHANY-01", observedYear, month, day);
            this.AssertSubdivisionCodes(year, "EPIPHANY-01", "DE-BW", "DE-BY", "DE-ST");
        }

        [TestMethod]
        [DataRow(2019, 2019, 3, 8)] //First year in Berlin (law in force 7 February 2019)
        [DataRow(2020, 2020, 3, 8)]
        [DataRow(2021, 2021, 3, 8)]
        [DataRow(2022, 2022, 3, 8)]
        public void TestInternationalWomensDayBerlin(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "INTERNATIONALWOMENSDAY-01", observedYear, month, day);
            this.AssertSubdivisionCodes(year, "INTERNATIONALWOMENSDAY-01", "DE-BE");
        }

        [TestMethod]
        [DataRow(2023, 2023, 3, 8)] //First year in Mecklenburg-Vorpommern (law of 7 July 2022, in force 13 July 2022)
        [DataRow(2024, 2024, 3, 8)]
        [DataRow(2025, 2025, 3, 8)]
        [DataRow(2026, 2026, 3, 8)]
        [DataRow(2027, 2027, 3, 8)]
        public void TestInternationalWomensDayBerlinAndMecklenburgVorpommern(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "INTERNATIONALWOMENSDAY-01", observedYear, month, day);
            this.AssertSubdivisionCodes(year, "INTERNATIONALWOMENSDAY-01", "DE-BE", "DE-MV");
        }

        [TestMethod]
        [DataRow(2018)]
        public void TestNoInternationalWomensDay(int year)
        {
            this.AssertNoHoliday(year, "INTERNATIONALWOMENSDAY-01");
        }

        [TestMethod]
        [DataRow(2021, 2021, 4, 2)]
        [DataRow(2022, 2022, 4, 15)]
        [DataRow(2023, 2023, 4, 7)]
        [DataRow(2024, 2024, 3, 29)]
        [DataRow(2025, 2025, 4, 18)]
        [DataRow(2026, 2026, 4, 3)]
        [DataRow(2027, 2027, 3, 26)]
        public void TestGoodFriday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CGOODFRIDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 4, 4)]
        [DataRow(2022, 2022, 4, 17)]
        [DataRow(2023, 2023, 4, 9)]
        [DataRow(2024, 2024, 3, 31)]
        [DataRow(2025, 2025, 4, 20)]
        [DataRow(2026, 2026, 4, 5)]
        [DataRow(2027, 2027, 3, 28)]
        public void TestEasterSunday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CEASTERSUNDAY-01", observedYear, month, day);
            this.AssertSubdivisionCodes(year, "CEASTERSUNDAY-01", "DE-BB");
        }

        [TestMethod]
        [DataRow(2021, 2021, 4, 5)]
        [DataRow(2022, 2022, 4, 18)]
        [DataRow(2023, 2023, 4, 10)]
        [DataRow(2024, 2024, 4, 1)]
        [DataRow(2025, 2025, 4, 21)]
        [DataRow(2026, 2026, 4, 6)]
        [DataRow(2027, 2027, 3, 29)]
        public void TestEasterMonday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CEASTERMONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 5, 1)]
        [DataRow(2022, 2022, 5, 1)]
        [DataRow(2023, 2023, 5, 1)]
        [DataRow(2024, 2024, 5, 1)]
        [DataRow(2025, 2025, 5, 1)]
        [DataRow(2026, 2026, 5, 1)]
        [DataRow(2027, 2027, 5, 1)]
        public void TestLabourDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "LABOURDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 5, 8)] //One-time public holiday in Berlin, 75th anniversary
        [DataRow(2025, 2025, 5, 8)] //One-time public holiday in Berlin, 80th anniversary (GVBl. 2024 Nr. 28 S. 460)
        public void TestLiberationDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "LIBERATIONDAY-01", observedYear, month, day);
            this.AssertSubdivisionCodes(year, "LIBERATIONDAY-01", "DE-BE");
        }

        [TestMethod]
        [DataRow(2019)]
        [DataRow(2021)]
        [DataRow(2024)]
        [DataRow(2026)]
        public void TestNoLiberationDay(int year)
        {
            this.AssertNoHoliday(year, "LIBERATIONDAY-01");
        }

        [TestMethod]
        [DataRow(2021, 2021, 5, 13)]
        [DataRow(2022, 2022, 5, 26)]
        [DataRow(2023, 2023, 5, 18)]
        [DataRow(2024, 2024, 5, 9)]
        [DataRow(2025, 2025, 5, 29)]
        [DataRow(2026, 2026, 5, 14)]
        [DataRow(2027, 2027, 5, 6)]
        public void TestAscensionDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CASCENSIONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 5, 23)]
        [DataRow(2022, 2022, 6, 5)]
        [DataRow(2023, 2023, 5, 28)]
        [DataRow(2024, 2024, 5, 19)]
        [DataRow(2025, 2025, 6, 8)]
        [DataRow(2026, 2026, 5, 24)]
        [DataRow(2027, 2027, 5, 16)]
        public void TestPentecost(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CPENTECOST-01", observedYear, month, day);
            this.AssertSubdivisionCodes(year, "CPENTECOST-01", "DE-BB");
        }

        [TestMethod]
        [DataRow(2021, 2021, 5, 24)]
        [DataRow(2022, 2022, 6, 6)]
        [DataRow(2023, 2023, 5, 29)]
        [DataRow(2024, 2024, 5, 20)]
        [DataRow(2025, 2025, 6, 9)]
        [DataRow(2026, 2026, 5, 25)]
        [DataRow(2027, 2027, 5, 17)]
        public void TestWhitMonday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CWHITMONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2017, 2017, 6, 15)]
        [DataRow(2021, 2021, 6, 3)]
        [DataRow(2022, 2022, 6, 16)]
        [DataRow(2023, 2023, 6, 8)]
        [DataRow(2024, 2024, 5, 30)]
        [DataRow(2025, 2025, 6, 19)]
        [DataRow(2026, 2026, 6, 4)]
        [DataRow(2027, 2027, 5, 27)]
        public void TestCorpusChristi(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CCORPUSCHRISTI-01", observedYear, month, day);
            this.AssertSubdivisionCodes(year, "CCORPUSCHRISTI-01", "DE-BW", "DE-BY", "DE-HE", "DE-NW", "DE-RP", "DE-SL");
        }

        [TestMethod]
        [DataRow(1954, 1954, 6, 17)] //First year (Gesetz über den Tag der deutschen Einheit of 4 August 1953, BGBl. I S. 778)
        [DataRow(1958, 1958, 6, 17)] //Bremen law lists "der 17. Juni - Tag der deutschen Einheit -" since 17 June 1958
        [DataRow(1963, 1963, 6, 17)]
        [DataRow(1980, 1980, 6, 17)]
        [DataRow(1989, 1989, 6, 17)]
        [DataRow(1990, 1990, 6, 17)] //Last year, replaced by 3 October (Unification Treaty)
        public void TestGermanUnityDayJune17(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "GERMANUNITYDAYJUNE17-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(1953)]
        [DataRow(1991)]
        [DataRow(2024)]
        [DataRow(2028)]
        public void TestNoGermanUnityDayJune17(int year)
        {
            this.AssertNoHoliday(year, "GERMANUNITYDAYJUNE17-01");
        }

        [TestMethod]
        [DataRow(2028, 2028, 6, 17)] //One-time public holiday in Berlin (GVBl. 2024 Nr. 28 S. 460)
        public void TestUprisingOfJune17Anniversary(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "75THANNIVERSARYOFTHEUPRISING-01", observedYear, month, day);
            this.AssertSubdivisionCodes(year, "75THANNIVERSARYOFTHEUPRISING-01", "DE-BE");
        }

        [TestMethod]
        [DataRow(2027)]
        [DataRow(2029)]
        public void TestNoUprisingOfJune17Anniversary(int year)
        {
            this.AssertNoHoliday(year, "75THANNIVERSARYOFTHEUPRISING-01");
        }

        [TestMethod]
        [DataRow(2021, 2021, 8, 15)]
        [DataRow(2022, 2022, 8, 15)]
        [DataRow(2023, 2023, 8, 15)]
        [DataRow(2024, 2024, 8, 15)]
        [DataRow(2025, 2025, 8, 15)]
        [DataRow(2026, 2026, 8, 15)]
        [DataRow(2027, 2027, 8, 15)]
        public void TestAssumptionDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "ASSUMPTIONDAY-01", observedYear, month, day);
            this.AssertSubdivisionCodes(year, "ASSUMPTIONDAY-01", "DE-SL");
        }

        [TestMethod]
        [DataRow(2019, 2019, 9, 20)] //First year in Thuringia
        [DataRow(2020, 2020, 9, 20)]
        [DataRow(2021, 2021, 9, 20)]
        [DataRow(2022, 2022, 9, 20)]
        [DataRow(2023, 2023, 9, 20)]
        [DataRow(2024, 2024, 9, 20)]
        [DataRow(2025, 2025, 9, 20)]
        [DataRow(2026, 2026, 9, 20)]
        [DataRow(2027, 2027, 9, 20)]
        public void TestWorldChildrensDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "WORLDCHILDRENSDAY-01", observedYear, month, day);
            this.AssertSubdivisionCodes(year, "WORLDCHILDRENSDAY-01", "DE-TH");
        }

        [TestMethod]
        [DataRow(2018)]
        public void TestNoWorldChildrensDay(int year)
        {
            this.AssertNoHoliday(year, "WORLDCHILDRENSDAY-01");
        }

        [TestMethod]
        [DataRow(1990, 1990, 10, 3)] //First year (Unification Treaty, Art. 2 Abs. 2)
        [DataRow(2021, 2021, 10, 3)]
        [DataRow(2022, 2022, 10, 3)]
        [DataRow(2023, 2023, 10, 3)]
        [DataRow(2024, 2024, 10, 3)]
        [DataRow(2025, 2025, 10, 3)]
        [DataRow(2026, 2026, 10, 3)]
        [DataRow(2027, 2027, 10, 3)]
        public void TestGermanUnityDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "GERMANUNITYDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(1989)]
        public void TestNoGermanUnityDay(int year)
        {
            this.AssertNoHoliday(year, "GERMANUNITYDAY-01");
        }

        [TestMethod]
        [DataRow(2016, 2016, 10, 31)]
        public void TestReformationDayBefore2018(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "REFORMATIONDAY-01", observedYear, month, day);
            this.AssertSubdivisionCodes(year, "REFORMATIONDAY-01", "DE-BB", "DE-MV", "DE-SN", "DE-ST", "DE-TH");
        }

        [TestMethod]
        [DataRow(2018, 2018, 10, 31)] //First year in Bremen, Hamburg, Lower Saxony and Schleswig-Holstein
        [DataRow(2021, 2021, 10, 31)]
        [DataRow(2022, 2022, 10, 31)]
        [DataRow(2023, 2023, 10, 31)]
        [DataRow(2024, 2024, 10, 31)]
        [DataRow(2025, 2025, 10, 31)]
        [DataRow(2026, 2026, 10, 31)]
        [DataRow(2027, 2027, 10, 31)]
        public void TestReformationDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "REFORMATIONDAY-01", observedYear, month, day);
            this.AssertSubdivisionCodes(year, "REFORMATIONDAY-01", "DE-BB", "DE-HB", "DE-HH", "DE-MV", "DE-NI", "DE-SH", "DE-SN", "DE-ST", "DE-TH");
        }

        [TestMethod]
        [DataRow(1984, 1984, 11, 1)] //First year statewide in Bavaria (Feiertagsgesetz 1980, Art. 9 Abs. 2)
        [DataRow(2021, 2021, 11, 1)]
        [DataRow(2022, 2022, 11, 1)]
        [DataRow(2023, 2023, 11, 1)]
        [DataRow(2024, 2024, 11, 1)]
        [DataRow(2025, 2025, 11, 1)]
        [DataRow(2026, 2026, 11, 1)]
        [DataRow(2027, 2027, 11, 1)]
        public void TestAllSaintsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "ALLSAINTSDAY-01", observedYear, month, day);
            this.AssertSubdivisionCodes(year, "ALLSAINTSDAY-01", "DE-BW", "DE-BY", "DE-NW", "DE-RP", "DE-SL");
        }

        [TestMethod]
        [DataRow(1981, 1981, 11, 1)] //Bavaria only in predominantly Catholic municipalities (Feiertagsgesetz 1980, Art. 9 Abs. 2)
        [DataRow(1983, 1983, 11, 1)]
        public void TestAllSaintsDayWithoutBavaria(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "ALLSAINTSDAY-01", observedYear, month, day);
            this.AssertSubdivisionCodes(year, "ALLSAINTSDAY-01", "DE-BW", "DE-NW", "DE-RP", "DE-SL");
        }

        [TestMethod]
        [DataRow(1994, 1994, 11, 16)] //Last year in Bremen (law until 9 December 1994)
        public void TestRepentanceAndPrayerDayBremen(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "REPENTANCEANDPRAYERDAY-01", observedYear, month, day);
            Assert.IsTrue(HolidaySystem.IsPublicHoliday(new DateTime(year, month, day), CountryCode.DE, "DE-HB"));
        }

        [TestMethod]
        [DataRow(1995, 1995, 11, 22)] //First year only in Saxony
        [DataRow(2021, 2021, 11, 17)]
        [DataRow(2022, 2022, 11, 16)]
        [DataRow(2023, 2023, 11, 22)]
        [DataRow(2024, 2024, 11, 20)]
        [DataRow(2025, 2025, 11, 19)]
        [DataRow(2026, 2026, 11, 18)]
        [DataRow(2027, 2027, 11, 17)]
        public void TestRepentanceAndPrayerDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "REPENTANCEANDPRAYERDAY-01", observedYear, month, day);
            this.AssertSubdivisionCodes(year, "REPENTANCEANDPRAYERDAY-01", "DE-SN");
        }

        [TestMethod]
        [DataRow(2017, 2017, 12, 25)]
        [DataRow(2021, 2021, 12, 25)]
        [DataRow(2022, 2022, 12, 25)]
        [DataRow(2023, 2023, 12, 25)]
        [DataRow(2024, 2024, 12, 25)]
        [DataRow(2025, 2025, 12, 25)]
        [DataRow(2026, 2026, 12, 25)]
        [DataRow(2027, 2027, 12, 25)]
        public void TestChristmasDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CHRISTMASDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 12, 26)]
        [DataRow(2022, 2022, 12, 26)]
        [DataRow(2023, 2023, 12, 26)]
        [DataRow(2024, 2024, 12, 26)]
        [DataRow(2025, 2025, 12, 26)]
        [DataRow(2026, 2026, 12, 26)]
        [DataRow(2027, 2027, 12, 26)]
        public void TestStStephensDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "STSTEPHENSDAY-01", observedYear, month, day);
        }
    }
}
