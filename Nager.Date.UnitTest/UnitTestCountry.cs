﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Enum;
using Nager.Date.Utils;

namespace Nager.Date.UnitTest
{
    [TestClass]
    public class UnitTestCountry
    {
        [TestMethod]
        public void TestAustria()
        {
            for (var year = DateTime.Now.Year; year < 3000; year++)
            {
                var publicHolidays = DateSystem.GetPublicHoliday(ECountry.AT.GetDescription(), year);
                Assert.AreEqual(13, publicHolidays.Count);
            }
        }

        [TestMethod]
        public void TestGermany()
        {
            for (var year = DateTime.Now.Year; year < 3000; year++)
            {
                var publicHolidays = DateSystem.GetPublicHoliday(ECountry.DE.GetDescription(), year);
                Assert.AreEqual(9, publicHolidays.Count);
            }
        }

        [TestMethod]
        public void TestSwitzerland()
        {
            for (var year = DateTime.Now.Year; year < 3000; year++)
            {
                var publicHolidays = DateSystem.GetPublicHoliday(ECountry.CH.GetDescription(), year);
                Assert.AreEqual(21, publicHolidays.Count);
            }
        }

        [TestMethod]
        public void TestSpain()
        {
            for (var year = DateTime.Now.Year; year < 3000; year++)
            {
                var publicHolidays = DateSystem.GetPublicHoliday(ECountry.ES.GetDescription(), year);
                Assert.AreEqual(34, publicHolidays.Count);
            }
        }
    }
}