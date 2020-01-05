using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class RomaniaTest
    {
        [TestMethod]
        public void TestRomania2017()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(2017, CountryCode.RO).ToArray();

            //New Year's Day
            Assert.AreEqual(new DateTime(2017, 1, 1), publicHolidays[0].Date);
            //Day after New Year's Day
            Assert.AreEqual(new DateTime(2017, 1, 2), publicHolidays[1].Date);
            //Union Day/Small Union
            Assert.AreEqual(new DateTime(2017, 1, 24), publicHolidays[2].Date);
            //Easter Sunday
            Assert.AreEqual(new DateTime(2017, 4, 16), publicHolidays[3].Date);
            //Easter Monday
            Assert.AreEqual(new DateTime(2017, 4, 17), publicHolidays[4].Date);
            //Labour Day
            Assert.AreEqual(new DateTime(2017, 5, 1), publicHolidays[5].Date);
            //Children's Day
            Assert.AreEqual(new DateTime(2017, 6, 1), publicHolidays[6].Date);
            //Pentecost
            Assert.AreEqual(new DateTime(2017, 6, 4), publicHolidays[7].Date);
            //Whit Monday
            Assert.AreEqual(new DateTime(2017, 6, 5), publicHolidays[8].Date);
            //Dormition of the Theotokos
            Assert.AreEqual(new DateTime(2017, 8, 15), publicHolidays[9].Date);
            //St. Andrew's Day
            Assert.AreEqual(new DateTime(2017, 11, 30), publicHolidays[10].Date);
            //National Day/Great Union
            Assert.AreEqual(new DateTime(2017, 12, 1), publicHolidays[11].Date);
            //Christmas Day
            Assert.AreEqual(new DateTime(2017, 12, 25), publicHolidays[12].Date);
            //St. Stephen's Day
            Assert.AreEqual(new DateTime(2017, 12, 26), publicHolidays[13].Date);
        }

        [TestMethod]
        public void TestRomania2018()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(2018, CountryCode.RO).ToArray();

            //New Year's Day
            Assert.AreEqual(new DateTime(2018, 1, 1), publicHolidays[0].Date);
            //Day after New Year's Day
            Assert.AreEqual(new DateTime(2018, 1, 2), publicHolidays[1].Date);
            //Union Day/Small Union
            Assert.AreEqual(new DateTime(2018, 1, 24), publicHolidays[2].Date);
            //Good Friday
            Assert.AreEqual(new DateTime(2018, 4, 6), publicHolidays[3].Date);
            //Easter Sunday
            Assert.AreEqual(new DateTime(2018, 4, 8), publicHolidays[4].Date);
            //Easter Monday
            Assert.AreEqual(new DateTime(2018, 4, 9), publicHolidays[5].Date);
            //Labour Day
            Assert.AreEqual(new DateTime(2018, 5, 1), publicHolidays[6].Date);
            //Pentecost
            Assert.AreEqual(new DateTime(2018, 5, 27), publicHolidays[7].Date);
            //Whit Monday
            Assert.AreEqual(new DateTime(2018, 5, 28), publicHolidays[8].Date);
            //Children's Day
            Assert.AreEqual(new DateTime(2018, 6, 1), publicHolidays[9].Date);
            //Dormition of the Theotokos
            Assert.AreEqual(new DateTime(2018, 8, 15), publicHolidays[10].Date);
            //St. Andrew's Day
            Assert.AreEqual(new DateTime(2018, 11, 30), publicHolidays[11].Date);
            //National Day/Great Union
            Assert.AreEqual(new DateTime(2018, 12, 1), publicHolidays[12].Date);
            //Christmas Day
            Assert.AreEqual(new DateTime(2018, 12, 25), publicHolidays[13].Date);
            //St. Stephen's Day
            Assert.AreEqual(new DateTime(2018, 12, 26), publicHolidays[14].Date);
        }

        [TestMethod]
        public void TestRomania2019()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(2019, CountryCode.RO).ToArray();

            //New Year's Day
            Assert.AreEqual(new DateTime(2019, 1, 1), publicHolidays[0].Date);
            //Day after New Year's Day
            Assert.AreEqual(new DateTime(2019, 1, 2), publicHolidays[1].Date);
            //Union Day/Small Union
            Assert.AreEqual(new DateTime(2019, 1, 24), publicHolidays[2].Date);
            //Good Friday
            Assert.AreEqual(new DateTime(2019, 4, 26), publicHolidays[3].Date);
            //Easter Sunday
            Assert.AreEqual(new DateTime(2019, 4, 28), publicHolidays[4].Date);
            //Easter Monday
            Assert.AreEqual(new DateTime(2019, 4, 29), publicHolidays[5].Date);
            //Labour Day
            Assert.AreEqual(new DateTime(2019, 5, 1), publicHolidays[6].Date);
            //Children's Day
            Assert.AreEqual(new DateTime(2019, 6, 1), publicHolidays[7].Date);
            //Pentecost
            Assert.AreEqual(new DateTime(2019, 6, 16), publicHolidays[8].Date);
            //Whit Monday
            Assert.AreEqual(new DateTime(2019, 6, 17), publicHolidays[9].Date);
            //Dormition of the Theotokos
            Assert.AreEqual(new DateTime(2019, 8, 15), publicHolidays[10].Date);
            //St. Andrew's Day
            Assert.AreEqual(new DateTime(2019, 11, 30), publicHolidays[11].Date);
            //National Day/Great Union
            Assert.AreEqual(new DateTime(2019, 12, 1), publicHolidays[12].Date);
            //Christmas Day
            Assert.AreEqual(new DateTime(2019, 12, 25), publicHolidays[13].Date);
            //St. Stephen's Day
            Assert.AreEqual(new DateTime(2019, 12, 26), publicHolidays[14].Date);
        }

        [TestMethod]
        public void TestRomania2020()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(2020, CountryCode.RO).ToArray();

            //New Year's Day
            Assert.AreEqual(new DateTime(2020, 1, 1), publicHolidays[0].Date);
            //Day after New Year's Day
            Assert.AreEqual(new DateTime(2020, 1, 2), publicHolidays[1].Date);
            //Union Day/Small Union
            Assert.AreEqual(new DateTime(2020, 1, 24), publicHolidays[2].Date);
            //Good Friday
            Assert.AreEqual(new DateTime(2020, 4, 17), publicHolidays[3].Date);
            //Easter Sunday
            Assert.AreEqual(new DateTime(2020, 4, 19), publicHolidays[4].Date);
            //Easter Monday
            Assert.AreEqual(new DateTime(2020, 4, 20), publicHolidays[5].Date);
            //Labour Day
            Assert.AreEqual(new DateTime(2020, 5, 1), publicHolidays[6].Date);
            //Children's Day
            Assert.AreEqual(new DateTime(2020, 6, 1), publicHolidays[7].Date);
            //Pentecost
            Assert.AreEqual(new DateTime(2020, 6, 7), publicHolidays[8].Date);
            //Whit Monday
            Assert.AreEqual(new DateTime(2020, 6, 8), publicHolidays[9].Date);
            //Dormition of the Theotokos
            Assert.AreEqual(new DateTime(2020, 8, 15), publicHolidays[10].Date);
            //St. Andrew's Day
            Assert.AreEqual(new DateTime(2020, 11, 30), publicHolidays[11].Date);
            //National Day/Great Union
            Assert.AreEqual(new DateTime(2020, 12, 1), publicHolidays[12].Date);
            //Christmas Day
            Assert.AreEqual(new DateTime(2020, 12, 25), publicHolidays[13].Date);
            //St. Stephen's Day
            Assert.AreEqual(new DateTime(2020, 12, 26), publicHolidays[14].Date);
        }

        [TestMethod]
        public void TestRomania2021()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(2021, CountryCode.RO).ToArray();

            //New Year's Day
            Assert.AreEqual(new DateTime(2021, 1, 1), publicHolidays[0].Date);
            //Day after New Year's Day
            Assert.AreEqual(new DateTime(2021, 1, 2), publicHolidays[1].Date);
            //Union Day/Small Union
            Assert.AreEqual(new DateTime(2021, 1, 24), publicHolidays[2].Date);
            //Good Friday
            Assert.AreEqual(new DateTime(2021, 4, 30), publicHolidays[3].Date);
            //Labour Day
            Assert.AreEqual(new DateTime(2021, 5, 1), publicHolidays[4].Date);
            //Easter Sunday
            Assert.AreEqual(new DateTime(2021, 5, 2), publicHolidays[5].Date);
            //Easter Monday
            Assert.AreEqual(new DateTime(2021, 5, 3), publicHolidays[6].Date);
            //Children's Day
            Assert.AreEqual(new DateTime(2021, 6, 1), publicHolidays[7].Date);
            //Pentecost
            Assert.AreEqual(new DateTime(2021, 6, 20), publicHolidays[8].Date);
            //Whit Monday
            Assert.AreEqual(new DateTime(2021, 6, 21), publicHolidays[9].Date);
            //Dormition of the Theotokos
            Assert.AreEqual(new DateTime(2021, 8, 15), publicHolidays[10].Date);
            //St. Andrew's Day
            Assert.AreEqual(new DateTime(2021, 11, 30), publicHolidays[11].Date);
            //National Day/Great Union
            Assert.AreEqual(new DateTime(2021, 12, 1), publicHolidays[12].Date);
            //Christmas Day
            Assert.AreEqual(new DateTime(2021, 12, 25), publicHolidays[13].Date);
            //St. Stephen's Day
            Assert.AreEqual(new DateTime(2021, 12, 26), publicHolidays[14].Date);
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
            var result = date.IsWeekend(CountryCode.RO);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
