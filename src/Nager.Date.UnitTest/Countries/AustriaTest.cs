using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    /// <summary>
    /// Expected dates are taken from the official open data holiday calendar of the City of Vienna
    /// (https://www.wien.gv.at/gogv/l9ogdfeiertagskalender, type "HF", all years 2004-2034)
    /// and the Feiertagsruhegesetz 1957 (BGBl. Nr. 153/1957).
    /// </summary>
    [TestClass]
    public class AustriaTest() : BaseTest(CountryCode.AT)
    {
        #region Fixed public holidays

        [TestMethod]
        [DataRow(2004, 2004, 1, 1)]
        [DataRow(2005, 2005, 1, 1)]
        [DataRow(2006, 2006, 1, 1)]
        [DataRow(2007, 2007, 1, 1)]
        [DataRow(2008, 2008, 1, 1)]
        [DataRow(2009, 2009, 1, 1)]
        [DataRow(2010, 2010, 1, 1)]
        [DataRow(2011, 2011, 1, 1)]
        [DataRow(2012, 2012, 1, 1)]
        [DataRow(2013, 2013, 1, 1)]
        [DataRow(2014, 2014, 1, 1)]
        [DataRow(2015, 2015, 1, 1)]
        [DataRow(2016, 2016, 1, 1)]
        [DataRow(2017, 2017, 1, 1)]
        [DataRow(2018, 2018, 1, 1)]
        [DataRow(2019, 2019, 1, 1)]
        [DataRow(2020, 2020, 1, 1)]
        [DataRow(2021, 2021, 1, 1)]
        [DataRow(2022, 2022, 1, 1)]
        [DataRow(2023, 2023, 1, 1)]
        [DataRow(2024, 2024, 1, 1)]
        [DataRow(2025, 2025, 1, 1)]
        [DataRow(2026, 2026, 1, 1)]
        [DataRow(2027, 2027, 1, 1)]
        [DataRow(2028, 2028, 1, 1)]
        [DataRow(2029, 2029, 1, 1)]
        [DataRow(2030, 2030, 1, 1)]
        [DataRow(2031, 2031, 1, 1)]
        [DataRow(2032, 2032, 1, 1)]
        [DataRow(2033, 2033, 1, 1)]
        [DataRow(2034, 2034, 1, 1)]
        public void TestNewYearsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NEWYEARSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2004, 2004, 1, 6)]
        [DataRow(2005, 2005, 1, 6)]
        [DataRow(2006, 2006, 1, 6)]
        [DataRow(2007, 2007, 1, 6)]
        [DataRow(2008, 2008, 1, 6)]
        [DataRow(2009, 2009, 1, 6)]
        [DataRow(2010, 2010, 1, 6)]
        [DataRow(2011, 2011, 1, 6)]
        [DataRow(2012, 2012, 1, 6)]
        [DataRow(2013, 2013, 1, 6)]
        [DataRow(2014, 2014, 1, 6)]
        [DataRow(2015, 2015, 1, 6)]
        [DataRow(2016, 2016, 1, 6)]
        [DataRow(2017, 2017, 1, 6)]
        [DataRow(2018, 2018, 1, 6)]
        [DataRow(2019, 2019, 1, 6)]
        [DataRow(2020, 2020, 1, 6)]
        [DataRow(2021, 2021, 1, 6)]
        [DataRow(2022, 2022, 1, 6)]
        [DataRow(2023, 2023, 1, 6)]
        [DataRow(2024, 2024, 1, 6)]
        [DataRow(2025, 2025, 1, 6)]
        [DataRow(2026, 2026, 1, 6)]
        [DataRow(2027, 2027, 1, 6)]
        [DataRow(2028, 2028, 1, 6)]
        [DataRow(2029, 2029, 1, 6)]
        [DataRow(2030, 2030, 1, 6)]
        [DataRow(2031, 2031, 1, 6)]
        [DataRow(2032, 2032, 1, 6)]
        [DataRow(2033, 2033, 1, 6)]
        [DataRow(2034, 2034, 1, 6)]
        public void TestEpiphany(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "EPIPHANY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2004, 2004, 5, 1)]
        [DataRow(2005, 2005, 5, 1)]
        [DataRow(2006, 2006, 5, 1)]
        [DataRow(2007, 2007, 5, 1)]
        [DataRow(2008, 2008, 5, 1)]
        [DataRow(2009, 2009, 5, 1)]
        [DataRow(2010, 2010, 5, 1)]
        [DataRow(2011, 2011, 5, 1)]
        [DataRow(2012, 2012, 5, 1)]
        [DataRow(2013, 2013, 5, 1)]
        [DataRow(2014, 2014, 5, 1)]
        [DataRow(2015, 2015, 5, 1)]
        [DataRow(2016, 2016, 5, 1)]
        [DataRow(2017, 2017, 5, 1)]
        [DataRow(2018, 2018, 5, 1)]
        [DataRow(2019, 2019, 5, 1)]
        [DataRow(2020, 2020, 5, 1)]
        [DataRow(2021, 2021, 5, 1)]
        [DataRow(2022, 2022, 5, 1)]
        [DataRow(2023, 2023, 5, 1)]
        [DataRow(2024, 2024, 5, 1)]
        [DataRow(2025, 2025, 5, 1)]
        [DataRow(2026, 2026, 5, 1)]
        [DataRow(2027, 2027, 5, 1)]
        [DataRow(2028, 2028, 5, 1)]
        [DataRow(2029, 2029, 5, 1)]
        [DataRow(2030, 2030, 5, 1)]
        [DataRow(2031, 2031, 5, 1)]
        [DataRow(2032, 2032, 5, 1)]
        [DataRow(2033, 2033, 5, 1)]
        [DataRow(2034, 2034, 5, 1)]
        public void TestStaatsfeiertag(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NATIONALHOLIDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2004, 2004, 8, 15)]
        [DataRow(2005, 2005, 8, 15)]
        [DataRow(2006, 2006, 8, 15)]
        [DataRow(2007, 2007, 8, 15)]
        [DataRow(2008, 2008, 8, 15)]
        [DataRow(2009, 2009, 8, 15)]
        [DataRow(2010, 2010, 8, 15)]
        [DataRow(2011, 2011, 8, 15)]
        [DataRow(2012, 2012, 8, 15)]
        [DataRow(2013, 2013, 8, 15)]
        [DataRow(2014, 2014, 8, 15)]
        [DataRow(2015, 2015, 8, 15)]
        [DataRow(2016, 2016, 8, 15)]
        [DataRow(2017, 2017, 8, 15)]
        [DataRow(2018, 2018, 8, 15)]
        [DataRow(2019, 2019, 8, 15)]
        [DataRow(2020, 2020, 8, 15)]
        [DataRow(2021, 2021, 8, 15)]
        [DataRow(2022, 2022, 8, 15)]
        [DataRow(2023, 2023, 8, 15)]
        [DataRow(2024, 2024, 8, 15)]
        [DataRow(2025, 2025, 8, 15)]
        [DataRow(2026, 2026, 8, 15)]
        [DataRow(2027, 2027, 8, 15)]
        [DataRow(2028, 2028, 8, 15)]
        [DataRow(2029, 2029, 8, 15)]
        [DataRow(2030, 2030, 8, 15)]
        [DataRow(2031, 2031, 8, 15)]
        [DataRow(2032, 2032, 8, 15)]
        [DataRow(2033, 2033, 8, 15)]
        [DataRow(2034, 2034, 8, 15)]
        public void TestAssumptionDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "ASSUMPTIONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2004, 2004, 10, 26)]
        [DataRow(2005, 2005, 10, 26)]
        [DataRow(2006, 2006, 10, 26)]
        [DataRow(2007, 2007, 10, 26)]
        [DataRow(2008, 2008, 10, 26)]
        [DataRow(2009, 2009, 10, 26)]
        [DataRow(2010, 2010, 10, 26)]
        [DataRow(2011, 2011, 10, 26)]
        [DataRow(2012, 2012, 10, 26)]
        [DataRow(2013, 2013, 10, 26)]
        [DataRow(2014, 2014, 10, 26)]
        [DataRow(2015, 2015, 10, 26)]
        [DataRow(2016, 2016, 10, 26)]
        [DataRow(2017, 2017, 10, 26)]
        [DataRow(2018, 2018, 10, 26)]
        [DataRow(2019, 2019, 10, 26)]
        [DataRow(2020, 2020, 10, 26)]
        [DataRow(2021, 2021, 10, 26)]
        [DataRow(2022, 2022, 10, 26)]
        [DataRow(2023, 2023, 10, 26)]
        [DataRow(2024, 2024, 10, 26)]
        [DataRow(2025, 2025, 10, 26)]
        [DataRow(2026, 2026, 10, 26)]
        [DataRow(2027, 2027, 10, 26)]
        [DataRow(2028, 2028, 10, 26)]
        [DataRow(2029, 2029, 10, 26)]
        [DataRow(2030, 2030, 10, 26)]
        [DataRow(2031, 2031, 10, 26)]
        [DataRow(2032, 2032, 10, 26)]
        [DataRow(2033, 2033, 10, 26)]
        [DataRow(2034, 2034, 10, 26)]
        public void TestNationalfeiertag(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NATIONALHOLIDAY-02", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2004, 2004, 11, 1)]
        [DataRow(2005, 2005, 11, 1)]
        [DataRow(2006, 2006, 11, 1)]
        [DataRow(2007, 2007, 11, 1)]
        [DataRow(2008, 2008, 11, 1)]
        [DataRow(2009, 2009, 11, 1)]
        [DataRow(2010, 2010, 11, 1)]
        [DataRow(2011, 2011, 11, 1)]
        [DataRow(2012, 2012, 11, 1)]
        [DataRow(2013, 2013, 11, 1)]
        [DataRow(2014, 2014, 11, 1)]
        [DataRow(2015, 2015, 11, 1)]
        [DataRow(2016, 2016, 11, 1)]
        [DataRow(2017, 2017, 11, 1)]
        [DataRow(2018, 2018, 11, 1)]
        [DataRow(2019, 2019, 11, 1)]
        [DataRow(2020, 2020, 11, 1)]
        [DataRow(2021, 2021, 11, 1)]
        [DataRow(2022, 2022, 11, 1)]
        [DataRow(2023, 2023, 11, 1)]
        [DataRow(2024, 2024, 11, 1)]
        [DataRow(2025, 2025, 11, 1)]
        [DataRow(2026, 2026, 11, 1)]
        [DataRow(2027, 2027, 11, 1)]
        [DataRow(2028, 2028, 11, 1)]
        [DataRow(2029, 2029, 11, 1)]
        [DataRow(2030, 2030, 11, 1)]
        [DataRow(2031, 2031, 11, 1)]
        [DataRow(2032, 2032, 11, 1)]
        [DataRow(2033, 2033, 11, 1)]
        [DataRow(2034, 2034, 11, 1)]
        public void TestAllSaintsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "ALLSAINTSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2004, 2004, 12, 8)]
        [DataRow(2005, 2005, 12, 8)]
        [DataRow(2006, 2006, 12, 8)]
        [DataRow(2007, 2007, 12, 8)]
        [DataRow(2008, 2008, 12, 8)]
        [DataRow(2009, 2009, 12, 8)]
        [DataRow(2010, 2010, 12, 8)]
        [DataRow(2011, 2011, 12, 8)]
        [DataRow(2012, 2012, 12, 8)]
        [DataRow(2013, 2013, 12, 8)]
        [DataRow(2014, 2014, 12, 8)]
        [DataRow(2015, 2015, 12, 8)]
        [DataRow(2016, 2016, 12, 8)]
        [DataRow(2017, 2017, 12, 8)]
        [DataRow(2018, 2018, 12, 8)]
        [DataRow(2019, 2019, 12, 8)]
        [DataRow(2020, 2020, 12, 8)]
        [DataRow(2021, 2021, 12, 8)]
        [DataRow(2022, 2022, 12, 8)]
        [DataRow(2023, 2023, 12, 8)]
        [DataRow(2024, 2024, 12, 8)]
        [DataRow(2025, 2025, 12, 8)]
        [DataRow(2026, 2026, 12, 8)]
        [DataRow(2027, 2027, 12, 8)]
        [DataRow(2028, 2028, 12, 8)]
        [DataRow(2029, 2029, 12, 8)]
        [DataRow(2030, 2030, 12, 8)]
        [DataRow(2031, 2031, 12, 8)]
        [DataRow(2032, 2032, 12, 8)]
        [DataRow(2033, 2033, 12, 8)]
        [DataRow(2034, 2034, 12, 8)]
        public void TestImmaculateConception(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "IMMACULATECONCEPTION-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2004, 2004, 12, 25)]
        [DataRow(2005, 2005, 12, 25)]
        [DataRow(2006, 2006, 12, 25)]
        [DataRow(2007, 2007, 12, 25)]
        [DataRow(2008, 2008, 12, 25)]
        [DataRow(2009, 2009, 12, 25)]
        [DataRow(2010, 2010, 12, 25)]
        [DataRow(2011, 2011, 12, 25)]
        [DataRow(2012, 2012, 12, 25)]
        [DataRow(2013, 2013, 12, 25)]
        [DataRow(2014, 2014, 12, 25)]
        [DataRow(2015, 2015, 12, 25)]
        [DataRow(2016, 2016, 12, 25)]
        [DataRow(2017, 2017, 12, 25)]
        [DataRow(2018, 2018, 12, 25)]
        [DataRow(2019, 2019, 12, 25)]
        [DataRow(2020, 2020, 12, 25)]
        [DataRow(2021, 2021, 12, 25)]
        [DataRow(2022, 2022, 12, 25)]
        [DataRow(2023, 2023, 12, 25)]
        [DataRow(2024, 2024, 12, 25)]
        [DataRow(2025, 2025, 12, 25)]
        [DataRow(2026, 2026, 12, 25)]
        [DataRow(2027, 2027, 12, 25)]
        [DataRow(2028, 2028, 12, 25)]
        [DataRow(2029, 2029, 12, 25)]
        [DataRow(2030, 2030, 12, 25)]
        [DataRow(2031, 2031, 12, 25)]
        [DataRow(2032, 2032, 12, 25)]
        [DataRow(2033, 2033, 12, 25)]
        [DataRow(2034, 2034, 12, 25)]
        public void TestChristmasDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CHRISTMASDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2004, 2004, 12, 26)]
        [DataRow(2005, 2005, 12, 26)]
        [DataRow(2006, 2006, 12, 26)]
        [DataRow(2007, 2007, 12, 26)]
        [DataRow(2008, 2008, 12, 26)]
        [DataRow(2009, 2009, 12, 26)]
        [DataRow(2010, 2010, 12, 26)]
        [DataRow(2011, 2011, 12, 26)]
        [DataRow(2012, 2012, 12, 26)]
        [DataRow(2013, 2013, 12, 26)]
        [DataRow(2014, 2014, 12, 26)]
        [DataRow(2015, 2015, 12, 26)]
        [DataRow(2016, 2016, 12, 26)]
        [DataRow(2017, 2017, 12, 26)]
        [DataRow(2018, 2018, 12, 26)]
        [DataRow(2019, 2019, 12, 26)]
        [DataRow(2020, 2020, 12, 26)]
        [DataRow(2021, 2021, 12, 26)]
        [DataRow(2022, 2022, 12, 26)]
        [DataRow(2023, 2023, 12, 26)]
        [DataRow(2024, 2024, 12, 26)]
        [DataRow(2025, 2025, 12, 26)]
        [DataRow(2026, 2026, 12, 26)]
        [DataRow(2027, 2027, 12, 26)]
        [DataRow(2028, 2028, 12, 26)]
        [DataRow(2029, 2029, 12, 26)]
        [DataRow(2030, 2030, 12, 26)]
        [DataRow(2031, 2031, 12, 26)]
        [DataRow(2032, 2032, 12, 26)]
        [DataRow(2033, 2033, 12, 26)]
        [DataRow(2034, 2034, 12, 26)]
        public void TestStStephensDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "STSTEPHENSDAY-01", observedYear, month, day);
        }

        #endregion

        #region Easter based public holidays

        [TestMethod]
        [DataRow(2004, 2004, 4, 12)]
        [DataRow(2005, 2005, 3, 28)]
        [DataRow(2006, 2006, 4, 17)]
        [DataRow(2007, 2007, 4, 9)]
        [DataRow(2008, 2008, 3, 24)]
        [DataRow(2009, 2009, 4, 13)]
        [DataRow(2010, 2010, 4, 5)]
        [DataRow(2011, 2011, 4, 25)]
        [DataRow(2012, 2012, 4, 9)]
        [DataRow(2013, 2013, 4, 1)]
        [DataRow(2014, 2014, 4, 21)]
        [DataRow(2015, 2015, 4, 6)]
        [DataRow(2016, 2016, 3, 28)]
        [DataRow(2017, 2017, 4, 17)]
        [DataRow(2018, 2018, 4, 2)]
        [DataRow(2019, 2019, 4, 22)]
        [DataRow(2020, 2020, 4, 13)]
        [DataRow(2021, 2021, 4, 5)]
        [DataRow(2022, 2022, 4, 18)]
        [DataRow(2023, 2023, 4, 10)]
        [DataRow(2024, 2024, 4, 1)]
        [DataRow(2025, 2025, 4, 21)]
        [DataRow(2026, 2026, 4, 6)]
        [DataRow(2027, 2027, 3, 29)]
        [DataRow(2028, 2028, 4, 17)]
        [DataRow(2029, 2029, 4, 2)]
        [DataRow(2030, 2030, 4, 22)]
        [DataRow(2031, 2031, 4, 14)]
        [DataRow(2032, 2032, 3, 29)]
        [DataRow(2033, 2033, 4, 18)]
        [DataRow(2034, 2034, 4, 10)]
        public void TestEasterMonday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CEASTERMONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2004, 2004, 5, 20)]
        [DataRow(2005, 2005, 5, 5)]
        [DataRow(2006, 2006, 5, 25)]
        [DataRow(2007, 2007, 5, 17)]
        [DataRow(2008, 2008, 5, 1)] //Same day as Staatsfeiertag
        [DataRow(2009, 2009, 5, 21)]
        [DataRow(2010, 2010, 5, 13)]
        [DataRow(2011, 2011, 6, 2)]
        [DataRow(2012, 2012, 5, 17)]
        [DataRow(2013, 2013, 5, 9)]
        [DataRow(2014, 2014, 5, 29)]
        [DataRow(2015, 2015, 5, 14)]
        [DataRow(2016, 2016, 5, 5)]
        [DataRow(2017, 2017, 5, 25)]
        [DataRow(2018, 2018, 5, 10)]
        [DataRow(2019, 2019, 5, 30)]
        [DataRow(2020, 2020, 5, 21)]
        [DataRow(2021, 2021, 5, 13)]
        [DataRow(2022, 2022, 5, 26)]
        [DataRow(2023, 2023, 5, 18)]
        [DataRow(2024, 2024, 5, 9)]
        [DataRow(2025, 2025, 5, 29)]
        [DataRow(2026, 2026, 5, 14)]
        [DataRow(2027, 2027, 5, 6)]
        [DataRow(2028, 2028, 5, 25)]
        [DataRow(2029, 2029, 5, 10)]
        [DataRow(2030, 2030, 5, 30)]
        [DataRow(2031, 2031, 5, 22)]
        [DataRow(2032, 2032, 5, 6)]
        [DataRow(2033, 2033, 5, 26)]
        [DataRow(2034, 2034, 5, 18)]
        public void TestAscensionDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CASCENSIONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2004, 2004, 5, 31)]
        [DataRow(2005, 2005, 5, 16)]
        [DataRow(2006, 2006, 6, 5)]
        [DataRow(2007, 2007, 5, 28)]
        [DataRow(2008, 2008, 5, 12)]
        [DataRow(2009, 2009, 6, 1)]
        [DataRow(2010, 2010, 5, 24)]
        [DataRow(2011, 2011, 6, 13)]
        [DataRow(2012, 2012, 5, 28)]
        [DataRow(2013, 2013, 5, 20)]
        [DataRow(2014, 2014, 6, 9)]
        [DataRow(2015, 2015, 5, 25)]
        [DataRow(2016, 2016, 5, 16)]
        [DataRow(2017, 2017, 6, 5)]
        [DataRow(2018, 2018, 5, 21)]
        [DataRow(2019, 2019, 6, 10)]
        [DataRow(2020, 2020, 6, 1)]
        [DataRow(2021, 2021, 5, 24)]
        [DataRow(2022, 2022, 6, 6)]
        [DataRow(2023, 2023, 5, 29)]
        [DataRow(2024, 2024, 5, 20)]
        [DataRow(2025, 2025, 6, 9)]
        [DataRow(2026, 2026, 5, 25)]
        [DataRow(2027, 2027, 5, 17)]
        [DataRow(2028, 2028, 6, 5)]
        [DataRow(2029, 2029, 5, 21)]
        [DataRow(2030, 2030, 6, 10)]
        [DataRow(2031, 2031, 6, 2)]
        [DataRow(2032, 2032, 5, 17)]
        [DataRow(2033, 2033, 6, 6)]
        [DataRow(2034, 2034, 5, 29)]
        public void TestWhitMonday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CWHITMONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2004, 2004, 6, 10)]
        [DataRow(2005, 2005, 5, 26)]
        [DataRow(2006, 2006, 6, 15)]
        [DataRow(2007, 2007, 6, 7)]
        [DataRow(2008, 2008, 5, 22)]
        [DataRow(2009, 2009, 6, 11)]
        [DataRow(2010, 2010, 6, 3)]
        [DataRow(2011, 2011, 6, 23)]
        [DataRow(2012, 2012, 6, 7)]
        [DataRow(2013, 2013, 5, 30)]
        [DataRow(2014, 2014, 6, 19)]
        [DataRow(2015, 2015, 6, 4)]
        [DataRow(2016, 2016, 5, 26)]
        [DataRow(2017, 2017, 6, 15)]
        [DataRow(2018, 2018, 5, 31)]
        [DataRow(2019, 2019, 6, 20)]
        [DataRow(2020, 2020, 6, 11)]
        [DataRow(2021, 2021, 6, 3)]
        [DataRow(2022, 2022, 6, 16)]
        [DataRow(2023, 2023, 6, 8)]
        [DataRow(2024, 2024, 5, 30)]
        [DataRow(2025, 2025, 6, 19)]
        [DataRow(2026, 2026, 6, 4)]
        [DataRow(2027, 2027, 5, 27)]
        [DataRow(2028, 2028, 6, 15)]
        [DataRow(2029, 2029, 5, 31)]
        [DataRow(2030, 2030, 6, 20)]
        [DataRow(2031, 2031, 6, 12)]
        [DataRow(2032, 2032, 5, 27)]
        [DataRow(2033, 2033, 6, 16)]
        [DataRow(2034, 2034, 6, 8)]
        public void TestCorpusChristi(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CCORPUSCHRISTI-01", observedYear, month, day);
        }

        #endregion

        #region Not a public holiday

        [TestMethod]
        [DataRow(2004)]
        [DataRow(2018)]
        [DataRow(2019)]
        [DataRow(2026)]
        public void TestGoodFridayIsNotAPublicHoliday(int year)
        {
            //Karfreitag is only marked as a non-statutory day ("A") in the Vienna calendar,
            //since 2019 it is replaced by the "persönlicher Feiertag" (BGBl. I Nr. 22/2019)
            this.AssertNoHoliday(year, "CGOODFRIDAY-01");
        }

        #endregion

        #region Public holidays per year

        [TestMethod]
        [DataRow(2008)]
        [DataRow(2017)]
        [DataRow(2025)]
        [DataRow(2026)]
        [DataRow(2034)]
        public void TestNationwidePublicHolidayCount(int year)
        {
            //13 statutory holidays (Feiertagsruhegesetz 1957 §1) plus Easter Sunday and Whit Sunday
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.AT)
                .Where(o => o.HolidayTypes.HasFlag(Models.HolidayTypes.Public) && o.NationalHoliday)
                .ToArray();

            Assert.HasCount(15, publicHolidays);
        }

        #endregion

        #region Regional school holidays (Landespatrone)

        [TestMethod]
        public void TestSaintJosephsDay()
        {
            this.AssertObservedDate(2026, "SAINTJOSEPHSDAY-01", 2026, 3, 19);
            this.AssertSubdivisionCodes(2026, "SAINTJOSEPHSDAY-01", "AT-2", "AT-6", "AT-7", "AT-8");
        }

        [TestMethod]
        public void TestSaintFloriansDay()
        {
            this.AssertObservedDate(2026, "SAINTFLORIANSDAY-01", 2026, 5, 4);
            this.AssertSubdivisionCodes(2026, "SAINTFLORIANSDAY-01", "AT-4");
        }

        [TestMethod]
        public void TestSaintRupertsDay()
        {
            this.AssertObservedDate(2026, "SAINTRUPERTSDAY-01", 2026, 9, 24);
            this.AssertSubdivisionCodes(2026, "SAINTRUPERTSDAY-01", "AT-5");
        }

        [TestMethod]
        public void TestSaintMartinsDay()
        {
            this.AssertObservedDate(2026, "SAINTMARTINSDAY-01", 2026, 11, 11);
            this.AssertSubdivisionCodes(2026, "SAINTMARTINSDAY-01", "AT-1");
        }

        [TestMethod]
        public void TestSaintLeopoldsDay()
        {
            this.AssertObservedDate(2026, "SAINTLEOPOLDSDAY-01", 2026, 11, 15);
            this.AssertSubdivisionCodes(2026, "SAINTLEOPOLDSDAY-01", "AT-3", "AT-9");
        }

        #endregion

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
            var isWeekend = date.IsWeekend(CountryCode.AT);
            Assert.AreEqual(expectedIsWeekend, isWeekend);
        }
    }
}
