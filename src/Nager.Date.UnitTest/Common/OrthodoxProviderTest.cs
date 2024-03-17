using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.ReligiousProviders;
using Nager.Date.UnitTest.Helpers;
using System;

namespace Nager.Date.UnitTest.Common
{
    [TestClass]
    public class OrthodoxProviderTest
    {
        [DataTestMethod]
        [DataRow(1800, 4, 20)]
        [DataRow(1810, 4, 29)]
        [DataRow(1820, 4, 9)]
        [DataRow(1830, 4, 18)]
        [DataRow(1840, 4, 26)]
        [DataRow(1850, 5, 5)]
        [DataRow(1860, 4, 15)]
        [DataRow(1870, 4, 24)]
        [DataRow(1880, 5, 2)]
        [DataRow(1890, 4, 13)]
        [DataRow(1900, 4, 22)]
        [DataRow(1910, 5, 1)]
        [DataRow(1920, 4, 11)]
        [DataRow(1930, 4, 20)]
        [DataRow(1940, 4, 28)]
        [DataRow(1950, 4, 9)]
        [DataRow(1960, 4, 17)]
        [DataRow(1970, 4, 26)]
        [DataRow(1980, 4, 6)]
        [DataRow(1990, 4, 15)]
        [DataRow(2001, 4, 15)]
        [DataRow(2002, 5, 5)]
        [DataRow(2003, 4, 27)]
        [DataRow(2004, 4, 11)]
        [DataRow(2005, 5, 1)]
        [DataRow(2006, 4, 23)]
        [DataRow(2007, 4, 8)]
        [DataRow(2008, 4, 27)]
        [DataRow(2009, 4, 19)]
        [DataRow(2010, 4, 4)]
        [DataRow(2011, 4, 24)]
        [DataRow(2012, 4, 15)]
        [DataRow(2013, 5, 5)]
        [DataRow(2014, 4, 20)]
        [DataRow(2015, 4, 12)]
        [DataRow(2016, 5, 1)]
        [DataRow(2017, 4, 16)]
        [DataRow(2018, 4, 8)]
        [DataRow(2019, 4, 28)]
        [DataRow(2020, 4, 19)]
        [DataRow(2021, 5, 2)]
        [DataRow(2022, 4, 24)]
        [DataRow(2023, 4, 16)]
        [DataRow(2024, 5, 5)]
        [DataRow(2025, 4, 20)]
        [DataRow(2026, 4, 12)]
        [DataRow(2027, 5, 2)]
        [DataRow(2028, 4, 16)]
        [DataRow(2029, 4, 8)]
        [DataRow(2030, 4, 28)]
        [DataRow(2050, 4, 17)]
        [DataRow(2075, 4, 7)]
        [DataRow(2090, 4, 23)]
        [DataRow(2091, 4, 8)]
        [DataRow(2092, 4, 27)]
        [DataRow(2093, 4, 19)]
        [DataRow(2094, 4, 11)]
        [DataRow(2095, 4, 24)]
        [DataRow(2096, 4, 15)]
        [DataRow(2097, 5, 5)]
        [DataRow(2098, 4, 27)]
        [DataRow(2099, 4, 12)]
        [DataRow(2100, 5, 2)]
        [DataRow(2101, 4, 24)]
        [DataRow(2102, 4, 9)]
        [DataRow(2110, 4, 13)]
        [DataRow(2120, 4, 21)]
        [DataRow(2130, 4, 30)]
        [DataRow(2140, 4, 10)]
        public void CheckEasterSunday(int year, int month, int day)
        {
            var orthodoxProvider = new OrthodoxProvider();

            var easterSunday = orthodoxProvider.EasterSunday(year);
            Assert.AreEqual(new DateTime(year, month, day), easterSunday);
        }

        [TestMethod]
        public void CompareComplexWithSimpleCalculation()
        {
            var orthodoxProvider = new OrthodoxProvider();

            for (var year = 1583; year <= 3399; year++)
            {
                var easterSunday1 = OrthodoxEasterSundayHelper.CalculateEasterSunday(year);
                var easterSunday2 = orthodoxProvider.EasterSunday(year);

                Assert.AreEqual(easterSunday1, easterSunday2);
            }
        }
    }
}
