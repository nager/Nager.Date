using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.ReligiousProviders;
using System;

namespace Nager.Date.UnitTest.Common
{
    [TestClass]
    public class CatholicProviderTest
    {
        [DataTestMethod]
        [DataRow(1800, 4, 13)]
        [DataRow(1810, 4, 22)]
        [DataRow(1820, 4, 2)]
        [DataRow(1830, 4, 11)]
        [DataRow(1840, 4, 19)]
        [DataRow(1850, 3, 31)]
        [DataRow(1860, 4, 8)]
        [DataRow(1870, 4, 17)]
        [DataRow(1880, 3, 28)]
        [DataRow(1890, 4, 6)]
        [DataRow(1900, 4, 15)]
        [DataRow(1910, 3, 27)]
        [DataRow(1920, 4, 4)]
        [DataRow(1930, 4, 20)]
        [DataRow(1940, 3, 24)]
        [DataRow(1950, 4, 9)]
        [DataRow(1960, 4, 17)]
        [DataRow(1970, 3, 29)]
        [DataRow(1980, 4, 6)]
        [DataRow(1990, 4, 15)]
        [DataRow(2000, 4, 23)]
        [DataRow(2001, 4, 15)]
        [DataRow(2002, 3, 31)]
        [DataRow(2003, 4, 20)]
        [DataRow(2004, 4, 11)]
        [DataRow(2005, 3, 27)]
        [DataRow(2006, 4, 16)]
        [DataRow(2007, 4, 8)]
        [DataRow(2008, 3, 23)]
        [DataRow(2009, 4, 12)]
        [DataRow(2010, 4, 4)]
        [DataRow(2011, 4, 24)]
        [DataRow(2012, 4, 8)]
        [DataRow(2013, 3, 31)]
        [DataRow(2014, 4, 20)]
        [DataRow(2015, 4, 5)]
        [DataRow(2016, 3, 27)]
        [DataRow(2017, 4, 16)]
        [DataRow(2018, 4, 1)]
        [DataRow(2019, 4, 21)]
        [DataRow(2020, 4, 12)]
        [DataRow(2021, 4, 4)]
        [DataRow(2022, 4, 17)]
        [DataRow(2023, 4, 9)]
        [DataRow(2024, 3, 31)]
        [DataRow(2025, 4, 20)]
        [DataRow(2026, 4, 5)]
        [DataRow(2027, 3, 28)]
        [DataRow(2028, 4, 16)]
        [DataRow(2029, 4, 1)]
        [DataRow(2030, 4, 21)]
        [DataRow(2040, 4, 1)]
        [DataRow(2050, 4, 10)]
        [DataRow(2060, 4, 18)]
        [DataRow(2070, 3, 30)]
        [DataRow(2080, 4, 7)]
        [DataRow(2090, 4, 16)]
        [DataRow(2100, 3, 28)]
        [DataRow(2110, 4, 6)]
        [DataRow(2200, 4, 6)]
        public void CheckEasterSunday(int year, int month, int day)
        {
            var catholicProvider = new CatholicProvider();

            var easterSunday = catholicProvider.EasterSunday(year);
            Assert.AreEqual(new DateTime(year, month, day), easterSunday);
        }
    }
}
